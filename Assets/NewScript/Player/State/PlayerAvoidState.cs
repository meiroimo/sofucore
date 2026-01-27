using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

/// <summary>
/// プレイヤーの回避状態
/// </summary>
public class PlayerAvoidState : PlayerState
{
    private Vector3 dodgeDirection;
    private float dodgeSpeed = 5f;
    private float dodgeDuration = 0.5f;
    private float timer = 0f;

    public PlayerAvoidState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        if (!player.TakeAvoid(300))
        {
            player.ChangeState(new PlayerIdleState(player));
            Debug.LogWarning("スタミナが足りない！");
            return;
        }

        player.IsAvoid = true;
        player.PlayerEffectScript.PlayEffect((int)playerEffectScript.EffectName.AVOIDANCE);
       // player.PlayerMotionScript.TrueBack();
        //入力方向がなければ向いている方向に回避
        Vector2 moveInput = player.MoveInput; // ← 例：新Input Systemでの移動入力
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y).normalized;

        if(moveDir.x > 0)//右
        {
            player.PlayerMotionScript.TrueFront();
            player.transform.eulerAngles = new Vector3(0, 90, 0);
            Debug.Log("右");
        }
        else if(0 > moveDir.x)
        {
            player.PlayerMotionScript.TrueFront();
            player.transform.eulerAngles = new Vector3(0, -90, 0);
        }
        else if(moveDir.z > 0 && moveDir.x == 0)
        {
            player.PlayerMotionScript.TrueFront();
        }
        else if(moveDir.z < 0 && moveDir.x == 0)
        {
            player.PlayerMotionScript.TrueBack();
        }


        //x:-1　左　x:1　右　y:1　前　y:-1　後ろ
        Debug.Log("値" + moveDir);

        //入力があればその方向、なければ前方
        //sqrMagnitude:平方根らしい
        if (moveDir.sqrMagnitude > 0.01f)
        {
            dodgeDirection = moveDir;
        }
        else
        {
            dodgeDirection = player.transform.forward;
            player.PlayerMotionScript.TrueFront();
        }
        player.SeBox.PlayPlayerSE(PlayerSEBox.SENAME.AVOID);
        timer = 0f;

    }

    public override void Update()
    {
        timer += Time.deltaTime;

        float moveSpeed = player.player_Avoidance_Distance / dodgeDuration;
        Debug.LogWarning(player.player_Avoidance_Distance);
        player.MoveInstant(dodgeDirection * moveSpeed);

        if (timer >= dodgeDuration)
        {
            player.ChangeState(new PlayerIdleState(player));
        }
    }

    public override void Exit() {
        player.PlayerEffectScript.StopEffect((int)playerEffectScript.EffectName.AVOIDANCE);
        player.IsAvoid = false;
    }
}
