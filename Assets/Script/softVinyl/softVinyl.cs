using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class softVinyl : MonoBehaviour
{
       [Header("���O")] public  Name  sofviName;//���̃\�t�r�̉摜

    [Header("�摜")] public Sprite sofviImage;//���̃\�t�r�̉摜
    [Header("�e�[�}")] public themeNu�� theme;//���̃\�t�r�̃e�[�}
    [Header("�X�L��")] public SKILLNUM skill;//���̃\�t�r�̃X�L��
    [Header("�R�X�g")] public int  cost;//���̃\�t�r�̃R�X�g
    [Header("�i���o�[")] public int�@ListNumber;//���̃\�t�r�̔ԍ�
                      

    [Header("�o�t���C���X�e�[�^�X")] public BUFFSTATUSNUM buffMainstatus;//���C���X�e
    [Header("�o�t�T�u�X�e�[�^�X�P")] public BUFFSTATUSNUM buffSubstatus1;//�T�u�X�e�P
    [Header("�o�t�T�u�X�e�[�^�X�Q")] public BUFFSTATUSNUM buffSubstatus2;//�T�u�X�e�Q
    [Header("�o�t�T�u�X�e�[�^�X�R")] public BUFFSTATUSNUM buffSubstatus3;//�T�u�X�e�R

    [Header("�o�t���C���X�e�[�^�X�p�����[�^�[")] public int Buffparameter;//���C���X�e
    [Header("�o�t�T�u�X�e�[�^�X�p�����[�^�[�P")] public int Buffparameter1;//�T�u�X�e�P
    [Header("�o�t�T�u�X�e�[�^�X�p�����[�^�[�Q")] public int Buffparameter2;//�T�u�X�e�Q
    [Header("�o�t�T�u�X�e�[�^�X�p�����[�^�[�R")] public int Buffparameter3;//�T�u�X�e�R

    [Header("���C�����O")] public new string buffName;�@ //���C���X�e���O
    [Header("�T�u�P���O")] public  string buffName1;�@�@//�T�u���O�P
    [Header("�T�u�Q���O")] public string buffName2;�@�@//�T�u���O�Q
    [Header("�T�u�R���O")] public  string buffName3;�@//�T�u���O�R

    public bool selectCheck;
    public GameObject selectButton;//�Z���N�g���̃{�^��
                                   //�����b�r�u�ŊǗ��ł����炢����



    public enum Name
    {
        NULL = 0,
        NAME1,
        NAME2,
        NAME3,
        NAME4,
        NAME5,
        NAME6,
        NAME7,
        NAME8,
        NAME9,
        NAME10,
        NAME11,
        NAME12,
        NAME13,
        NAME14,
        NAME15,
        NAME16,
        NAME17,
        NAME18,
        NAME19,
        NAME20,
        NAME21,
        NAME22,
        NAME23,
        NAME24,
        NAME25,
        NAME26,
        NAME27,
        NAME28,
        NAME29,
        NAME30,
        NAME31,
        NAME32,
        NAME33,
        NAME34,
        NAME35,
        NAME36,
        NAME37,
        NAME38,
        NAME39,
        NAME40,
        NAME41,
        NAME42,
        NAME43,
        NAME44,
        NAME45,
        NAME46,
        NAME47,
        NAME48,
        NAME49,
        NAME50,
        NAME51,
        NAME52,
        NAME53,
        NAME54,
        NAME55,
        NAME56,
        NAME57,
        NAME58,
        NAME59,
        NAME60,
        NAME61,
        NAME62,
        NAME63,
        NAME64,
        NAME65,
        NAME66,
        NAME67,
        NAME68,
        NAME69,
        NAME70,
        NAME71,
        NAME72,
        NAME73,
        NAME74,
        NAME75,
        NAME76,
        NAME77,
        NAME78,
        NAME79,
        NAME80,
        NAME81,
        NAME82,
        NAME83,
        NAME84,
        NAME85,
        NAME86,
        NAME87,
        NAME88,
        NAME89,
        NAME90,
        NAME91,
        NAME92,
        NAME93,
        NAME94,
        NAME95,
        NAME96,
        NAME97,
        NAME98,
        NAME99,
        NAME100,
        MAX,
    }

    /// <summary>
    /// �e�[�}�̃C�[�i��
    /// </summary>
    public enum themeNu��
    {
        NULL=0,
        theme1,
        theme2,
        theme3,
        theme4,
        theme5,
        theme6,
        theme7,
        theme8,
        theme9,
        theme10,
        theme11,
        theme12,
        theme13,
        theme14,
        theme15,
        theme16,
        theme17,
        theme18,
        theme19,
        theme20,
        MAX,
    }
    /// <summary>
    /// �X�L���̃C�[�i��
    /// </summary>
    public enum SKILLNUM
    {
        NULL=0,
        SKILL1,
        SKILL2,
        SKILL3,
        SKILL4,
        MAX,
    }


    public enum BUFFSTATUSNUM
    {
        NULL=0,
        POWER,
        DEFENSE,
        SPEED,
        CRITICAL,
        CRITICALDAMAGE,
        MAXHP,
        MAXSUTAMINA,

    }



    void Start()
    {
        selectCheck = false;
    }

    void Update()
    {
        
    }
}
