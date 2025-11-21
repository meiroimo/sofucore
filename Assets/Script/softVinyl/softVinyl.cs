using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ソフビ1体のパラメータデータを保持（モデル、スキル、テーマ、バフ値など）。
/// UIボタンや設置場所オブジェクトにも付与されている。
/// </summary>
public class softVinyl 
{
    [Header("ソフビ種類")] public SOFVINUMBER sofvimodel;//このソフビの３ｄモデルプレハブ
    [Header("レア度")] public Raritynum rarity;//このソフビのレア度
    [Header("ナンバー")] public int ListNumber;//このソフビの番号


    [Header("バフメインステータス")] public BUFFSTATUSNUM buffMainstatus;//メインステ
    [Header("バフサブステータス１")] public BUFFSTATUSNUM buffSubstatus1;//サブステ１
    [Header("バフサブステータス２")] public BUFFSTATUSNUM buffSubstatus2;//サブステ２
    [Header("バフサブステータス３")] public BUFFSTATUSNUM buffSubstatus3;//サブステ３

    [Header("バフメインステータスパラメーター")] public int BuffMainParameter;//メインステ
    [Header("バフサブステータスパラメーター１")] public int BuffSubParameter1;//サブステ１
    [Header("バフサブステータスパラメーター２")] public int BuffSubParameter2;//サブステ２
    [Header("バフサブステータスパラメーター３")] public int BuffSubParameter3;//サブステ３

  
    /// <summary>
    ///設置ポジション用ソフビが置かれていたら判定 
    /// </summary>
    public bool checksetpotion = false;
    public bool selectCheck;
    public int selectButton;//セレクト中のボタンの番号


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
        MAXHP,
        SKILL_CHARGE,
        SUTAMINA_RECHARGE_SPEED,
        MAXSUTAMINA,
    }
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

  
    public void ResetParameter()
    {
        sofvimodel= SOFVINUMBER.NULL;//このソフビの３ｄモデルプレハブ
        rarity= Raritynum.NULL;//このソフビのレア度
        ListNumber=0;//このソフビの番号
        buffMainstatus= BUFFSTATUSNUM.NULL;//メインステ
        buffSubstatus1 = BUFFSTATUSNUM.NULL;//サブステ１
        buffSubstatus2 = BUFFSTATUSNUM.NULL;//サブステ2
        buffSubstatus3 = BUFFSTATUSNUM.NULL;//サブステ3
        BuffMainParameter = 0;
        BuffSubParameter1 = 0;
        BuffSubParameter2 = 0;
        BuffSubParameter3 = 0;
        checksetpotion = false;
        selectCheck=false;
        selectButton = 0;
    }
}
