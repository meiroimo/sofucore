using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;
    public float attackDelay = 0.8f; // �U���܂ł̑ҋ@����

    private float delayTimer = 0f;
    private float lastAttackTime = 0f;
    private bool isDelaying = true;

    public override void Enter(EnemyController enemy)
    {
        enemy.Agent.ResetPath();  // �U�����͈ړ���~

        // �v���C���[�̕���������
        Vector3 direction = (enemy.player.position - enemy.transform.position).normalized;
        direction.y = 0;
        if (direction != Vector3.zero)
        {
            enemy.transform.rotation = Quaternion.LookRotation(direction);
        }

        delayTimer = 0f;
        isDelaying = true;
    }

    public override void Update(EnemyController enemy)
    {
        // �v���C���[�����ꂽ��ǐՂ֖߂�
        if (!enemy.IsPlayerInAttackRange())
        {
            enemy.ChangeState(new EnemyChaseState());
            return;
        }

        // �U���O�҂����ԏ���
        if (isDelaying)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer >= attackDelay)
            {
                isDelaying = false;
                lastAttackTime = Time.time - attackCooldown; // �҂����Ԍシ���U���ł���悤����
            }
            return;
        }

        // �N�[���_�E�����I�������U��
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            PerformAttack(enemy);
            lastAttackTime = Time.time;
        }
    }

    public override void Exit(EnemyController enemy) 
    {
        // ��ԏI�����Ƀ^�C�}�[���Z�b�g
        delayTimer = 0f;
        isDelaying = false;
    }

    private void PerformAttack(EnemyController enemy)
    {
        // �U������F�U���͈͓��̃v���C���[���m�F
        if (enemy.DistanceToPlayer <= attackRange + 0.5f)
        {
            //Debug.Log("Hit player!"); // �����Ńv���C���[�̃_���[�W�������Ăяo����
            enemy.player.GetComponent<PlayerController>()?.TakeDamage((int)enemy.Enemy_Power);
        }
    }
}
