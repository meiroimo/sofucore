using UnityEngine;

/// <summary>
/// ƒvƒŒƒCƒ„[‚ÌˆÚ“®ó‘Ô
/// </summary>
public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(PlayerController player) : base(player) { }

    public override void Enter()
    {

    }

    public override void Update()
    {
        Vector2 input = player.MoveInput;

        if (input.magnitude < 0.1f)
        {
            player.ChangeState(new PlayerIdleState(player));
            return;
        }

        Vector3 moveDirection = new Vector3(input.x, 0, input.y); // Z•ûŒüˆÚ“®
        player.MoveCharacter(moveDirection, player.moveForce);
    }

    public override void Exit()
    {

    }
}
