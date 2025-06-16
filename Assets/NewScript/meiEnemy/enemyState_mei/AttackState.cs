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
        enemy.AttackPlayer();     // 攻撃処理（ここは適宜実装）

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
            Debug.Log("Hit player!"); // ここでプレイヤーのダメージ処理を呼び出せる
            enemy.player.GetComponent<PlayerController>()?.TakeDamage(1);
        }

        //float sphereRadius = 0.5f;
        //float castHeight = 1.5f;
        //Vector3 origin = enemy.transform.position + Vector3.up * castHeight;
        //Vector3 direction = (enemy.player.position + Vector3.up * 1f - origin).normalized;

        //RaycastHit[] hits = Physics.SphereCastAll(origin, sphereRadius, direction, attackRange);

        //// 最も近いPlayerを見つける
        //float closestDistance = Mathf.Infinity;
        //RaycastHit? playerHit = null;

        //foreach (var hit in hits)
        //{
        //    if (hit.collider.CompareTag("Player"))
        //    {
        //        float distance = hit.distance;
        //        if (distance < closestDistance)
        //        {
        //            closestDistance = distance;
        //            playerHit = hit;
        //        }
        //    }
        //}

        //if (playerHit.HasValue)
        //{
        //    Debug.Log("Enemy hit the player!");

        //    PlayerController playerHealth = playerHit.Value.collider.GetComponent<PlayerController>();
        //    if (playerHealth != null)
        //    {
        //        playerHealth.TakeDamage(damage);
        //    }
        //}

        //    int playerLayer = LayerMask.GetMask("Player");
        //    float sphereRadius = 0.5f; // 攻撃の太さ（幅）
        //    float castHeight = 1.5f;   // 敵の胸の高さなど
        //    Vector3 origin = enemy.transform.position + Vector3.up * castHeight;
        //    Vector3 direction = (enemy.player.position + Vector3.up * 1f - origin).normalized;

        //    RaycastHit[] hits = Physics.SphereCastAll(origin, sphereRadius, direction, attackRange, playerLayer);

        //    foreach (var hit in hits)
        //    {
        //        Debug.Log("name:" + hit.collider.name);
        //        if (hit.collider.CompareTag("Player"))
        //        {
        //            Debug.Log("Enemy hit the player!");

        //            // ダメージ処理（仮想）
        //            PlayerController playerHealth = hit.collider.GetComponent<PlayerController>();
        //            if (playerHealth != null)
        //            {
        //                playerHealth.TakeDamage(damage);
        //            }

        //            break; // プレイヤーに当たったら終了
        //        }
        //    }

        //    Debug.DrawRay(origin, direction * attackRange, Color.red, 1f);
        //}
    }
}

