using UnityEngine;

/// <summary>
/// プレイヤーの立ち状態
/// </summary>
public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerController player) : base(player) { }

    public override void Enter()
    {

    }

    public override void Update()
    {
        //magnitude:ベクトルの長さ
        if (player.MoveInput.magnitude > 0.1f)
        {
            player.ChangeState(new PlayerMoveState(player));
        }
        // 滑り防止：XZ方向を完全に止める
        Vector3 stopped = player.Rigid.velocity;
        stopped.x = 0;
        stopped.z = 0;
        player.Rigid.velocity = stopped;

    }

    public override void Exit()
    {

    }
}
