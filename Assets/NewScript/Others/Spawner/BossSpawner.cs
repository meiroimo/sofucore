using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.BoolParameter;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] Transform player; // プレイヤーの位置
    [SerializeField] GameObject bossPrefab;
    [SerializeField] Transform bossSpawnPoint;


    [SerializeField] CSVReader csvReader;//CSVReaderをインスペクターで指定
    [SerializeField] int bossTypeNo = 2;//CSV上のボスの行番号

    [SerializeField] BossWarningUI bossWarningUI;

    public GameTimer gameTimer;

    private bool bossSpawned = false;

    private void Start()
    {
        //イベントに登録
        gameTimer.OnTimeReached += StartSpawnBoss;
    }

    void StartSpawnBoss()
    {
        StartCoroutine(SpawnBossCoroutine());
    }

    IEnumerator SpawnBossCoroutine()
    {
        if (bossSpawned || ResultClear.Instance.isGameClear)
            yield break;

        bossSpawned = true;

        if (bossWarningUI != null)
        {
            bossWarningUI.Show();
        }

        yield return new WaitForSeconds(bossWarningUI.DisplayTime);

        GameObject boss = Instantiate(bossPrefab, bossSpawnPoint.position, bossSpawnPoint.rotation);

        EnemyStatus_Script status = boss.GetComponent<EnemyStatus_Script>();
        if (status != null && csvReader != null)
        {
            csvReader.SetEnemyStatusScript(status);
            csvReader.LoadingEnemyStatus(bossTypeNo);
        }

        BossController bossController = boss.GetComponent<BossController>();
        if (bossController != null)
        {
            bossController.SetPlayer(player, player.GetComponent<PlayerStatus_Script>());
        }
    }
}


