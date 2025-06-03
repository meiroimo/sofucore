using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus_Script : MonoBehaviour
{
    [Header("�X�e�[�^�X"),Tooltip("�ő�̗�")] public float player_MaxHealth = 500;
    [Tooltip("�X�^�~�i")] public float player_MaxSutamina = 500;
    [Tooltip("�U����")] public float player_Attack_Power = 10;
    [Tooltip("�h���")] public float player_Defense = 10;
    [Tooltip("�ړ����x")] public float player_Speed = 5;
    [Tooltip("��S��"), Range(0, 100)] public float player_Critical = 0;
    [Tooltip("��S�_����")] public float player_Critical_Damage = 150;


    [Header("�����X�e�[�^�X"), Tooltip("�����ő�̗�")] public float D_player_MaxHealth;
    [Tooltip("�����X�^�~�i")] public float D_player_MaxSutamina;
    [Tooltip("�����U����")] public float D_player_Attack_Power;
    [Tooltip("�����h���")] public float D_player_Defense;
    [Tooltip("�����ړ����x")] public float D_player_Speed;
    [Tooltip("������S��"), Range(0, 100)] public float D_player_Critical;
    [Tooltip("������S�_����")] public float D_player_Critical_Damage;

    [Header("�ǉ��X�e�[�^�X"), Tooltip("�ǉ��ő�̗�")] public float add_Player_MaxHealth = 0;
    [Tooltip("�ǉ��X�^�~�i")] public float add_Player_MaxSutamina = 0;
    [Tooltip("�ǉ��U����")] public float add_Player_Attack_Power = 0;
    [Tooltip("�ǉ��h���")] public float add_Player_Defense = 0;
    [Tooltip("�ǉ��ړ����x")] public float add_Player_Speed = 0;
    [Tooltip("�ǉ���S��"), Range(0, 100)] public float add_Player_Critical = 0;
    [Tooltip("�ǉ���S�_����")] public float add_Player_Critical_Damage = 0;

    [HideInInspector] public int enemyDeathCount;//�|���������X�^�[�̐���ێ�

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
    // �X�e�[�^�X�A�b�v�̔��f
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
