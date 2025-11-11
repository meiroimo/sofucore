using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerState
{
    private float runSpeed;

    public PlayerRunState(PlayerController player) : base(player) 
    {
        runSpeed = player.moveForce * 1.6f;//í èÌÇÊÇË60%ë¨Ç≠
    }

    public override void Enter()
    {
        //player.animator.SetBool("isRun", true);
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

        // ShiftÉLÅ[Çó£ÇµÇΩÇÁí èÌà⁄ìÆÇ…ñﬂÇ∑
        if (!player.IsRunning)
        {
            player.ChangeState(new PlayerMoveState(player));
            return;
        }

        player.MoveCharacter(moveDir, runSpeed);
    }

    public override void Exit()
    {
        //player.animator.SetBool("isRun", false);

    }

}
