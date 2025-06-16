using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{
    public override void Enter(EnemyController enemy) { }

    public override void Update(EnemyController enemy)
    {
        // �v���C���[�̈ʒu�Ɍ������Ĉړ�
        enemy.Agent.SetDestination(enemy.player.position);

        // �U���͈͂ɓ�������U����Ԃ�
        if (enemy.IsPlayerInAttackRange())
        {
            enemy.ChangeState(new AttackState());
        }
    }

    public override void Exit(EnemyController enemy) { }
}
