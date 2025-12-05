using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus_Script : MonoBehaviour
{
    [Header("ステータス"), Tooltip("最大体力")] public float enemy_MaxHealth;
    [Tooltip("攻撃力")] public float enemy_Attack_Power;
    [Tooltip("防御力")] public float enemy_Defense;
    [Tooltip("移動速度")] public float enemy_Speed;
}
