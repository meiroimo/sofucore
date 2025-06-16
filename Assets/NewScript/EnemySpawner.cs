using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class EnemySpawner : MonoBehaviour
{
    public Transform player; //�v���C���[�̈ʒu
    public GameObject enemyPrefab;   // �o��������G�v���n�u
    public Transform[] spawnPoints;  // �X�|�[���ʒu
    public float spawnInterval = 5f; // �G���o��������Ԋu
    public int maxEnemies = 10;      // �����ɑ��݂ł���G�̍ő吔

    private int currentEnemyCount = 0;//���݂̓G�̏o����

    void Start()
    {
        //InvokeRepeating(���\�b�h��, ����̑҂�����, �J��Ԃ��̊Ԋu)
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

        // �G�̃J�E���g���X�V
        currentEnemyCount++;

        // �G�����񂾂Ƃ��ɃJ�E���g�����炷������G���ōs��
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        enemyController.SetPlayer(player);
        if (enemyController != null)
        {
            //�G�����񂾂Ƃ��ɁAcurrentEnemyCount--;�����s����@�Ƃ����Ӗ�
            enemyController.OnDeath += () => currentEnemyCount--;
        }
    }
}
