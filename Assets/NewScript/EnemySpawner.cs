using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class EnemySpawner : MonoBehaviour
{
    public Transform player; // プレイヤーの位置
    public GameObject enemyPrefab;   // 出現させる敵プレハブ
    public Transform[] spawnPoints;  // スポーン位置
    public float spawnInterval = 5f; // 敵を出現させる間隔
    public int maxEnemies = 10;      // 同時に存在できる敵の最大数
    public int enemyTypeNo = 1;      // CSVから読み込む敵の種類

    private int currentEnemyCount = 0;
    private CSVReader csvReader;     // CSVReaderへの参照
    private EnemyStatus_Script enemyStatus;

    void Start()
    {
        // シーン内のCSVReaderを探して参照
        csvReader = FindObjectOfType<CSVReader>();
        if (csvReader == null)
        {
            Debug.LogError("CSVReaderがシーンに見つかりません！");
            return;
        }

        // 繰り返し呼び出し開始
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (currentEnemyCount >= maxEnemies) return;

        // ランダムなスポーン地点を選択
        int index = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];

        // 敵を生成
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // ステータス設定
        EnemyStatus_Script enemyStatus = enemy.GetComponent<EnemyStatus_Script>();
        if (enemyStatus != null)
        {
            csvReader.SetEnemyStatusScript(enemyStatus);
            csvReader.LoadingEnemyStatus(enemyTypeNo);                // CSVからステータス読み込み
        }
        else
        {
            Debug.LogWarning("EnemyStatus_Script がプレハブにありません");
        }

        // 敵のカウントを更新
        currentEnemyCount++;

        // 敵が死亡したときにカウント減少
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.SetPlayer(player);
            enemyController.OnDeath += () => currentEnemyCount--;
        }
    }
}
