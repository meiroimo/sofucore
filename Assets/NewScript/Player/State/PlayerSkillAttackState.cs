using UnityEngine;
using UnityEngine.Windows;

/// <summary>
/// プレイヤーの必殺技（8回連続ひっかき）を制御するステート
/// </summary>
public class PlayerSkillAttackState : PlayerState
{
    private int attackCount = 0;                // 今までのひっかき回数
    private float attackInterval = 0.1f;        // 各ひっかきの間隔（秒）
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
        player.PlayerEffectScript.PlayEffect((int)playerEffectScript.EffectName.SLASH);
        player.PlayerEffectScript.PlayEffect((int)playerEffectScript.EffectName.AURA);
        attackCount = 0;
        timer = 0f;
        player.PlayerMotionScript.ultMotion(true);

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

        SkillAttackDir();

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

    }

    public override void Exit()
    {
        //Debug.Log("Exited LightAttack State");

        //player.PlayerEffectScript.StopEffect((int)playerEffectScript.EffectName.AURA);
        player.PlayerEffectScript.StopEffect((int)playerEffectScript.EffectName.SLASH);
        player.PlayerMotionScript.ultMotion(false);


    }

    // ひとつのひっかき処理
    private void DoClawAttack()
    {
        attackCount++;// 回数カウント
        player.PlayerLAttack();
    }

    private void SkillAttackDir()
    {
        Vector2 rightInput = player.AttackStickInput;

        if (rightInput.sqrMagnitude > 0.1f)
        {
            Vector3 direction = new Vector3(rightInput.x, 0, rightInput.y);
            player.transform.rotation = Quaternion.LookRotation(direction);
        }
        else
        {
            //マウス位置へのRayを取得
            ray = player.mainCamera.ScreenPointToRay(UnityEngine.Input.mousePosition);
            //プレイヤーの高さに水平な仮想平面を作成
            Plane groundPlane = new Plane(Vector3.up, player.transform.position);

            if (groundPlane.Raycast(ray, out float distance))
            {
                //プレイヤーがマウス位置の方向を向く
                Vector3 lookPoint = ray.GetPoint(distance);
                Vector3 targetDirection = lookPoint - player.transform.position;
                targetDirection.y = 0f;

                if (targetDirection != Vector3.zero)
                {
                    player.transform.rotation = Quaternion.LookRotation(targetDirection);
                }
            }
        }
    }

    #region
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
                EnemyController enemy = col.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.OnHit(player);
                    return;
                }
                BossController boss = col.GetComponent<BossController>();
                if (boss != null)
                {
                    boss.OnHit(player);
                }

            }
        }
    }
    #endregion
}
