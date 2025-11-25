using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

/// <summary>
/// プレイヤーの回避状態
/// </summary>
public class PlayerAvoidState : PlayerState
{
    private Vector3 dodgeDirection;
    private float dodgeSpeed = 15f;
    private float dodgeDuration = 0.3f;
    private float timer = 0f;

    public PlayerAvoidState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        if (!player.TakeAvoid(30))
        {
            player.ChangeState(new PlayerIdleState(player));
            return;
        }

            player.PlayerEffectScript.PlayEffect((int)playerEffectScript.EffectName.AVOIDANCE);
        player.PlayerMotionScript.avoidanceMotion(true);

        //入力方向がなければ向いている方向に回避
        Vector2 moveInput = player.MoveInput; // ← 例：新Input Systemでの移動入力
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y).normalized;

        //入力があればその方向、なければ前方
        //sqrMagnitude:平方根らしい
        if (moveDir.sqrMagnitude > 0.01f)
        {
            dodgeDirection = moveDir;
        }
        else
        {
            dodgeDirection = player.transform.forward;
        }
        player.SeBox.PlayPlayerSE(PlayerSEBox.SENAME.AVOID);
        timer = 0f;
    }

    public override void Update()
    {
        timer += Time.deltaTime;
        player.MoveInstant(dodgeDirection * dodgeSpeed);

        if (timer < dodgeDuration)
        {
            player.MoveInDirection(dodgeDirection, dodgeSpeed);
        }
        else
        {
            player.ChangeState(new PlayerIdleState(player)); 
        }
    }

    public override void Exit() {
        player.PlayerEffectScript.StopEffect((int)playerEffectScript.EffectName.AVOIDANCE);
        player.PlayerMotionScript.avoidanceMotion(false);
    }
}
