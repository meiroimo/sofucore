using UnityEngine;
using UnityEngine.Windows;

/// <summary>
/// プレイヤーの必殺技（8回連続ひっかき）を制御するステート
/// </summary>
public class PlayerSkillAttackState : PlayerState
{
    private int attackCount = 0;                // 今までのひっかき回数
    private float attackInterval = 0.5f;        // 各ひっかきの間隔（秒）
    private float timer = 0f;                   // 経過時間
    private int maxAttacks = 8;                 // 最大ひっかき回数（8回）

    private float attackMoveSpeedMultiplier = 1.2f; // 攻撃中の移動速度倍率（通常の1.2倍）

    Ray ray;

    private float attackRadius = 5f;
    private float attackAngle = 50f;
    private int attackDamage = 10;
    private LayerMask enemyLayer;

    public PlayerSkillAttackState(PlayerController player) : base(player)
    {
        this.enemyLayer = player.enemyLayer; // コントローラーからレイヤー取得
    }

    public override void Enter()
    {
        //Debug.Log("Entered LightAttack State");
        attackCount = 0;
        timer = 0f;

        //player.SetInvincible(true);             // 攻撃中は無敵にする
        Debug.Log($"ひっかき攻撃{attackCount + 1}回目");
        //DoClawAttack();                         // 最初のひっかき攻撃を発動
    }

    public override void Update()
    {
        // プレイヤーの移動（入力に応じて、速度は1.2倍）
        Vector2 moveInput = player.MoveInput;

        if (moveInput != Vector2.zero)
        {
            //Vector3 moveDir = player.GetCameraRelativeDirection(moveInput);
            Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y); // Z方向移動
            player.MoveCharacter(moveDirection, player.moveForce * attackMoveSpeedMultiplier);
        }

        //マウス位置へのRayを取得
        ray = player.mainCamera.ScreenPointToRay(UnityEngine.Input.mousePosition);

        //プレイヤーの高さに水平な仮想平面を作成
        Plane groundPlane = new Plane(Vector3.up, player.transform.position);

        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 lookPoint = ray.GetPoint(distance);

            // 3. プレイヤーがマウス位置の方向を向く
            Vector3 targetDirection = lookPoint - player.transform.position;
            targetDirection.y = 0f; // 水平のみ回転
            if (targetDirection != Vector3.zero)
            {
                player.transform.rotation = Quaternion.LookRotation(targetDirection);
            }
        }

        //PlayerLAttack();

        // 時間をカウントしてひっかき間隔を管理
        timer += Time.deltaTime;

        // 最大回数に到達したら終了（Idleに戻す）
        if (attackCount >= maxAttacks)
        {
            player.ChangeState(new PlayerIdleState(player));
            return;
        }

        // 一定時間経過したら次のひっかきを発動
        if (timer >= attackInterval)
        {
            timer = 0f;
            //Debug.Log($"ひっかき攻撃{attackCount + 1}回目");
            DoClawAttack();
        }

        // 攻撃が終わったら待機状態に戻す
        //player.ChangeState(new PlayerIdleState(player));



    }

    public override void Exit()
    {
        //Debug.Log("Exited LightAttack State");
    }

    // ひとつのひっかき処理
    private void DoClawAttack()
    {
        attackCount++;                          // 回数カウント

        //player.PlayAttackAnimation(attackCount); // アニメーション（Claw1 / Claw2 切替）
        //player.DealDamageInFront();              // 前方にダメージを与える処理（当たり判定）
        PlayerLAttack();
    }


    private void PlayerLAttack()
    {
        Vector3 origin = player.transform.position;
        Vector3 forward = player.transform.forward;

        Collider[] hits = Physics.OverlapSphere(origin, attackRadius, enemyLayer);

        foreach (Collider col in hits)
        {
            Vector3 dirToTarget = (col.transform.position - origin).normalized;
            dirToTarget.y = 0; // 水平のみで比較

            float angle = Vector3.Angle(forward, dirToTarget);
            if (angle < attackAngle / 2f)
            {
                Debug.Log($"{col.name} に攻撃が命中しました！");
                //Enemy enemy = col.GetComponent<Enemy>();
                //if (enemy != null)
                //{
                //    enemy.TakeDamage(attackDamage);
                //    
                //}
            }
        }
    }
}
