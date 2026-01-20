using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

/// <summary>
/// çUåÇÇÃÇQíiäKñ⁄
/// </summary>
public class AttackTwoState : PlayerState
{
    private float timer = 0f;

    public AttackTwoState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        if (player.IsAvoid) player.ChangeState(new PlayerAvoidState(player));

        player.PlayerMotionScript.attackMotion();
        player.PlayerEffectScript.PlayEffect((int)playerEffectScript.EffectName.SLASH);
        player.ReceivedNextAttack = false;
        player.IsAttack = true;
        player.PlayerLAttack();
        player.FixedAttackDirection = player.transform.forward; // çUåÇéûÇÃå¸Ç´Çï€ë∂

    }

    public override void Update()
    {
        timer += Time.deltaTime;
        Vector2 input = player.MoveInput;
        Vector3 moveDirection = new Vector3(input.x, 0, input.y); // Zï˚å¸à⁄ìÆ
        player.MoveCharacter(moveDirection, player.CurrentMoveSpeed);


        if (timer >= player.ComboInputWindow)
        {
            player.ChangeState(new PlayerMoveState(player));
        }
        else if (player.ReceivedNextAttack)
        {
            player.ChangeState(new AttackThreeState(player));
        }
    }

    public override void Exit()
    {
        player.IsAttack = false;
        player.PlayerMotionScript.idleMotion();

        player.PlayerEffectScript.StopEffect((int)playerEffectScript.EffectName.SLASH);


    }
}
