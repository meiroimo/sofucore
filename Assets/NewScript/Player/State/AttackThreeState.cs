using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class AttackThreeState : PlayerState
{
    private float timer = 0f;

    public AttackThreeState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        Debug.Log("攻撃：三段階目！");
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


        // コンボ終了で Idle に戻る
        if (timer >= player.ComboInputWindow)
        {
            player.ChangeState(new PlayerMoveState(player));
        }
    }

    public override void Exit()
    {
        player.IsAttack = false;
    }
}
