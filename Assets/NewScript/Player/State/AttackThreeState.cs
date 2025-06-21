using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

/// <summary>
/// UŒ‚‚R’iŠK–Ú
/// </summary>
public class AttackThreeState : PlayerState
{
    private float timer = 0f;

    public AttackThreeState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        Debug.Log("UŒ‚FO’iŠK–ÚI");
        player.IsAttack = true;
        player.PlayerLAttack();
        player.FixedAttackDirection = player.transform.forward; // UŒ‚‚ÌŒü‚«‚ğ•Û‘¶
    }

    public override void Update()
    {
        timer += Time.deltaTime;
        Vector2 input = player.MoveInput;
        Vector3 moveDirection = new Vector3(input.x, 0, input.y); // Z•ûŒüˆÚ“®
        player.MoveCharacter(moveDirection, player.moveForce);


        // ƒRƒ“ƒ{I—¹‚Å Idle ‚É–ß‚é
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
