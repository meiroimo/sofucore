using UnityEngine;

/// <summary>
/// �v���C���[�̗������
/// </summary>
public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerController player) : base(player) { }

    public override void Enter()
    {

    }

    public override void Update()
    {
        //magnitude:�x�N�g���̒���
        if (player.MoveInput.magnitude > 0.1f)
        {
            player.ChangeState(new PlayerMoveState(player));
        }
        // ����h�~�FXZ���������S�Ɏ~�߂�
        Vector3 stopped = player.Rigid.velocity;
        stopped.x = 0;
        stopped.z = 0;
        player.Rigid.velocity = stopped;

    }

    public override void Exit()
    {

    }
}
