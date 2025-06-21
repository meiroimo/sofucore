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

        // 入力方向がなければ向いている方向に回避
        dodgeDirection = player.transform.forward;

        timer = 0f;

        player.TakeAvoid(30);
        // 無敵状態ON（必要なら）
        //player.SetInvincible(true);
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

    public override void Exit() { }
}
