using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        Debug.Log("Entered Move State");
    }

    public override void Update()
    {
        Vector2 input = player.MoveInput;

        if (input.magnitude < 0.1f)
        {
            player.ChangeState(new PlayerIdleState(player));
            return;
        }

        // 入力に応じて力を加える
        Vector3 force = new Vector3(input.x, 0, input.y) * player.moveForce;

        // 地面との摩擦を避けるため Y軸の速度を保ちつつ方向だけ変える（任意）
        //Vector3 currentVelocity = player.Rigid.velocity;
        //Vector3 targetVelocity = new Vector3(force.x, currentVelocity.y, force.z);
        //player.Rigid.velocity = Vector3.Lerp(currentVelocity, targetVelocity, 0.1f);

        Vector3 moveDirection = new Vector3(input.x, 0, input.y); // Z方向移動
        player.Rigid.velocity = moveDirection * player.moveForce + new Vector3(0, player.Rigid.velocity.y, 0); // Yは重力に任せる

        player.RotateTowards(moveDirection); // ← 向きを変更

    }

    public override void Exit()
    {
        Debug.Log("Exited Move State");
    }
}
