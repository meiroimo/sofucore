using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus_Script : MonoBehaviour
{
    [Header("ステータス"), Tooltip("最大体力")] public float enemy_MaxHealth = 20;
    [Tooltip("攻撃力")] public float enemy_Attack_Power = 10;
    [Tooltip("防御力")] public float enemy_Defense = 10;
    [Tooltip("移動速度")] public float enemy_Speed = 5;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
