using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

/// <summary>
/// çUåÇÇRíiäKñ⁄
/// </summary>
public class AttackThreeState : PlayerState
{
    private float timer = 0f;

    public AttackThreeState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        player.PlayerMotionScript.attackMotion(true);

        player.PlayerEffectScript.PlayEffect((int)playerEffectScript.EffectName.SLASH);
        player.IsAttack = true;
        player.PlayerLAttack();
        player.FixedAttackDirection = player.transform.forward; // çUåÇéûÇÃå¸Ç´Çï€ë∂
    }

    public override void Update()
    {
        timer += Time.deltaTime;
        Vector2 input = player.MoveInput;
        Vector3 moveDirection = new Vector3(input.x, 0, input.y); // Zï˚å¸à⁄ìÆ
        player.MoveCharacter(moveDirection, player.CurrentMoveSpeed);


        // ÉRÉìÉ{èIóπÇ≈ Idle Ç…ñﬂÇÈ
        if (timer >= player.ComboInputWindow)
        {
            player.ChangeState(new PlayerMoveState(player));
        }
    }

    public override void Exit()
    {
        player.IsAttack = false;
        player.PlayerMotionScript.attackMotion(false);
        player.PlayerEffectScript.StopEffect((int)playerEffectScript.EffectName.SLASH);

    }
}
