using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus_Script : MonoBehaviour
{
    [Header("ステータス"),
     Tooltip("最大体力")]                public float player_MaxHealth;
    [Tooltip("スタミナ")]                public float player_MaxSutamina;
    [Tooltip("スタミナ回復速度(毎秒)")]  public float player_stamina_recovery_speed;
    [Tooltip("攻撃力")]                  public float player_Attack_Power;
    [Tooltip("スキルポイント")]          public float player_Skill_Point;
    [Tooltip("スキルチャージ(毎秒)")]    public float player_Skill_Charge;
    [Tooltip("攻撃範囲")]                public float player_Attack_Range;
    //使ってない
   
    [Header("初期ステータス"), 
     Tooltip("初期最大体力")]                public float default_player_MaxHealth;
    [Tooltip("初期スタミナ")]                public float default_player_MaxSutamina;
    [Tooltip("初期スタミナ回復速度(毎秒)")]  public float default_player_stamina_recovery_speed;

    [Tooltip("初期攻撃力")]                  public float default_player_Attack_Power;
    [Tooltip("初期スキルポイント")]          public float default_player_Skill_Point;
    [Tooltip("初期スキルチャージ(毎秒)")]    public float default_player_Skill_Charge;
    [Tooltip("初期攻撃範囲")]                public float default_player_Attack_Range;
    //使ってない
    [Header("追加ステータス"), 
     Tooltip("追加最大体力")]                public float add_Player_MaxHealth = 0;
    [Tooltip("追加スタミナ")]                public float add_Player_MaxSutamina = 0;
    [Tooltip("追加スタミナ回復速度(毎秒)")]  public float add_player_stamina_recovery_speed=0;

    [Tooltip("追加攻撃力")]                  public float add_Player_Attack_Power = 0;
    [Tooltip("追加スキルポイント")]          public float add_Player_Skill_Point = 0;
    [Tooltip("追加スキルチャージ(毎秒)")]    public float add_Player_Skill_Charge = 0;
    [Tooltip("追加攻撃範囲")]                public float add_player_Attack_Range = 0;

    //使ってない
    [HideInInspector] public int enemyDeathCount;//倒したモンスターの数を保持

    [SerializeField]CSVReader statusLoad;
    void Start()
    {

    }

    public void Init()
    {
        statusLoad.LoadingPlayerStatus();
        enemyDeathCount = 0;
        StatusUp();
    }

    void Update()
    {
       // StatusUp();
    }
    // ステータスアップの反映
  public   void StatusUp()
    {
        player_MaxHealth                = default_player_MaxHealth              + add_Player_MaxHealth;
        player_Attack_Power             = default_player_Attack_Power           + add_Player_Attack_Power;
        player_stamina_recovery_speed   = default_player_stamina_recovery_speed + add_player_stamina_recovery_speed;
        player_MaxSutamina              = default_player_MaxSutamina            + add_Player_MaxSutamina;
        player_Skill_Point              = default_player_Skill_Point            + add_Player_Skill_Point;
        player_Skill_Charge             = default_player_Skill_Charge           + add_Player_Skill_Charge;
        player_Attack_Range             = default_player_Attack_Range           + add_player_Attack_Range;
        //使ってない
      
    }
}
