using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] Transform player; // プレイヤーの位置
    [SerializeField] GameObject bossPrefab;
    [SerializeField] Transform bossSpawnPoint;

    [SerializeField] CSVReader csvReader;//CSVReaderをインスペクターで指定
    [SerializeField] int bossTypeNo = 1;//CSV上のボスの行番号

    public GameTimer gameTimer;

    private bool bossSpawned = false;

    private void Start()
    {
        //イベントに登録
        gameTimer.OnTimeReached += SpawnBoss;
    }

    void SpawnBoss()
    {
        if (bossSpawned) return;

        GameObject boss = Instantiate(bossPrefab, bossSpawnPoint.position, bossSpawnPoint.rotation);

        // ステータススクリプト取得
        EnemyStatus_Script status = boss.GetComponent<EnemyStatus_Script>();
        if (status != null && csvReader != null)
        {
            csvReader.SetEnemyStatusScript(status);
            csvReader.LoadingEnemyStatus(bossTypeNo);// CSVからステータス読み込み
        }

        bossSpawned = true;
        Debug.Log("ボス出現！");
        BossController bossController = boss.GetComponent<BossController>();
        if (bossController != null)
        {
            bossController.SetPlayer(player);
            //bossController.OnDeath += () => currentEnemyCount--;
        }
    }
}
