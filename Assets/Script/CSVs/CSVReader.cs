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

    int playerNo = 1;

    /// <summary>
    /// 名前 = 1,
    /// 最大体力 = 2,
    /// 最大スタミナ = 3,
    /// 攻撃力 = 4,
    /// 防御力 = 5,
    /// スピード = 6,
    /// 会心率 = 7,
    /// 会心ダメ = 8,
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
        D_CRITICAL_DAMAGE
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

    void Start()
    {
        playerStatus_Script = GetComponent<PlayerStatus_Script>();
        enemyStatus_Script = GetComponent<EnemyStatus_Script>();
        CsvRead(enemyStatusCSV, enemyStatusDatas);
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
        playerStatus_Script.D_player_MaxHealth = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_MAX_HEALTH]);
        playerStatus_Script.D_player_MaxSutamina = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_MAX_SUTAMINA]);
        playerStatus_Script.D_player_Attack_Power = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_ATTACK_POWER]);
        playerStatus_Script.D_player_Defense = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_DEFENCE]);
        playerStatus_Script.D_player_Speed = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_SPEED]);
        playerStatus_Script.D_player_Critical = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_CRITICAL]);
        playerStatus_Script.D_player_Critical_Damage = float.Parse(playerStatusDatas[playerNo][(int)CSVPlayerStatus.D_CRITICAL_DAMAGE]);

    }


    public void LoadingEnemyStatus(int typeNo)
    {
        enemyStatus_Script.enemy_MaxHealth = float.Parse(enemyStatusDatas[typeNo][(int)CSVEnemyStatus.D_MAX_HEALTH]);
        enemyStatus_Script.enemy_Attack_Power = float.Parse(enemyStatusDatas[typeNo][(int)CSVEnemyStatus.D_ATTACK_POWER]);
        enemyStatus_Script.enemy_Defense = float.Parse(enemyStatusDatas[typeNo][(int)CSVEnemyStatus.D_DEFENCE]);
        enemyStatus_Script.enemy_Speed = float.Parse(enemyStatusDatas[typeNo][(int)CSVEnemyStatus.D_SPEED]);
    }

}
