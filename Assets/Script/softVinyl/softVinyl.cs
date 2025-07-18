using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class softVinyl : MonoBehaviour
{
    [Header("ソフビ種類")] public SOFVINUMBER sofvimodel;//このソフビの３ｄモデルプレハブ
    [Header("テーマ")] public themeNuｍ theme;//このソフビのテーマ
    [Header("スキル")] public SKILLNUM skill;//このソフビのスキル
    [Header("レア度")] public Raritynum rarity;//このソフビのレア度

    [Header("コスト")] public int cost;//このソフビのコスト
    [Header("ナンバー")] public int ListNumber;//このソフビの番号


    [Header("バフメインステータス")] public BUFFSTATUSNUM buffMainstatus;//メインステ
    [Header("バフサブステータス１")] public BUFFSTATUSNUM buffSubstatus1;//サブステ１
    [Header("バフサブステータス２")] public BUFFSTATUSNUM buffSubstatus2;//サブステ２
    [Header("バフサブステータス３")] public BUFFSTATUSNUM buffSubstatus3;//サブステ３

    [Header("バフメインステータスパラメーター")] public int Buffparameter;//メインステ
    [Header("バフサブステータスパラメーター１")] public int Buffparameter1;//サブステ１
    [Header("バフサブステータスパラメーター２")] public int Buffparameter2;//サブステ２
    [Header("バフサブステータスパラメーター３")] public int Buffparameter3;//サブステ３

    [Header("メインバフ名前")] public string buffName;　 //メインステ名前
    [Header("サブバフ１名前")] public string buffName1;　　//サブ名前１
    [Header("サブバフ２名前")] public string buffName2;　　//サブ名前２
    [Header("サブバフ３名前")] public string buffName3;　//サブ名前３
    /// <summary>
    ///設置ポジション用ソフビが置かれていたら判定 
    /// </summary>
    public bool checksetpotion = false;
    public bool selectCheck;
    public GameObject selectButton;//セレクト中のボタン
                                   //ここＣＳＶで管理できたらいいね




    /// <summary>
    /// テーマのイーナム
    /// </summary>
    public enum themeNuｍ
    {
        NULL = 0,
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
        NULL = 0,
        SKILL1,
        SKILL2,
        SKILL3,
        SKILL4,
        MAX,
    }
    public enum SOFVINUMBER
    {
        NULL = 0,
        MODEL1,
        MODEL2,
        MODEL3,
        MODEL4,
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

    /// <summary>
    /// テーマのイーナム
    /// </summary>
    public enum Raritynum
    {
        NULL = 0,
       NOMAL,
       RARE,
       SUPARRARE,
        MAX,
    }


    void Start()
    {
        selectCheck = false;
    }

    void Update()
    {
        
    }
}
