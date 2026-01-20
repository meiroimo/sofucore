using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus_Script : MonoBehaviour
{
    [Header("ステータス"),
     Tooltip("最大体力")]                public float player_MaxHealth;
    [Tooltip("攻撃力")]                  public float player_Attack_Power;

    //追加したステータス
    [Tooltip("攻撃範囲")]                public float player_Attack_Range;
    [Tooltip("回避距離")]                public float player_Avoidance_Distance;
    [Tooltip("スキル威力倍率")]          public float player_Skill_Power_Multiplier;
    //使ってないステータス
    [Tooltip("スタミナ")] public float player_MaxSutamina;
    [Tooltip("スタミナ回復速度(毎秒)")] public float player_stamina_recovery_speed;
    [Tooltip("スキルチャージ(毎秒)")] public float player_Skill_Charge;
    [Tooltip("スキルポイント")] public float player_Skill_Point;


    //初期値
    [Header("初期ステータス"), 
     Tooltip("初期最大体力")]                public float default_player_MaxHealth;
    [Tooltip("初期攻撃力")]                  public float default_player_Attack_Power;
    //追加した
    [Tooltip("初期攻撃範囲")]                public float default_player_Attack_Range;
    [Tooltip("初期回避距離")]                public float default_player_Avoidance_Distance;
    [Tooltip("初期スキル威力倍率")]          public float default_player_Skill_Power_Multiplier;
    //使ってないステータス
    [Tooltip("初期スキルポイント")] public float default_player_Skill_Point;
    [Tooltip("初期スキルチャージ(毎秒)")] public float default_player_Skill_Charge;
    [Tooltip("初期スタミナ")] public float default_player_MaxSutamina;
    [Tooltip("初期スタミナ回復速度(毎秒)")] public float default_player_stamina_recovery_speed;



    //追加値

    [Header("追加ステータス"), 
     Tooltip("追加最大体力")]                public float add_Player_MaxHealth = 0;
    [Tooltip("追加攻撃力")] public float add_Player_Attack_Power = 0;
    //使ってないステータス
    [Tooltip("追加スタミナ")] public float add_Player_MaxSutamina = 0;
    [Tooltip("追加スタミナ回復速度(毎秒)")] public float add_player_stamina_recovery_speed = 0;
    [Tooltip("追加スキルポイント")] public float add_Player_Skill_Point = 0;
    [Tooltip("追加スキルチャージ(毎秒)")] public float add_Player_Skill_Charge = 0;

    //追加したステータス
    [Tooltip("追加攻撃範囲")]                public float add_player_Attack_Range = 0;
    [Tooltip("追加回避距離")]                public float add_player_Avoidance_Distance = 0;
    [Tooltip("追加スキル威力倍率")]          public float add_player_Skill_Power_Multiplier = 0;


    //デバック用
    [Tooltip("debug用テキストオブジェ")] public Text debugText;


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
        debugText.text = "追加ステータスの確認\r\n攻撃範囲"+ (player_Attack_Range/100)*4.16 /*player_Attack_Range*/ + "　\r\nスキル威力"+ player_Skill_Power_Multiplier + "\r\n回避距離"+ player_Avoidance_Distance;
    }
    // ステータスアップの反映
  public   void StatusUp()
    {
        player_MaxHealth                = default_player_MaxHealth              + add_Player_MaxHealth;
        player_Attack_Power             = default_player_Attack_Power           + add_Player_Attack_Power;
        //追加したステータス
        player_Attack_Range             = default_player_Attack_Range           + add_player_Attack_Range;
        player_Avoidance_Distance       = default_player_Avoidance_Distance     + add_player_Avoidance_Distance;
        player_Skill_Power_Multiplier   = default_player_Skill_Power_Multiplier + (add_player_Skill_Power_Multiplier*0.01f);
        //使ってない
        player_stamina_recovery_speed = default_player_stamina_recovery_speed + add_player_stamina_recovery_speed;
        player_MaxSutamina = default_player_MaxSutamina + add_Player_MaxSutamina;
        player_Skill_Point = default_player_Skill_Point + add_Player_Skill_Point;
        player_Skill_Charge = default_player_Skill_Charge + add_Player_Skill_Charge;

    }
}
