using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static softVinyl;
using static TreasureChestDropScript;

public class dropRandomStatusScript : MonoBehaviour
{
    /*
     Prefabs/drop/sofvi�@�I�u�W�F�N�g�ɓ\��
     �������ꂽ�^�C�~���O�ŃX�e�[�^�X�������_���ŕt�^����
     �Ή����郌�A���e�B���X�e�[�^�X�̒ǉ��l������
     */
    softVinyl softVinylStatusScript;
    //�ǉ�����l�@�X�e�[�^�X�̏��Ԃ� softVinyl��BUFFSTATUSNUM enum�̏��ł����
    List<List<int>> setRarityStatus = new List<List<int>>()
    {
        //POWER,DEFENSE,SPEED,CRITICAL,CRITICALDAMAGE,MAXHP,MAXSUTAMINA,SUTAMINA_CHARGE_SPEED,SKILL_CHARGE,ATTACKRANGE
        new List<int>(){1,0,2,1,1,10,10,1,1,10},  //Normal
        new List<int>(){3,0,4,2,2,30,30,3,3,30},  //RARE
        new List<int>(){5,0,6,3,3,50,50,5,5,50}   //SUPARRARE
    };

    void Start()
    {
        softVinylStatusScript = GetComponent<softVinyl>();
        
        SetStatusRandom();
    }

    void Update()
    {
        
    }


    void SetStatusRandom()
    {
        //���C���X�e
        softVinylStatusScript.buffMainstatus = (BUFFSTATUSNUM)Random.Range((float)BUFFSTATUSNUM.NULL, (float)BUFFSTATUSNUM.MAXSUTAMINA) + 1;
        //�T�u�X�e�P
        softVinylStatusScript.buffSubstatus1 = (BUFFSTATUSNUM)Random.Range((float)BUFFSTATUSNUM.NULL, (float)BUFFSTATUSNUM.MAXSUTAMINA) + 1;
        //�T�u�X�e2
        softVinylStatusScript.buffSubstatus2 = (BUFFSTATUSNUM)Random.Range((float)BUFFSTATUSNUM.NULL, (float)BUFFSTATUSNUM.MAXSUTAMINA) + 1;
        //�T�u�X�e3
        softVinylStatusScript.buffSubstatus3 = (BUFFSTATUSNUM)Random.Range((float)BUFFSTATUSNUM.NULL, (float)BUFFSTATUSNUM.MAXSUTAMINA) + 1;

        //���C���X�e�@�ǉ��l
        softVinylStatusScript.Buffparameter = setRarityStatus[(int)softVinylStatusScript.rarity -1][(int)softVinylStatusScript.buffMainstatus -1];
        //�T�u�X�e�P�@�ǉ��l
        softVinylStatusScript.Buffparameter1 = setRarityStatus[(int)softVinylStatusScript.rarity -1][(int)softVinylStatusScript.buffSubstatus1 -1];
        //�T�u�X�e2 �@�ǉ��l
        softVinylStatusScript.Buffparameter2 = setRarityStatus[(int)softVinylStatusScript.rarity -1][(int)softVinylStatusScript.buffSubstatus2 -1];
        //�T�u�X�e3 �@�ǉ��l
        softVinylStatusScript.Buffparameter3 = setRarityStatus[(int)softVinylStatusScript.rarity -1][(int)softVinylStatusScript.buffSubstatus3 -1];


    }
}
