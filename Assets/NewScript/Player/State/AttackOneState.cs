using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Windows;

public class AttackOneState : PlayerState
{
    private float timer = 0f;

    public AttackOneState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        Debug.Log("UFêiKÚI");
        player.ReceivedNextAttack = false;
        player.IsAttack = true;
        player.PlayerLAttack(); // U
        player.FixedAttackDirection = player.transform.forward; // UÌü«ðÛ¶

    }

    public override void Update()
    {
        timer += Time.deltaTime;
        Vector2 input = player.MoveInput;
        Vector3 moveDirection = new Vector3(input.x, 0, input.y); // ZûüÚ®
        player.MoveCharacter(moveDirection, player.moveForce);


        if (timer >= player.ComboInputWindow)
        {
            // P\ÔI¹ ¨ MoveÖ
            player.ChangeState(new PlayerMoveState(player));
        }
        else if (player.ReceivedNextAttack)
        {
            // ÌUªüÍ³ê½çAttack2Ö
            player.ChangeState(new AttackTwoState(player));
        }

    }

    public override void Exit()
    {
        player.IsAttack = false;
    }
}
