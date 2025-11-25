using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerState
{
    private float runSpeed;
    private float nextStaminaDecreaseTime;
    private float staminaDecrease = 1;

    public PlayerRunState(PlayerController player) : base(player) 
    {
        runSpeed = player.moveForce * 1.6f;//’Êí‚æ‚è60%‘¬‚­
    }

    public override void Enter()
    {
        if (!player.TakeAvoid(5))
        {
            player.ChangeState(new PlayerMoveState(player));
            return;
        }
        player.PlayerMotionScript.runMotion(true);
        player.PlayerEffectScript.PlayEffect((int)playerEffectScript.EffectName.SMOKE);
        player.SeBox.PlayPlayerSE(PlayerSEBox.SENAME.MOVE);
    }

    public override void Update()
    {
        Vector2 moveInput = player.MoveInput;
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);

        if (Time.time > nextStaminaDecreaseTime)
        {
            nextStaminaDecreaseTime = Time.time + staminaDecrease;
            if (!player.TakeAvoid(5))
            {
                player.ChangeState(new PlayerMoveState(player));
                return;
            }
        }

        if (moveDir.sqrMagnitude < 0.01f)
        {
            player.ChangeState(new PlayerIdleState(player));
            return;
        }

        // ShiftƒL[‚ð—£‚µ‚½‚ç’ÊíˆÚ“®‚É–ß‚·
        if (!player.IsRunning)
        {
            player.ChangeState(new PlayerMoveState(player));
            return;
        }

        player.MoveCharacter(moveDir, runSpeed);
    }

    public override void Exit()
    {
        player.PlayerMotionScript.runMotion(false);
        player.PlayerEffectScript.StopEffect((int)playerEffectScript.EffectName.SMOKE);
        player.SeBox.StopPlayerSE();
    }

}
