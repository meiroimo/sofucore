using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        Debug.Log("Entered Move State");
    }

    public override void Update()
    {
        Vector2 input = player.MoveInput;

        if (input.magnitude < 0.1f)
        {
            player.ChangeState(new PlayerIdleState(player));
            return;
        }

        // ���͂ɉ����ė͂�������
        Vector3 force = new Vector3(input.x, 0, input.y) * player.moveForce;

        // �n�ʂƂ̖��C������邽�� Y���̑��x��ۂ����������ς���i�C�Ӂj
        //Vector3 currentVelocity = player.Rigid.velocity;
        //Vector3 targetVelocity = new Vector3(force.x, currentVelocity.y, force.z);
        //player.Rigid.velocity = Vector3.Lerp(currentVelocity, targetVelocity, 0.1f);

        Vector3 moveDirection = new Vector3(input.x, 0, input.y); // Z�����ړ�
        player.Rigid.velocity = moveDirection * player.moveForce + new Vector3(0, player.Rigid.velocity.y, 0); // Y�͏d�͂ɔC����

        player.RotateTowards(moveDirection); // �� ������ύX

    }

    public override void Exit()
    {
        Debug.Log("Exited Move State");
    }
}
