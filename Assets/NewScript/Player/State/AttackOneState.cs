using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Windows;

/// <summary>
/// �U���P�i�K��
/// </summary>
public class AttackOneState : PlayerState
{
    private float timer = 0f;

    public AttackOneState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        Debug.Log("�U���F��i�K�ځI");
        player.ReceivedNextAttack = false;
        player.IsAttack = true;
        player.PlayerLAttack(); // �U������
        player.FixedAttackDirection = player.transform.forward; // �U�����̌�����ۑ�

    }

    public override void Update()
    {
        timer += Time.deltaTime;
        Vector2 input = player.MoveInput;
        Vector3 moveDirection = new Vector3(input.x, 0, input.y); // Z�����ړ�
        player.MoveCharacter(moveDirection, player.moveForce);


        if (timer >= player.ComboInputWindow)
        {
            // �P�\���ԏI�� �� Move��
            player.ChangeState(new PlayerMoveState(player));
        }
        else if (player.ReceivedNextAttack)
        {
            // ���̍U�������͂��ꂽ��Attack2��
            player.ChangeState(new AttackTwoState(player));
        }

    }

    public override void Exit()
    {
        player.IsAttack = false;
    }
}
