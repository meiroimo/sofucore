using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    TextAsset csvFile; // CSVファイル

    string playerStatusCSV = "Status/PlayerStatusCSV";  //プレイヤー初期ステータスのCSVのパス
    string enemyStatusCSV = "Status/EnemyStatusCSV";    //エネミー初期ステータスのCSVのパス

    List<string[]> playerStatusDatas = new List<string[]>();    //プレイヤーデータCSVの中身を入れるリスト
    List<string[]> enemyStatusDatas = new List<string[]>();     //エネミーデータCSVの中身を入れるリスト

    [SerializeField, Header("代入するプレイヤーステータススクリプト")] PlayerStatus_Script playerStatus_Script;
    [SerializeField, Header("代入するエネミーステータススクリプト")] EnemyStatus_Script enemyStatus_Script;
    [SerializeField, Header("敵の最終ステータスを代入するスポナースクリプト")] EnemySpawner enemySpawner_Script;

    int playerNo = 1;

    public void SetPlayerStatusScript(PlayerStatus_Script script)
    {
        this.playerStatus_Script = script;
    }

    public void SetEnemyStatusScript(EnemyStatus_Script script)
    {
        this.enemyStatus_Script = script;
    }

    public void SetFinalEnemyStatusScript(EnemySpawner script)
    {
        this.enemySpawner_Script = script;
    }


    /// <summary>
    /// 名前 = 1,
    /// 最大体力 = 2,
    /// 最大スタミナ = 3,
    /// 攻撃力 = 4,
    /// スキルチャージ = 5
    /// スタミナ回復速度=6
    /// </summary>
    enum CSVPlayerStatus
    {
        NAME = 1,
        D_MAX_HEALTH,
        D_MAX_SUTAMINA,
        D_ATTACK_POWER,
        D_SKILL_CHARGE,
        D_SUTAMINA_RECHARGE,
        D_ATTACK_RANGE,
        D_AVOIDANCE_DISTANCE,
        D_SKILL_POWER_MULTIPLIER
    }

    /// <summary>
    /// 敵の種類(タイプ) = 0,
    /// 名前 = 1,
    /// 最大体力 = 2,
    /// 攻撃力 = 4,
    /// 防御力 = 5,
    /// スピード = 6,
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
     CSV読み込み関数　データを使う前やStarで読み込む
     引数：string CSV：CSVのパス
    　　　 List<string[]> Datas：データを入れるリスト
     戻り値：なし
     */
    public void CsvRead(string CSV, List<string[]> Datas)
    {
        csvFile = Resources.Load(CSV) as TextAsset; //Resoucsc下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine(); //一行ずつ読み込み
            Datas.Add(line.Split(','));      //, 区切りでリストに追加
        }
    }


    public void LoadingPlayerStatus()
    {
        //データ読み込み
        CsvRead(playerStatusCSV, playerStatusDatas);

        //データを入れる
        playerStatus_Script.default_player_MaxHealth = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_MAX_HEALTH]);
        playerStatus_Script.default_player_MaxSutamina = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_MAX_SUTAMINA]);
        playerStatus_Script.default_player_Attack_Power = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_ATTACK_POWER]);
        playerStatus_Script.default_player_Skill_Charge = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_SKILL_CHARGE]);
        playerStatus_Script.default_player_stamina_recovery_speed = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_SUTAMINA_RECHARGE]);
        playerStatus_Script.default_player_Attack_Range = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_ATTACK_RANGE]);
        playerStatus_Script.default_player_Avoidance_Distance = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_AVOIDANCE_DISTANCE]);
        playerStatus_Script.default_player_Skill_Power_Multiplier = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_SKILL_POWER_MULTIPLIER]);

    }



    public void LoadingEnemyStatus(int typeNo)
    {
        enemyStatus_Script.enemy_MaxHealth = float.Parse(enemyStatusDatas[typeNo][(int)CSVEnemyStatus.D_MAX_HEALTH]);
        enemyStatus_Script.enemy_Attack_Power = float.Parse(enemyStatusDatas[typeNo][(int)CSVEnemyStatus.D_ATTACK_POWER]);
        enemyStatus_Script.enemy_Defense = float.Parse(enemyStatusDatas[typeNo][(int)CSVEnemyStatus.D_DEFENCE]);
        enemyStatus_Script.enemy_Speed = float.Parse(enemyStatusDatas[typeNo][(int)CSVEnemyStatus.D_SPEED]);
    }

    public void LoadingEnemyFinalStatus(int typeNo)
    {
        enemySpawner_Script.Enemy_Final_MaxHealth = float.Parse(enemyStatusDatas[typeNo][(int)CSVEnemyStatus.D_MAX_HEALTH]);
        enemySpawner_Script.Enemy_Final_Attack_Power = float.Parse(enemyStatusDatas[typeNo][(int)CSVEnemyStatus.D_ATTACK_POWER]);
        enemySpawner_Script.Enemy_Final_Defense = float.Parse(enemyStatusDatas[typeNo][(int)CSVEnemyStatus.D_DEFENCE]);
        enemySpawner_Script.Enemy_Final_Speed = float.Parse(enemyStatusDatas[typeNo][(int)CSVEnemyStatus.D_SPEED]);
    }

    public void ApplyPlayerStatusToSaveData()
    {
        if (DataManager.Instance == null)
        {
            Debug.Log("jspnがないよ");
            return;
        }

        var data = DataManager.Instance.data;

        float atk = playerStatus_Script.default_player_Attack_Power;
        float hp = playerStatus_Script.default_player_MaxHealth;
        float stamina_rechage = playerStatus_Script.default_player_stamina_recovery_speed;


        data.attackPower = atk;
        data.maxHealth = hp;
        data.staminaRecoverySpeed = stamina_rechage;
        // 初期値としても保存
        data.base_attackPower = atk;
        data.base_maxHealth = hp;
        data.base_staminaRecoverySpeed = stamina_rechage;

        DataManager.Instance.SaveNow(); // 保存 
    }

    public void ResetToBaseStatus()
    {
        if (DataManager.Instance == null) return;

        var data = DataManager.Instance.data;

        data.attackPower = data.base_attackPower;
        data.maxHealth = data.base_maxHealth;
       // data.player_Speed = data.base_player_Speed;


        DataManager.Instance.SaveNow(); // 必要なら
    }
}
