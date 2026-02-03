using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

/// <summary>
/// プレイヤーの移動状態
/// </summary>
public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(PlayerController player) : base(player) { }
    float time = 0;

    public override void Enter()
    {
        player.CurrentMoveSpeed = player.moveForce;
        player.PlayerMotionScript.runMotion(true);

        player.SeBox.PlayPlayerSE(PlayerSEBox.SENAME.MOVE);
    }

    public override void Update()
    {
        if (player.IsAvoid) return;
        Vector2 moveInput = player.MoveInput;
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);


        if (moveDir.sqrMagnitude < 0.01f)
        {
            player.ChangeState(new PlayerIdleState(player));
            return;
        }

        // Shiftキー押下で走りに移行
        if (player.IsRunning)
        {
            player.ChangeState(new PlayerRunState(player));
            return;
        }

        player.CallHealStamina();
        player.MoveCharacter(moveDir, player.CurrentMoveSpeed);
    }

    public override void Exit()
    {
        player.PlayerMotionScript.runMotion(false);
        player.SeBox.StopPlayerSE();
    }

}