using UnityEngine;

/// <summary>
/// プレイヤーの移動状態
/// </summary>
public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(PlayerController player) : base(player) { }


    public override void Enter()
    {
        player.animator.SetBool("isWalk", true);
        player.PlayerEffectScript.PlayEffect((int)playerEffectScript.EffectName.SMOKE);
        //        bird_Audio.PlayOneShot(jump_SE);
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
        if (player.IsRunning)
        {
            player.ChangeState(new PlayerRunState(player));
            return;
        }

        player.MoveCharacter(moveDir, player.moveForce);
    }

    public override void Exit()
    {
        player.animator.SetBool("isWalk", false);
        player.PlayerEffectScript.StopEffect((int)playerEffectScript.EffectName.SMOKE);
        player.SeBox.StopPlayerSE();
    }
}
