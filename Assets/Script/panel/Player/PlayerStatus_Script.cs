using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus_Script : MonoBehaviour
{
    [Header("ステータス"),
     Tooltip("最大体力")]                public float player_MaxHealth;
    [Tooltip("スタミナ")]                public float player_MaxSutamina;
    [Tooltip("攻撃力")]                  public float player_Attack_Power;
    [Tooltip("スキルポイント")]          public float player_Skill_Point;
    [Tooltip("スキルチャージ(毎秒)")]          public float player_Skill_Charge;
    //使ってない
    [Tooltip("移動速度")] public float player_Speed;
    [Tooltip("会心率"), Range(0, 100)] public float player_Critical;
    [Tooltip("会心ダメ率")] public float player_Critical_Damage;
    [Tooltip("防御力")] public float player_Defense;
    [Tooltip("サイズ")] public float player_Size;
    [Tooltip("攻撃範囲")] public float player_Attack_Range;



    [Header("初期ステータス"), 
     Tooltip("初期最大体力")]                public float default_player_MaxHealth;
    [Tooltip("初期スタミナ")]                public float default_player_MaxSutamina;
    [Tooltip("初期攻撃力")]                  public float default_player_Attack_Power;
    [Tooltip("初期スキルポイント")]          public float default_player_Skill_Point;
    [Tooltip("初期スキルチャージ(毎秒)")]          public float default_player_Skill_Charge;
    //使ってない
    [Tooltip("初期移動速度")] public float default_player_Speed;
    [Tooltip("初期防御力")] public float D_player_Defense;
    [Tooltip("初期会心率"), Range(0, 100)] public float D_player_Critical;
    [Tooltip("初期会心ダメ率")] public float D_player_Critical_Damage;
    [Tooltip("初期サイズ")] public float default_player_Size;
    [Tooltip("初期攻撃範囲")] public float default_player_Attack_Range;



    [Header("追加ステータス"), 
     Tooltip("追加最大体力")]                public float add_Player_MaxHealth = 0;
    [Tooltip("追加スタミナ")]                public float add_Player_MaxSutamina = 0;
    [Tooltip("追加攻撃力")]                  public float add_Player_Attack_Power = 0;
    [Tooltip("追加スキルポイント")]          public float add_Player_Skill_Point = 0;
    [Tooltip("追加スキルチャージ(毎秒)")]          public float add_Player_Skill_Charge = 0;
    //使ってない
    [Tooltip("追加移動速度")] public float add_Player_Speed = 0;
    [Tooltip("追加防御力")] public float add_Player_Defense = 0;
    [Tooltip("追加会心率"), Range(0, 100)] public float add_Player_Critical = 0;
    [Tooltip("追加会心ダメ率")] public float add_Player_Critical_Damage = 0;
    [Tooltip("追加サイズ")] public float add_Player_Size = 0;
    [Tooltip("追加攻撃範囲")] public float add_Player_Attack_Range = 0;


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
        StatusUp();
    }
    // ステータスアップの反映
    void StatusUp()
    {
        player_MaxHealth       = default_player_MaxHealth       + add_Player_MaxHealth;
        player_Attack_Power    = default_player_Attack_Power    + add_Player_Attack_Power;
        player_MaxSutamina     = default_player_MaxSutamina     + add_Player_MaxSutamina;
        player_Skill_Point     = default_player_Skill_Point     + add_Player_Skill_Point;
        player_Skill_Charge    = default_player_Skill_Charge    + add_Player_Skill_Charge;
        //使ってない
        player_Size = default_player_Size + add_Player_Size;
        player_Attack_Range = default_player_Attack_Range + add_Player_Attack_Range;
        player_Speed = default_player_Speed + (add_Player_Speed * 0.01f * default_player_Speed);
        player_Defense = D_player_Defense + add_Player_Defense;
        player_Critical = D_player_Critical + add_Player_Critical;
        player_Critical_Damage = D_player_Critical_Damage + add_Player_Critical_Damage;


    }
}
