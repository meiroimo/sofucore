using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        //Debug.Log("Entered Move State");
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
        //Vector3 force = new Vector3(input.x, 0, input.y) * player.moveForce;

        Vector3 moveDirection = new Vector3(input.x, 0, input.y); // Z�����ړ�
        player.MoveCharacter(moveDirection, player.moveForce);
    }

    public override void Exit()
    {
        //Debug.Log("Exited Move State");
    }
}
