using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusCache : MonoBehaviour
{
    public static float lastattackPower;
    public static float lastmaxHealth;
    public static float lastcurrentHealth;
    public static float lastMaxSutamina;
    public static float lastAttack_Range;
    public static float lastSkill_Charge;
    public static float lastspeed;

    public static void LastStatusSave(PlayerStatus_Script playerStatus)
    {
        lastattackPower = playerStatus.player_Attack_Power;
        lastmaxHealth = playerStatus.player_MaxHealth;
        lastspeed = playerStatus.player_Speed;
        lastMaxSutamina = playerStatus.player_MaxSutamina;
        lastAttack_Range = playerStatus.player_Attack_Range;
        lastSkill_Charge = playerStatus.player_Skill_Charge;
    }
}
