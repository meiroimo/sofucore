using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using static softVinyl;
[CreateAssetMenu(fileName = "NewSofviData", menuName = "Sofvi/SoftVinylData")]
public class SofviDataScriptable : ScriptableObject
{
    [Header("ソフビ種類")] public SOFVINUMBER sofvimodel;//このソフビの３ｄモデルの番号
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
    public GameObject selectButton;//セレクト中のボタン


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
        NULL = 0,
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
    public void ResetParameter()
    {
        sofvimodel = SOFVINUMBER.NULL;//このソフビの３ｄモデルプレハブ
        rarity = Raritynum.NULL;//このソフビのレア度
        ListNumber = 0;//このソフビの番号
        buffMainstatus = BUFFSTATUSNUM.NULL;//メインステ
        buffSubstatus1 = BUFFSTATUSNUM.NULL;//サブステ１
        buffSubstatus2 = BUFFSTATUSNUM.NULL;//サブステ2
        buffSubstatus3 = BUFFSTATUSNUM.NULL;//サブステ3
        BuffMainParameter = 0;
        BuffSubParameter1 = 0;
        BuffSubParameter2 = 0;
        BuffSubParameter3 = 0;
        checksetpotion = false;
        selectCheck = false;
        selectButton = null;
    }
}
