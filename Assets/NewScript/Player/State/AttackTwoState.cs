using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class AttackTwoState : PlayerState
{
    private float timer = 0f;

    public AttackTwoState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        Debug.Log("UŒ‚F“ñ’iŠK–ÚI");  
        player.ReceivedNextAttack = false;
        player.IsAttack = true;
        player.PlayerLAttack();
        player.FixedAttackDirection = player.transform.forward; // UŒ‚Žž‚ÌŒü‚«‚ð•Û‘¶

    }

    public override void Update()
    {
        timer += Time.deltaTime;
        Vector2 input = player.MoveInput;
        Vector3 moveDirection = new Vector3(input.x, 0, input.y); // Z•ûŒüˆÚ“®
        player.MoveCharacter(moveDirection, player.moveForce);


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
    }
}
