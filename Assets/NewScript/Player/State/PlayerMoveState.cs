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
        Vector2 input = player.MoveInput;

        if (input.magnitude < 0.1f)
        {
            player.ChangeState(new PlayerIdleState(player));
            return;
        }

        Vector3 moveDirection = new Vector3(input.x, 0, input.y); // Z方向移動
        player.MoveCharacter(moveDirection, player.moveForce);
    }

    public override void Exit()
    {
        player.animator.SetBool("isWalk", false);
        player.PlayerEffectScript.StopEffect((int)playerEffectScript.EffectName.SMOKE);
        player.SeBox.StopPlayerSE();
    }
}
