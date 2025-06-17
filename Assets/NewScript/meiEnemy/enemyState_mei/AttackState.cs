using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class AttackState : EnemyState
{
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;
    public int damage = 10;

    private float lastAttackTime;
    private Quaternion fixedRotation; // �U�����̌Œ����


    public override void Enter(EnemyController enemy)
    {
        enemy.Agent.ResetPath();  // �U�����͈ړ���~
        //enemy.AttackPlayer();     // �U�������i�����͓K�X�����j

        // �������v���C���[�ɌŒ�
        Vector3 direction = (enemy.player.position - enemy.transform.position).normalized;
        direction.y = 0;
        if (direction != Vector3.zero)
        {
            enemy.transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public override void Update(EnemyController enemy)
    {
        // �v���C���[���U���͈͊O�ɂȂ�����ǐՂɖ߂�
        if (!enemy.IsPlayerInAttackRange())
        {
            enemy.ChangeState(new ChaseState());
            return;
        }

        // �N�[���_�E�����I�������U��
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            PerformAttack(enemy);
            lastAttackTime = Time.time;
        }
    }

    public override void Exit(EnemyController enemy) { }

    private void PerformAttack(EnemyController enemy)
    {
        // �U������F�U���͈͓��̃v���C���[���m�F
        if (enemy.DistanceToPlayer <= attackRange + 0.5f)
        {
            //Debug.Log("Hit player!"); // �����Ńv���C���[�̃_���[�W�������Ăяo����
            enemy.player.GetComponent<PlayerController>()?.TakeDamage(1);
        }
    }
}

