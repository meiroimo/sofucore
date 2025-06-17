using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class EnemySpawner : MonoBehaviour
{
    public Transform player; // �v���C���[�̈ʒu
    public GameObject enemyPrefab;   // �o��������G�v���n�u
    public Transform[] spawnPoints;  // �X�|�[���ʒu
    public float spawnInterval = 5f; // �G���o��������Ԋu
    public int maxEnemies = 10;      // �����ɑ��݂ł���G�̍ő吔
    public int enemyTypeNo = 1;      // CSV����ǂݍ��ޓG�̎��

    private int currentEnemyCount = 0;
    private CSVReader csvReader;     // CSVReader�ւ̎Q��
    private EnemyStatus_Script enemyStatus;

    void Start()
    {
        // �V�[������CSVReader��T���ĎQ��
        csvReader = FindObjectOfType<CSVReader>();
        if (csvReader == null)
        {
            Debug.LogError("CSVReader���V�[���Ɍ�����܂���I");
            return;
        }

        // �J��Ԃ��Ăяo���J�n
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (currentEnemyCount >= maxEnemies) return;

        // �����_���ȃX�|�[���n�_��I��
        int index = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];

        // �G�𐶐�
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // �X�e�[�^�X�ݒ�
        EnemyStatus_Script enemyStatus = enemy.GetComponent<EnemyStatus_Script>();
        if (enemyStatus != null)
        {
            csvReader.SetEnemyStatusScript(enemyStatus);
            csvReader.LoadingEnemyStatus(enemyTypeNo);                // CSV����X�e�[�^�X�ǂݍ���
        }
        else
        {
            Debug.LogWarning("EnemyStatus_Script ���v���n�u�ɂ���܂���");
        }

        // �G�̃J�E���g���X�V
        currentEnemyCount++;

        // �G�����S�����Ƃ��ɃJ�E���g����
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.SetPlayer(player);
            enemyController.OnDeath += () => currentEnemyCount--;
        }
    }
}
