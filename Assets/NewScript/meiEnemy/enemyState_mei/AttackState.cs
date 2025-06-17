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
    private Quaternion fixedRotation; // 攻撃中の固定向き


    public override void Enter(EnemyController enemy)
    {
        enemy.Agent.ResetPath();  // 攻撃中は移動停止
        //enemy.AttackPlayer();     // 攻撃処理（ここは適宜実装）

        // 向きをプレイヤーに固定
        Vector3 direction = (enemy.player.position - enemy.transform.position).normalized;
        direction.y = 0;
        if (direction != Vector3.zero)
        {
            enemy.transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public override void Update(EnemyController enemy)
    {
        // プレイヤーが攻撃範囲外になったら追跡に戻る
        if (!enemy.IsPlayerInAttackRange())
        {
            enemy.ChangeState(new ChaseState());
            return;
        }

        // クールダウンが終わったら攻撃
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            PerformAttack(enemy);
            lastAttackTime = Time.time;
        }
    }

    public override void Exit(EnemyController enemy) { }

    private void PerformAttack(EnemyController enemy)
    {
        // 攻撃判定：攻撃範囲内のプレイヤーを確認
        if (enemy.DistanceToPlayer <= attackRange + 0.5f)
        {
            //Debug.Log("Hit player!"); // ここでプレイヤーのダメージ処理を呼び出せる
            enemy.player.GetComponent<PlayerController>()?.TakeDamage(1);
        }
    }
}

