using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTackleState : BossState
{

    public override void Enter(BossController boss)
    {
        Debug.Log("tackle");
    }

    public override void Update(BossController boss)
    {
        
        //// �v���C���[�̈ʒu�Ɍ������Ĉړ�
        //boss.Agent.SetDestination(boss.player.position);

        //// �U���͈͂ɓ�������U����Ԃ�
        //if (boss.IsPlayerInAttackRange())
        //{
        //    boss.ChangeState(new BossAttackState());
        //}
    }

    public override void Exit(BossController boss) { }
}
