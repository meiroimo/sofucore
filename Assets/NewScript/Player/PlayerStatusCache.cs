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
    public static float lastAvoidance_Distance;
    public static float lastSkill_Power_Multiplier;
    public static float lastspeed;
    public static float enemy_Defats;//ì|ÇµÇΩêî
    public static float catchSofviCount;

    public static void LastStatusSave(PlayerStatus_Script playerStatus)
    {
        lastattackPower = playerStatus.player_Attack_Power;
        lastmaxHealth = playerStatus.player_MaxHealth;
        lastspeed =100;
        lastMaxSutamina = playerStatus.player_MaxSutamina;
        lastAttack_Range = playerStatus.player_Attack_Range;
        lastSkill_Charge = playerStatus.player_Skill_Charge;
        lastAvoidance_Distance = playerStatus.player_Avoidance_Distance;
        lastSkill_Power_Multiplier = playerStatus.player_Skill_Power_Multiplier;
    }

    public static void SaveDefats(int defats = 1)
    {
        enemy_Defats += defats;
    }

    public static void SaveCatchSofviCount()
    {
        catchSofviCount++;
    }
}
