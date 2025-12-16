using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using static softVinyl;

public class SelectText : MonoBehaviour
{
   public SetSofviManeger SetSofviManegerSc;

    [Header("メインバフ名")] public  string MainBuffname;//名前
    [Header("サブ１バフ名")] public string Sub1Buffname;//名前
    [Header("サブ２バフ名")] public string Sub2Buffname;//名前
    [Header("サブ３バフ名")] public string Sub3Buffname;//名前

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
   public void setText(SoftVinilData buttonlocalsoftVinyldata)//パラメータテキストのセット関数
    {
        GameObject textOBJ = transform.GetChild(0).gameObject;
        switch (buttonlocalsoftVinyldata.buffMainstatus)
        {
            case SoftVinilData.BUFFSTATUSNUM.POWER:
                MainBuffname = "<color=#ff3355>攻撃力 ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.SKILL_CHARGE:
                MainBuffname = "<color=#3377ff>スキルチャージ速度 ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.MAXHP:
                MainBuffname = "<color=#33ff33>体力 ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.MAXSUTAMINA:
                MainBuffname = "<color=#ffff00>スタミナ ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.SUTAMINA_RECHARGE_SPEED:
                MainBuffname = "<color=#ffff00>スタミナ回復速度 ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.NULL:
                MainBuffname = "<color=#000000>";
                break;
            default:
                break;
        }
        switch (buttonlocalsoftVinyldata.buffSubstatus1)
        {
            case SoftVinilData.BUFFSTATUSNUM.POWER:
                Sub1Buffname = "<color=#ff3355>攻撃力 ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.SKILL_CHARGE:
                Sub1Buffname = "<color=#3377ff>スキルチャージ速度 ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.MAXHP:
                Sub1Buffname = "<color=#33ff33>体力 ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.SUTAMINA_RECHARGE_SPEED:
                Sub1Buffname = "<color=#ffff00>スタミナ回復速度 ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.MAXSUTAMINA:
                Sub1Buffname = "<color=#ffff00>スタミナ ";
                break;

              case SoftVinilData.BUFFSTATUSNUM.NULL:
                Sub1Buffname = "<color=#000000>";
                break;
            default:
                break;
        }
        switch (buttonlocalsoftVinyldata.buffSubstatus2)
        {
            case SoftVinilData.BUFFSTATUSNUM.POWER:
                Sub2Buffname = "<color=#ff3355>攻撃力 ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.SKILL_CHARGE:
                Sub2Buffname = "<color=#3377ff>スキルチャージ速度 ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.MAXHP:
                Sub2Buffname = "<color=#33ff33>体力 ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.SUTAMINA_RECHARGE_SPEED:
                Sub2Buffname = "<color=#ffff00>スタミナ回復速度 ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.MAXSUTAMINA:
                Sub2Buffname = "<color=#ffff00>スタミナ ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.NULL:
                Sub2Buffname = "<color=#000000>";
                break;
            default:
                break;
        }
        switch (buttonlocalsoftVinyldata.buffSubstatus3)
        {
            case SoftVinilData.BUFFSTATUSNUM.POWER:
                Sub3Buffname ="<color=#ff3355>攻撃力 ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.SKILL_CHARGE:
                Sub3Buffname = "<color=#3377ff>スキルチャージ速度 ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.MAXHP:
                Sub3Buffname = "<color=#33ff33>体力 ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.SUTAMINA_RECHARGE_SPEED:
                Sub3Buffname = "<color=#ffff00>スタミナ回復速度 ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.MAXSUTAMINA:
                Sub3Buffname = "<color=#ffff00>スタミナ ";
                break;
            case SoftVinilData.BUFFSTATUSNUM.NULL:
                Sub3Buffname = "<color=#000000>";
                break;
            default:
                break;
        }
        textOBJ.GetComponent<Text>().supportRichText = true; // ←これが重要！
        textOBJ.GetComponent<Text>().text = "\r\n" + MainBuffname +"+" + buttonlocalsoftVinyldata.BuffMainParameter +
        "</color>\r\n\r\n" + Sub1Buffname + "+" + buttonlocalsoftVinyldata.BuffSubParameter1
        + "</color>\r\n\r\n" + Sub2Buffname + "+" + buttonlocalsoftVinyldata.BuffSubParameter2 +
        "</color>\r\n\r\n" + Sub3Buffname + "+" + buttonlocalsoftVinyldata.BuffSubParameter3 +"</color>";
    }
}
