using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerState
{
    private float runSpeed;
    private float staminaInterval = 1.0f;//‰½•b‚²‚Æ‚ÉÁ”ï‚·‚é‚©
    private float staminaCost = 100f;//1‰ñ‚ÌÁ”ï—Ê
    private float timer;

    public PlayerRunState(PlayerController player) : base(player) 
    {
        runSpeed = player.moveForce * 2.0f;
        player.CurrentMoveSpeed = runSpeed;
    }

    public override void Enter()
    {
        if (!player.TakeAvoid(staminaCost))
        {
            player.ChangeState(new PlayerMoveState(player));
            return;
        }
        player.CurrentMoveSpeed = runSpeed;
        timer = 0f;

        player.PlayerMotionScript.runMotion(true);
        player.PlayerEffectScript.PlayEffect((int)playerEffectScript.EffectName.SMOKE);
        player.SeBox.PlayPlayerSE(PlayerSEBox.SENAME.MOVE);
    }

    public override void Update()
    {
        if (player.IsAvoid) return;
        Vector2 moveInput = player.MoveInput;
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);

        //if (Time.time > nextStaminaDecreaseTime)
        //{
        //    nextStaminaDecreaseTime = Time.time + staminaDecrease;
        //    if (!player.TakeAvoid(100))
        //    {
        //        player.ChangeState(new PlayerMoveState(player));
        //        return;
        //    }
        //}

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

        timer += Time.deltaTime;
        if (timer >= staminaInterval)
        {
            timer = 0f;
            if (!player.TakeAvoid(staminaCost))
            {
                player.ChangeState(new PlayerMoveState(player));
                return;
            }
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
