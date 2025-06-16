using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class EnemySpawner : MonoBehaviour
{
    public Transform player; //プレイヤーの位置
    public GameObject enemyPrefab;   // 出現させる敵プレハブ
    public Transform[] spawnPoints;  // スポーン位置
    public float spawnInterval = 5f; // 敵を出現させる間隔
    public int maxEnemies = 10;      // 同時に存在できる敵の最大数

    private int currentEnemyCount = 0;//現在の敵の出現数

    void Start()
    {
        //InvokeRepeating(メソッド名, 初回の待ち時間, 繰り返しの間隔)
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

        // 敵のカウントを更新
        currentEnemyCount++;

        // 敵が死んだときにカウントを減らす処理を敵側で行う
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        enemyController.SetPlayer(player);
        if (enemyController != null)
        {
            //敵が死んだときに、currentEnemyCount--;を実行する　という意味
            enemyController.OnDeath += () => currentEnemyCount--;
        }
    }
}
