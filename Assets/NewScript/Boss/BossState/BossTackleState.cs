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
        
        //// プレイヤーの位置に向かって移動
        //boss.Agent.SetDestination(boss.player.position);

        //// 攻撃範囲に入ったら攻撃状態へ
        //if (boss.IsPlayerInAttackRange())
        //{
        //    boss.ChangeState(new BossAttackState());
        //}
    }

    public override void Exit(BossController boss) { }
}
