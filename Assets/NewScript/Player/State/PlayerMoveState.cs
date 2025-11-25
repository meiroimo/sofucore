using UnityEngine;

/// <summary>
/// プレイヤーの移動状態
/// </summary>
public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(PlayerController player) : base(player) { }


    public override void Enter()
    {
        player.PlayerMotionScript.runMotion(true);

        player.PlayerEffectScript.PlayEffect((int)playerEffectScript.EffectName.SMOKE);
        player.SeBox.PlayPlayerSE(PlayerSEBox.SENAME.MOVE);
    }

    public override void Update()
    {
        Vector2 moveInput = player.MoveInput;
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);

        if (moveDir.sqrMagnitude < 0.01f)
        {
            player.ChangeState(new PlayerIdleState(player));
            return;
        }

        // Shiftキー押下で走りに移行
        if (player.IsRunning && player.TakeAvoid(5))
        {
            player.ChangeState(new PlayerRunState(player));
            return;
        }

        player.CallHealStamina();
        player.MoveCharacter(moveDir, player.moveForce);
    }

    public override void Exit()
    {
        player.PlayerMotionScript.runMotion(false);
        player.PlayerEffectScript.StopEffect((int)playerEffectScript.EffectName.SMOKE);
        player.SeBox.StopPlayerSE();
    }
}
