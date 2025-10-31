using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChaseState : BossState
{
    public override void Enter(BossController boss) { }

    public override void Update(BossController boss)
    {
        // プレイヤーの位置に向かって移動
        boss.Agent.SetDestination(boss.player.position);

        // 攻撃範囲に入ったら攻撃状態へ
        if (boss.IsPlayerInAttackRange())
        {
            boss.ChangeState(new BossAttackState());

        }
    }

    public override void Exit(BossController boss) { }
}
