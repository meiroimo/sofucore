using UnityEngine;

public class PlayerLightAttackState : PlayerState
{
    Ray ray;

    private float attackRadius = 5f;
    private float attackAngle = 60f;
    private int attackDamage = 10;
    private LayerMask enemyLayer;

    public PlayerLightAttackState(PlayerController player) : base(player) 
    {
        this.enemyLayer = player.enemyLayer; // コントローラーからレイヤー取得
    }

    public override void Enter()
    {
        //Debug.Log("Entered LightAttack State");

    }

    public override void Update()
    {
        //マウス位置へのRayを取得
        ray = player.mainCamera.ScreenPointToRay(Input.mousePosition);

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

        PlayerLAttack();

        // 攻撃が終わったら待機状態に戻す
        player.ChangeState(new PlayerIdleState(player));

    }

    public override void Exit()
    {
        //Debug.Log("Exited LightAttack State");
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
                EnemyController enemy = col.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.OnHit(player);

                }
            }
        }
    }


}
