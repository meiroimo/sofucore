using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus_Script : MonoBehaviour
{
    [Header("ステータス"),Tooltip("最大体力")] public float player_MaxHealth = 500;
    [Tooltip("スタミナ")] public float player_MaxSutamina = 500;
    [Tooltip("攻撃力")] public float player_Attack_Power = 10;
    [Tooltip("防御力")] public float player_Defense = 10;
    [Tooltip("移動速度")] public float player_Speed = 5;
    [Tooltip("会心率"), Range(0, 100)] public float player_Critical = 0;
    [Tooltip("会心ダメ率")] public float player_Critical_Damage = 150;


    [Header("初期ステータス"), Tooltip("初期最大体力")] public float D_player_MaxHealth;
    [Tooltip("初期スタミナ")] public float D_player_MaxSutamina;
    [Tooltip("初期攻撃力")] public float D_player_Attack_Power;
    [Tooltip("初期防御力")] public float D_player_Defense;
    [Tooltip("初期移動速度")] public float D_player_Speed;
    [Tooltip("初期会心率"), Range(0, 100)] public float D_player_Critical;
    [Tooltip("初期会心ダメ率")] public float D_player_Critical_Damage;

    [Header("追加ステータス"), Tooltip("追加最大体力")] public float add_Player_MaxHealth = 0;
    [Tooltip("追加スタミナ")] public float add_Player_MaxSutamina = 0;
    [Tooltip("追加攻撃力")] public float add_Player_Attack_Power = 0;
    [Tooltip("追加防御力")] public float add_Player_Defense = 0;
    [Tooltip("追加移動速度")] public float add_Player_Speed = 0;
    [Tooltip("追加会心率"), Range(0, 100)] public float add_Player_Critical = 0;
    [Tooltip("追加会心ダメ率")] public float add_Player_Critical_Damage = 0;

    [HideInInspector] public int enemyDeathCount;//倒したモンスターの数を保持

    [SerializeField]CSVReader statusLoad;
    void Start()
    {

        statusLoad.LoadingPlayerStatus();

        enemyDeathCount = 0;
    }

    void Update()
    {
        StatusUp();
    }
    // ステータスアップの反映
    void StatusUp()
    {
        player_MaxHealth = D_player_MaxHealth + add_Player_MaxHealth;
        player_Defense = D_player_Defense + add_Player_Defense;
        player_Attack_Power = D_player_Attack_Power + add_Player_Attack_Power;
        player_Speed = D_player_Speed + (add_Player_Speed * 0.01f * D_player_Speed);
        player_Critical = D_player_Critical + add_Player_Critical;
        player_Critical_Damage = D_player_Critical_Damage + add_Player_Critical_Damage;
        player_MaxSutamina = D_player_MaxSutamina + add_Player_MaxSutamina;
      
    }
}
