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
       //setText(null);//初期化
    }

    // Update is called once per frame
    void Update()
    {
       // setText();

    }
   public void setText(softVinyl buttonlocalsoftVinyldata)//パラメータテキストのセット関数
    {
        GameObject textOBJ = transform.GetChild(0).gameObject;
        switch (buttonlocalsoftVinyldata.buffSubstatus1)
        {
            case softVinyl.BUFFSTATUSNUM.POWER:
                MainBuffname = "<color=#ff3355>攻撃力アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.SPEED:
                MainBuffname = "<color=#3377ff>速度アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.DEFENSE:
                MainBuffname = "<color=#3377ff>防御力アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.MAXHP:
                MainBuffname = "<color=#33ff33>体力アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.MAXSUTAMINA:
                MainBuffname = "<color=#ffff00>スタミナアップ";
                break;
            case softVinyl.BUFFSTATUSNUM.CRITICAL:
                MainBuffname = "<color=#ffff00>クリティカル率アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.CRITICALDAMAGE:
                MainBuffname = "<color=#ffff00>クリティカルダメージアップ";
                break;
            case softVinyl.BUFFSTATUSNUM.NULL:
                MainBuffname = "<color=#000000>";
                break;
            default:
                break;
        }
        switch (buttonlocalsoftVinyldata.buffSubstatus1)
        {
            case softVinyl.BUFFSTATUSNUM.POWER:
                Sub1Buffname = "<color=#ff3355>攻撃力アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.SPEED:
                Sub1Buffname = "<color=#3377ff>速度アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.DEFENSE:
                Sub1Buffname = "<color=#3377ff>防御力アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.MAXHP:
                Sub1Buffname = "<color=#33ff33>体力アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.MAXSUTAMINA:
                Sub1Buffname = "<color=#ffff00>スタミナアップ";
                break;
            case softVinyl.BUFFSTATUSNUM.CRITICAL:
                Sub1Buffname = "<color=#ffff00>クリティカル率アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.CRITICALDAMAGE:
                Sub1Buffname = "<color=#ffff00>クリティカルダメージアップ";
                break;
            case softVinyl.BUFFSTATUSNUM.NULL:
                Sub1Buffname = "<color=#000000>";
                break;
            default:
                break;
        }
        switch (buttonlocalsoftVinyldata.buffSubstatus2)
        {
            case softVinyl.BUFFSTATUSNUM.POWER:
                Sub2Buffname = "<color=#ff3355>攻撃力アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.SPEED:
                Sub2Buffname = "<color=#3377ff>速度アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.DEFENSE:
                Sub2Buffname = "<color=#3377ff>防御力アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.MAXHP:
                Sub2Buffname = "<color=#33ff33>体力アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.MAXSUTAMINA:
                Sub2Buffname = "<color=#ffff00>スタミナアップ";
                break;
            case softVinyl.BUFFSTATUSNUM.CRITICAL:
                Sub2Buffname = "<color=#ffff00>クリティカル率アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.CRITICALDAMAGE:
                Sub2Buffname = "<color=#ffff00>クリティカルダメージアップ";
                break;
            case softVinyl.BUFFSTATUSNUM.NULL:
                Sub2Buffname = "<color=#000000>";
                break;
            default:
                break;
        }
        switch (buttonlocalsoftVinyldata.buffSubstatus3)
        {
            case softVinyl.BUFFSTATUSNUM.POWER:
                Sub3Buffname ="<color=#ff3355>攻撃力アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.SPEED:
                Sub3Buffname ="<color=#3377ff>素早さアップ";
                break;
            case softVinyl.BUFFSTATUSNUM.DEFENSE:
                Sub3Buffname ="<color=#3377ff>防御力アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.MAXHP:
                Sub3Buffname ="<color=#33ff33>体力アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.MAXSUTAMINA:
                Sub3Buffname ="<color=#ffff00>スタミナアップ";
                break;
            case softVinyl.BUFFSTATUSNUM.CRITICAL:
                Sub3Buffname ="<color=#ffff00>クリティカル率アップ";
                break;
            case softVinyl.BUFFSTATUSNUM.CRITICALDAMAGE:
                Sub3Buffname ="<color=#ffff00>クリティカルダメージアップ";
                break;
            case softVinyl.BUFFSTATUSNUM.NULL:
                Sub3Buffname = "<color=#000000>";
                break;
            default:
                break;
        }

        textOBJ.GetComponent<Text>().supportRichText = true; // ←これが重要！
        textOBJ.GetComponent<Text>().text = "メイン\r\n" + MainBuffname + buttonlocalsoftVinyldata.Buffparameter +
        "</color>\r\nサブ1\r\n" + Sub1Buffname + buttonlocalsoftVinyldata.Buffparameter1
        + "</color>\r\nサブ2\r\n" + Sub2Buffname + buttonlocalsoftVinyldata.Buffparameter2 +
        "</color>\r\nサブ3\r\n" + Sub3Buffname + buttonlocalsoftVinyldata.Buffparameter3 +"</color>";
    }
}//buttonlocalsoftVinyldata.Buffparameter +;
