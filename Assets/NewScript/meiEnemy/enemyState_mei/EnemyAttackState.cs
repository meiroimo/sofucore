using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;
    public float attackDelay = 0.8f; // 攻撃までの待機時間

    private float delayTimer = 0f;
    private float lastAttackTime = 0f;
    private bool isDelaying = true;


    public override void Enter(EnemyController enemy)
    {
        enemy.Agent.ResetPath();  // 攻撃中は移動停止

        // プレイヤーの方向を向く
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
        // プレイヤーが離れたら追跡へ戻る
        if (!enemy.IsPlayerInAttackRange())
        {
            enemy.ChangeState(new EnemyChaseState());
            return;
        }

        // 攻撃前待ち時間処理
        if (isDelaying)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer >= attackDelay)
            {
                isDelaying = false;
                lastAttackTime = Time.time - attackCooldown; // 待ち時間後すぐ攻撃できるよう調整
            }
            return;
        }

        // クールダウンが終わったら攻撃
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            enemy.StartCoroutine(PerformAttack(enemy));
            lastAttackTime = Time.time;
        }
    }

    public override void Exit(EnemyController enemy) 
    {
        // 状態終了時にタイマーリセット
        delayTimer = 0f;
        isDelaying = false;
    }

    IEnumerator PerformAttack(EnemyController enemy)
    {
        enemy.Enemy_SE.PlayEnemySE(EnemySEBox.SENAME.ATTACK);
        yield return new WaitForSeconds(0.7f);
        // 攻撃判定：攻撃範囲内のプレイヤーを確認
        if (enemy.DistanceToPlayer <= attackRange + 0.5f)
        {
            //Debug.Log("Hit player!"); // ここでプレイヤーのダメージ処理を呼び出せる
            enemy.StartAttackEffect();
            enemy.Enemy_SE.PlayEnemySE(EnemySEBox.SENAME.HIT);
            enemy.player.GetComponent<PlayerController>()?.TakeDamage((int)enemy.Enemy_Power);
        }
    }
}
