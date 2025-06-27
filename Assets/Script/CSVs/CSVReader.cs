using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    TextAsset csvFile; // CSV�t�@�C��

    string playerStatusCSV = "Status/PlayerStatusCSV";  //�v���C���[�����X�e�[�^�X��CSV�̃p�X
    string enemyStatusCSV = "Status/EnemyStatusCSV";    //�G�l�~�[�����X�e�[�^�X��CSV�̃p�X

    List<string[]> playerStatusDatas = new List<string[]>();    //�v���C���[�f�[�^CSV�̒��g�����郊�X�g
    List<string[]> enemyStatusDatas = new List<string[]>();     //�G�l�~�[�f�[�^CSV�̒��g�����郊�X�g

    [SerializeField, Header("�������v���C���[�X�e�[�^�X�X�N���v�g")] PlayerStatus_Script playerStatus_Script;
    [SerializeField, Header("�������G�l�~�[�X�e�[�^�X�X�N���v�g")] EnemyStatus_Script enemyStatus_Script;

    int playerNo = 1;

    public void SetPlayerStatusScript(PlayerStatus_Script script)
    {
        this.playerStatus_Script = script;
    }

    public void SetEnemyStatusScript(EnemyStatus_Script script)
    {
        this.enemyStatus_Script = script;
    }

    /// <summary>
    /// ���O = 1,
    /// �ő�̗� = 2,
    /// �ő�X�^�~�i = 3,
    /// �U���� = 4,
    /// �h��� = 5,
    /// �X�s�[�h = 6,
    /// ��S�� = 7,
    /// ��S�_�� = 8,
    /// �X�L���|�C���g= 9,
    /// �X�L���`���[�W = 10
    /// </summary>
    enum CSVPlayerStatus
    {
        NAME = 1,
        D_MAX_HEALTH,
        D_MAX_SUTAMINA,
        D_ATTACK_POWER,
        D_DEFENCE,
        D_SPEED,
        D_CRITICAL,
        D_CRITICAL_DAMAGE,
        D_SKILL_POINT,
        D_SKILL_CHARGE
    }

    /// <summary>
    /// �G�̎��(�^�C�v) = 0,
    /// ���O = 1,
    /// �ő�̗� = 2,
    /// �U���� = 4,
    /// �h��� = 5,
    /// �X�s�[�h = 6,
    /// </summary>
    enum CSVEnemyStatus
    {
        TYPE = 0,
        NAME,
        D_MAX_HEALTH,
        D_ATTACK_POWER,
        D_DEFENCE,
        D_SPEED
    }

    void Awake()
    {
        enemyStatus_Script = GetComponent<EnemyStatus_Script>();
        CsvRead(enemyStatusCSV, enemyStatusDatas);
        ResetToBaseStatus();
        ApplyPlayerStatusToSaveData();
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
        playerStatus_Script.D_player_Skill_Point = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_SKILL_POINT]);
        playerStatus_Script.D_player_Skill_Charge = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_SKILL_CHARGE]);

    }


    public void LoadingEnemyStatus(int typeNo)
    {
        enemyStatus_Script.enemy_MaxHealth = float.Parse(enemyStatusDatas[typeNo][(int)CSVEnemyStatus.D_MAX_HEALTH]);
        enemyStatus_Script.enemy_Attack_Power = float.Parse(enemyStatusDatas[typeNo][(int)CSVEnemyStatus.D_ATTACK_POWER]);
        enemyStatus_Script.enemy_Defense = float.Parse(enemyStatusDatas[typeNo][(int)CSVEnemyStatus.D_DEFENCE]);
        enemyStatus_Script.enemy_Speed = float.Parse(enemyStatusDatas[typeNo][(int)CSVEnemyStatus.D_SPEED]);
    }

    public void ApplyPlayerStatusToSaveData()
    {
        if (DataManager.Instance == null)
        {
            Debug.Log("jspn���Ȃ���");
            return;
        }

        var data = DataManager.Instance.data;

        float atk = playerStatus_Script.D_player_Attack_Power;
        float hp = playerStatus_Script.D_player_MaxHealth;
        float spd = playerStatus_Script.D_player_Speed;

        data.attackPower = atk;
        data.maxHealth = hp;
        data.player_Speed = spd;

        // �����l�Ƃ��Ă��ۑ�
        data.base_attackPower = atk;
        data.base_maxHealth = hp;
        data.base_player_Speed = spd;

        DataManager.Instance.SaveNow(); // �ۑ� 
    }

    public void ResetToBaseStatus()
    {
        if (DataManager.Instance == null) return;

        var data = DataManager.Instance.data;

        data.attackPower = data.base_attackPower;
        data.maxHealth = data.base_maxHealth;
        data.player_Speed = data.base_player_Speed;

        DataManager.Instance.SaveNow(); // �K�v�Ȃ�
    }
}
