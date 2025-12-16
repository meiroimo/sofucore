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

    [Header("イベントによる倍率変更")]
    public float enemyScaleMultiplier = 1f;

    public float spawnRadiusMin = 10f;
    public float spawnRadiusMax = 20f;

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
        csvReader.SetFinalEnemyStatusScript(this);
        csvReader.LoadingEnemyFinalStatus(2);
    }

    private void Update()
    {
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

        //敵をランダムに選んで生成
        GameObject prefab = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
        GameObject enemy = Instantiate(prefab, spawnPos, Quaternion.identity);

        //ステータス設定
        EnemyStatus_Script enemyStatus = enemy.GetComponent<EnemyStatus_Script>();
        if (enemyStatus != null)
        {
            csvReader.SetEnemyStatusScript(enemyStatus);
            csvReader.LoadingEnemyStatus(enemyStatusTypeNo);
            ApplyDifficultyBuff(enemyStatus);
        }
        else
        {
            Debug.LogWarning("EnemyStatus_Script がプレハブにありません");
        }

        TreasureChestDropScript treasureChestDropScript = enemy.GetComponentInChildren<TreasureChestDropScript>();
        if(treasureChestDropScript != null)
        {
            float d = Difficulty.GetDifficultyPercent();
            float middleDrop = Mathf.Lerp(40, 99, d);
            treasureChestDropScript.DropRate = (int)Mathf.Round(middleDrop);

        }

        //大きさ変更（イベントで倍率が変わる）
        enemy.transform.localScale *= enemyScaleMultiplier;

        //敵数カウント
        currentEnemyCount++;

        //死亡時に減らす
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

        //Debug.LogWarning("有効なスポーン位置が見つかりませんでした。");
        return Vector3.zero;

    }


    float enemy_Final_MaxHealth;
    float enemy_Final_Attack_Power;
    float enemy_Final_Defense;
    float enemy_Final_Speed;

    public float Enemy_Final_MaxHealth { get => enemy_Final_MaxHealth; set => enemy_Final_MaxHealth = value; }
    public float Enemy_Final_Attack_Power { get => enemy_Final_Attack_Power; set => enemy_Final_Attack_Power = value; }
    public float Enemy_Final_Defense { get => enemy_Final_Defense; set => enemy_Final_Defense = value; }
    public float Enemy_Final_Speed { get => enemy_Final_Speed; set => enemy_Final_Speed = value; }

    /// <summary>
    /// 難易度に応じてステータスを強化する
    /// </summary>
    void ApplyDifficultyBuff(EnemyStatus_Script status)
    {
        float d = Difficulty.GetDifficultyPercent();

        float middleHP = Mathf.Lerp(status.enemy_MaxHealth, enemy_Final_MaxHealth, d);
        float middleAtk = Mathf.Lerp(status.enemy_Attack_Power, enemy_Final_Attack_Power, d);
        float middleDef = Mathf.Lerp(status.enemy_Defense, enemy_Final_Defense, d);
        float middleSpeed = Mathf.Lerp(status.enemy_Speed, enemy_Final_Speed, d);

        status.enemy_MaxHealth = Mathf.Round(middleHP);
        status.enemy_Attack_Power = Mathf.Round(middleAtk);
        status.enemy_Defense = Mathf.Round(middleDef);
        status.enemy_Speed = Mathf.Round(middleSpeed);

        //Debug.LogWarning(status.enemy_MaxHealth);
    }
}
