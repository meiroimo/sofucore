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

        // “ü—Í‚É‰ž‚¶‚Ä—Í‚ð‰Á‚¦‚é
        Vector3 force = new Vector3(input.x, 0, input.y) * player.moveForce;

        // ’n–Ê‚Æ‚Ì–€ŽC‚ð”ð‚¯‚é‚½‚ß YŽ²‚Ì‘¬“x‚ð•Û‚¿‚Â‚Â•ûŒü‚¾‚¯•Ï‚¦‚éi”CˆÓj
        //Vector3 currentVelocity = player.Rigid.velocity;
        //Vector3 targetVelocity = new Vector3(force.x, currentVelocity.y, force.z);
        //player.Rigid.velocity = Vector3.Lerp(currentVelocity, targetVelocity, 0.1f);

        Vector3 moveDirection = new Vector3(input.x, 0, input.y); // Z•ûŒüˆÚ“®
        player.Rigid.velocity = moveDirection * player.moveForce + new Vector3(0, player.Rigid.velocity.y, 0); // Y‚Íd—Í‚É”C‚¹‚é

        player.RotateTowards(moveDirection); // © Œü‚«‚ð•ÏX

    }

    public override void Exit()
    {
        Debug.Log("Exited Move State");
    }
}
