using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [Header("�̗�")]
    public float maxHP;
    private float currentHP;
    EnemyStatus_Script enemyStatus_Script;
    BossController bossController;

    // ���S�C�x���g�i���X�N���v�g�ƘA�g�ł���j
    public event System.Action OnDeath;

    private void Awake()
    {
        enemyStatus_Script = GetComponent<EnemyStatus_Script>();
        bossController = GetComponent<BossController>();
    }

    private void Start()
    {
        maxHP = enemyStatus_Script.enemy_MaxHealth;
        currentHP = maxHP;
        Debug.Log(currentHP);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log($"{gameObject.name} �� {damage} �_���[�W���󂯂��I �c��HP: {currentHP}");

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Debug.Log($"{gameObject.name} �͓|���ꂽ�I");
        OnDeath?.Invoke(); // ���S�C�x���g�𔭉΁i�X�R�A���Z��G�t�F�N�g�Đ��Ȃǁj
        //Destroy(gameObject); // �G�I�u�W�F�N�g������
    }
}
