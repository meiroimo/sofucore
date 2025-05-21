using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class softVinyl : MonoBehaviour
{
       [Header("名前")] public  Name  sofviName;//このソフビの画像

    [Header("画像")] public Sprite sofviImage;//このソフビの画像
    [Header("テーマ")] public themeNuｍ theme;//このソフビのテーマ
    [Header("スキル")] public SKILLNUM skill;//このソフビのスキル
    [Header("コスト")] public int  cost;//このソフビのコスト
    [Header("ナンバー")] public int　ListNumber;//このソフビの番号
                      

    [Header("バフメインステータス")] public BUFFSTATUSNUM buffMainstatus;//メインステ
    [Header("バフサブステータス１")] public BUFFSTATUSNUM buffSubstatus1;//サブステ１
    [Header("バフサブステータス２")] public BUFFSTATUSNUM buffSubstatus2;//サブステ２
    [Header("バフサブステータス３")] public BUFFSTATUSNUM buffSubstatus3;//サブステ３

    [Header("バフメインステータスパラメーター")] public int Buffparameter;//メインステ
    [Header("バフサブステータスパラメーター１")] public int Buffparameter1;//サブステ１
    [Header("バフサブステータスパラメーター２")] public int Buffparameter2;//サブステ２
    [Header("バフサブステータスパラメーター３")] public int Buffparameter3;//サブステ３

    [Header("メイン名前")] public new string buffName;　 //メインステ名前
    [Header("サブ１名前")] public  string buffName1;　　//サブ名前１
    [Header("サブ２名前")] public string buffName2;　　//サブ名前２
    [Header("サブ３名前")] public  string buffName3;　//サブ名前３

    public bool selectCheck;
    public GameObject selectButton;//セレクト中のボタン
                                   //ここＣＳＶで管理できたらいいね



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
    /// テーマのイーナム
    /// </summary>
    public enum themeNuｍ
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
    /// スキルのイーナム
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
