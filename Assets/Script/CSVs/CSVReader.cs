using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    TextAsset csvFile; // CSV�t�@�C��

    string playerStatusCSV = "Status/PlayerStatusCSV";  //�v���C���[�����X�e�[�^�X��CSV�̃p�X

    List<string[]> playerStatusDatas = new List<string[]>();    //�v���C���[�f�[�^CSV�̒��g�����郊�X�g

    public PlayerStatus_Script playerStatus_Script;

    int playerNo = 1;


    enum CSVPlayerStatus
    {
        NAME = 1,
        D_MAX_HEALTH,
        D_MAX_SUTAMINA,
        D_ATTACK_POWER,
        D_DEFENCE,
        D_SPEED,
        D_CRITICAL,
        D_CRITICAL_DAMAGE
    }


    void Start()
    {
    }

    void Update()
    {
        
    }


    /*
     CSV�ǂݍ��݊֐��@�f�[�^���g���O��Star�œǂݍ���
     �����Fstring CSV�FCSV�̃p�X
    �@�@�@ List<string[]> Datas�F�f�[�^�����郊�X�g
     �߂�l�F�Ȃ�
     */
    public void CsvRead(string CSV, List<string[]> Datas)
    {
        csvFile = Resources.Load(CSV) as TextAsset; //Resoucsc����CSV�ǂݍ���
        StringReader reader = new StringReader(csvFile.text);
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); //��s���ǂݍ���
            Datas.Add(line.Split(','));      //, ��؂�Ń��X�g�ɒǉ�
        }
    }

    public void LoadingPlayerStatus()
    {
        //�f�[�^�ǂݍ���
        CsvRead(playerStatusCSV, playerStatusDatas);

        //�f�[�^������
        playerStatus_Script.D_player_MaxHealth = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_MAX_HEALTH]);
        playerStatus_Script.D_player_MaxSutamina = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_MAX_SUTAMINA]);
        playerStatus_Script.D_player_Attack_Power = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_ATTACK_POWER]);
        playerStatus_Script.D_player_Defense = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_DEFENCE]);
        playerStatus_Script.D_player_Speed = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_SPEED]);
        playerStatus_Script.D_player_Critical = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_CRITICAL]);
        playerStatus_Script.D_player_Critical_Damage = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_CRITICAL_DAMAGE]);

    }



}
