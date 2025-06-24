using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] Transform player; // �v���C���[�̈ʒu
    [SerializeField] GameObject bossPrefab;
    [SerializeField] Transform bossSpawnPoint;

    [SerializeField] CSVReader csvReader;//CSVReader���C���X�y�N�^�[�Ŏw��
    [SerializeField] int bossTypeNo = 1;//CSV��̃{�X�̍s�ԍ�

    public GameTimer gameTimer;

    private bool bossSpawned = false;

    private void Start()
    {
        //�C�x���g�ɓo�^
        gameTimer.OnTimeReached += SpawnBoss;
    }

    void SpawnBoss()
    {
        if (bossSpawned) return;

        GameObject boss = Instantiate(bossPrefab, bossSpawnPoint.position, bossSpawnPoint.rotation);

        // �X�e�[�^�X�X�N���v�g�擾
        EnemyStatus_Script status = boss.GetComponent<EnemyStatus_Script>();
        if (status != null && csvReader != null)
        {
            csvReader.SetEnemyStatusScript(status);
            csvReader.LoadingEnemyStatus(bossTypeNo);// CSV����X�e�[�^�X�ǂݍ���
        }

        bossSpawned = true;
        Debug.Log("�{�X�o���I");
        BossController bossController = boss.GetComponent<BossController>();
        if (bossController != null)
        {
            bossController.SetPlayer(player);
            //bossController.OnDeath += () => currentEnemyCount--;
        }
    }
}
