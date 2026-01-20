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

    string GetBuffColoredName(SoftVinilData.BUFFSTATUSNUM status)
    {
        switch (status)
        {
            case SoftVinilData.BUFFSTATUSNUM.POWER:
                return "<color=#ff3355>攻撃力</color>";
            case SoftVinilData.BUFFSTATUSNUM.MAXHP:
                return "<color=#33ff33>体力</color>";
            case SoftVinilData.BUFFSTATUSNUM.ATTACK_RANGE:
                return "<color=#ffff00>攻撃範囲</color>";
            case SoftVinilData.BUFFSTATUSNUM.AVOIDANCE_DISTANCE:
                return "<color=#ffff00>回避距離</color>";
            case SoftVinilData.BUFFSTATUSNUM.SKILL_POWER_MULTIPLIER:
                return "<color=#ffff00>スキル威力倍率</color>";
            case SoftVinilData.BUFFSTATUSNUM.NULL:
            //使ってないステータス
            case SoftVinilData.BUFFSTATUSNUM.SKILL_CHARGE:
                //return "<color=#3377ff>スキルチャージ速度</color>";
                return null; // ← 表示しない

            case SoftVinilData.BUFFSTATUSNUM.MAXSUTAMINA:
                //return "<color=#ffff00>スタミナ</color>";
                return null; // ← 表示しない

            case SoftVinilData.BUFFSTATUSNUM.SUTAMINA_RECHARGE_SPEED:
                //return "<color=#ffff00>スタミナ回復速度</color>";
                return null; // ← 表示しない

            default:
                return null; // ← 表示しない
        }
    }

    void AddBuffLine(System.Text.StringBuilder sb, string buffName, int value)
    {
        if (string.IsNullOrEmpty(buffName))
            return; // NULLは完全スキップ

        if (sb.Length > 0)
            sb.AppendLine(); // 既に行があれば改行

        sb.Append(buffName)
          .Append("  +")
          .Append(value);
    }
    public void setText(SoftVinilData data)
    {
        Text text = transform.GetChild(0).GetComponent<Text>();
        text.supportRichText = true;

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        AddBuffLine(sb, GetBuffColoredName(data.buffMainstatus), data.BuffMainParameter);
        AddBuffLine(sb, GetBuffColoredName(data.buffSubstatus1), data.BuffSubParameter1);
        AddBuffLine(sb, GetBuffColoredName(data.buffSubstatus2), data.BuffSubParameter2);
        AddBuffLine(sb, GetBuffColoredName(data.buffSubstatus3), data.BuffSubParameter3);

        text.text = sb.ToString();

        SetSofviManegerSc.TextWindowManegerSc.UpdateWindowSize();
        SetSofviManegerSc.TextWindowManegerSc_copy.UpdateWindowSize();
        Debug.Log("ウィンドウサイズを自動調整した");
    }
}
