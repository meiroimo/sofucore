using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossState
{
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;
    public float attackDelay = 0.8f; // 攻撃までの待機時間

    private float delayTimer = 0f;
    private float lastAttackTime = 0f;
    private bool isDelaying = true;

    public override void Enter(BossController boss)
    {
        boss.Agent.ResetPath();  // 攻撃中は移動停止

        // プレイヤーの方向を向く
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
        // プレイヤーが離れたら追跡へ戻る
        if (!boss.IsPlayerInAttackRange())
        {
            boss.ChangeState(new BossChaseState());
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
            PerformAttack(boss);
            lastAttackTime = Time.time;
        }
    }

    public override void Exit(BossController boss)
    {
        // 状態終了時にタイマーリセット
        delayTimer = 0f;
        isDelaying = false;
    }

    private void PerformAttack(BossController boss)
    {
        // 攻撃判定：攻撃範囲内のプレイヤーを確認
        if (boss.DistanceToPlayer <= attackRange + 0.5f)
        {
            //Debug.Log("Hit player!"); // ここでプレイヤーのダメージ処理を呼び出せる
            boss.player.GetComponent<PlayerController>()?.TakeDamage((int)boss.Boss_Power);
        }
    }
}
