using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossState
{
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;
    public float attackDelay = 0.8f; // �U���܂ł̑ҋ@����

    private float delayTimer = 0f;
    private float lastAttackTime = 0f;
    private bool isDelaying = true;

    public override void Enter(BossController boss)
    {
        boss.Agent.ResetPath();  // �U�����͈ړ���~

        // �v���C���[�̕���������
        Vector3 direction = (boss.player.position - boss.transform.position).normalized;
        direction.y = 0;
        if (direction != Vector3.zero)
        {
            boss.transform.rotation = Quaternion.LookRotation(direction);
        }

        delayTimer = 0f;
        isDelaying = true;
    }

    public override void Update(BossController boss)
    {
        // �v���C���[�����ꂽ��ǐՂ֖߂�
        if (!boss.IsPlayerInAttackRange())
        {
            boss.ChangeState(new BossChaseState());
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
            PerformAttack(boss);
            lastAttackTime = Time.time;
        }
    }

    public override void Exit(BossController boss)
    {
        // ��ԏI�����Ƀ^�C�}�[���Z�b�g
        delayTimer = 0f;
        isDelaying = false;
    }

    private void PerformAttack(BossController boss)
    {
        // �U������F�U���͈͓��̃v���C���[���m�F
        if (boss.DistanceToPlayer <= attackRange + 0.5f)
        {
            //Debug.Log("Hit player!"); // �����Ńv���C���[�̃_���[�W�������Ăяo����
            boss.player.GetComponent<PlayerController>()?.TakeDamage((int)boss.Boss_Power);
        }
    }
}
