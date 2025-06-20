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
        Debug.Log("攻撃：二段階目！");  
        player.ReceivedNextAttack = false;
        player.IsAttack = true;
        player.PlayerLAttack();
        player.FixedAttackDirection = player.transform.forward; // 攻撃時の向きを保存

    }

    public override void Update()
    {
        timer += Time.deltaTime;
        Vector2 input = player.MoveInput;
        Vector3 moveDirection = new Vector3(input.x, 0, input.y); // Z方向移動
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
