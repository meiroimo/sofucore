using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

/// <summary>
/// �v���C���[�̉�����
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

        // ���͕������Ȃ���Ό����Ă�������ɉ��
        dodgeDirection = player.transform.forward;

        timer = 0f;

        player.TakeAvoid(30);
        // ���G���ON�i�K�v�Ȃ�j
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
