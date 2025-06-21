using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

/// <summary>
/// �U���R�i�K��
/// </summary>
public class AttackThreeState : PlayerState
{
    private float timer = 0f;

    public AttackThreeState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        Debug.Log("�U���F�O�i�K�ځI");
        player.IsAttack = true;
        player.PlayerLAttack();
        player.FixedAttackDirection = player.transform.forward; // �U�����̌�����ۑ�
    }

    public override void Update()
    {
        timer += Time.deltaTime;
        Vector2 input = player.MoveInput;
        Vector3 moveDirection = new Vector3(input.x, 0, input.y); // Z�����ړ�
        player.MoveCharacter(moveDirection, player.moveForce);


        // �R���{�I���� Idle �ɖ߂�
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
