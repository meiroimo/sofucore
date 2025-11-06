using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ソフビ1体のパラメータデータを保持（モデル、スキル、テーマ、バフ値など）。
/// UIボタンや設置場所オブジェクトにも付与されている。
/// </summary>
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

  
    /// <summary>
    ///設置ポジション用ソフビが置かれていたら判定 
    /// </summary>
    public bool checksetpotion = false;
    public bool selectCheck;
    public GameObject selectButton;//セレクト中のボタン




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
        SUTAMINA_CHARGE_SPEED,
        SKILL_CHARGE,
        ATTACKRANGE
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
    public void ResetParameter()
    {
        sofvimodel= SOFVINUMBER.NULL;//このソフビの３ｄモデルプレハブ
        theme= themeNuｍ.NULL;//このソフビのテーマ
        skill= SKILLNUM.NULL;//このソフビのスキル
        rarity= Raritynum.NULL;//このソフビのレア度
        cost= 0;//このソフビのコスト
        ListNumber=0;//このソフビの番号
        buffMainstatus= BUFFSTATUSNUM.NULL;//メインステ
        buffSubstatus1 = BUFFSTATUSNUM.NULL;//サブステ１
        buffSubstatus2 = BUFFSTATUSNUM.NULL;//サブステ2
        buffSubstatus3 = BUFFSTATUSNUM.NULL;//サブステ3
        Buffparameter = 0;
        Buffparameter1 = 0;
        Buffparameter2 = 0;
        Buffparameter3 = 0;
        checksetpotion = false;
        selectCheck=false;

    }
}
