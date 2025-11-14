using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : EnemyState
{
    public override void Enter(EnemyController enemy) { }

    public override void Update(EnemyController enemy)
    {

        //NavMeshAgent が無効 / NavMesh上にいない → SetDestination禁止
        //if (enemy.Agent == null || !enemy.Agent.isActiveAndEnabled || !enemy.Agent.isOnNavMesh)
        //{
        //    return;
        //}

        // プレイヤーの位置に向かって移動
        enemy.Agent.SetDestination(enemy.player.position);

        // 攻撃範囲に入ったら攻撃状態へ
        if (enemy.IsPlayerInAttackRange())
        {
            enemy.ChangeState(new EnemyAttackState());
        }
    }

    public override void Exit(EnemyController enemy) { }
}
