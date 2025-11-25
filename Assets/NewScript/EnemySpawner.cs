using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR;

public class EnemySpawner : MonoBehaviour
{
    [Header("基本設定")]
    public Transform player; // プレイヤーの位置
    public GameObject[] enemyPrefab; // 出現させる敵プレハブ
    [Header("敵を出現させる間隔")] public Vector2 spawnInterval; // 敵を出現させる間隔
    float nextSpawnTime;
    public int maxEnemies; // 同時に存在できる敵の最大数
    [Header("一度に出す敵の数")] public Vector2 spawnCountPerWave; // 一度に出す敵の数
    public int enemyStatusTypeNo = 1; // CSVから読み込む敵の種類

    public float spawnRadiusMin = 10f;
    public float spawnRadiusMax = 20f;
    public float spawnHeight = 0f;

    private float timer;

    [Header("障害物チェック設定")]
    public LayerMask obstacleLayer; // 障害物レイヤー
    public float checkRadius = 1.0f; // 出現位置周囲の判定半径
    public int maxSpawnTries = 10; // 再抽選回数（障害物がある場合）

    private int currentEnemyCount = 0;
    private CSVReader csvReader;

    void Start()
    {
        // CSVReaderを探す
        csvReader = FindObjectOfType<CSVReader>();
        if (csvReader == null)
        {
            Debug.LogError("CSVReaderがシーンに見つかりません！");
            return;
        }

        // 一定間隔で呼び出し
        //InvokeRepeating(nameof(SpawnEnemyWave), 1f, spawnInterval);
    }

    private void Update()
    {
        //timer += Time.deltaTime;

        //if (timer >= spawnInterval)
        //{
        //    SpawnEnemyWave();
        //    timer = 0;
        //}

        if(Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawnsTime = Mathf.Lerp(spawnInterval.y, spawnInterval.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawnsTime;
            SpawnEnemyWave();
        }
    }

    /// <summary>
    /// 一度に複数の敵を出す（ウェーブ生成）
    /// </summary>
    void SpawnEnemyWave()
    {
        float secoundsBetweenSpawnEnemiesMaxCount = Mathf.Lerp(spawnCountPerWave.y, spawnCountPerWave.x, Difficulty.GetDifficultyPercent());
        if (ResultClear.Instance.isGameClear) return;

        if (currentEnemyCount >= maxEnemies) return;

        int spawnable = Mathf.Min((int)secoundsBetweenSpawnEnemiesMaxCount, maxEnemies - currentEnemyCount);

        for (int i = 0; i < spawnable; i++)
        {
            SpawnSingleEnemy();
        }
    }

    /// <summary>
    /// 敵1体を出現させる
    /// </summary>
    void SpawnSingleEnemy()
    {
        Vector3 spawnPos = GetValidSpawnPosition();

        if (spawnPos == Vector3.zero)
        {
            return;
        }

        // 敵をランダムに選んで生成
        GameObject prefab = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
        GameObject enemy = Instantiate(prefab, spawnPos, Quaternion.identity);

        // ステータス設定
        EnemyStatus_Script enemyStatus = enemy.GetComponent<EnemyStatus_Script>();
        if (enemyStatus != null)
        {
            csvReader.SetEnemyStatusScript(enemyStatus);
            csvReader.LoadingEnemyStatus(enemyStatusTypeNo);
        }
        else
        {
            Debug.LogWarning("EnemyStatus_Script がプレハブにありません");
        }

        // 敵数カウント
        currentEnemyCount++;

        // 死亡時に減らす
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.SetPlayer(player);
            enemyController.OnDeath += () => currentEnemyCount--;
            PlayerStatusCache.SaveDefats();
        }
    }

    /// <summary>
    /// 有効なスポーン位置を選ぶ（障害物があれば再抽選）
    /// </summary>
    Vector3 GetValidSpawnPosition()
    {
        for (int i = 0; i < maxSpawnTries; i++)
        {
            //ランダム方向と距離を決定
            Vector2 randomDir = Random.insideUnitCircle.normalized;
            float distance = Random.Range(spawnRadiusMin, spawnRadiusMax);

            //プレイヤーの周囲に候補位置を設定（XZ平面）
            Vector3 candidate = player.position + new Vector3(randomDir.x * distance, 0f, randomDir.y * distance);

            //NavMesh上の最近点を取得
            NavMeshHit hit;
            bool foundNavMesh = NavMesh.SamplePosition(candidate, out hit, 2.0f, NavMesh.AllAreas);

            if (foundNavMesh)
            {
                //障害物チェック
                bool hasObstacle = Physics.CheckSphere(hit.position, checkRadius, obstacleLayer);

                if (!hasObstacle)
                {
                    //NavMesh上かつ障害物なし
                    return hit.position;
                }
            }
        }

        Debug.LogWarning("有効なスポーン位置が見つかりませんでした。");
        return Vector3.zero;

    }
}
