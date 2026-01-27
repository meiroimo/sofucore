using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComparsionText : MonoBehaviour
{
    public SetSofviManeger SetSofviManegerSc;

    [Header("メインバフ名")] public string MainBuffname;//名前
    [Header("サブ１バフ名")] public string Sub1Buffname;//名前
    [Header("サブ２バフ名")] public string Sub2Buffname;//名前
    [Header("サブ３バフ名")] public string Sub3Buffname;//名前

    void Start()
    {
    }

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
            case SoftVinilData.BUFFSTATUSNUM.SKILL_CHARGE:
            case SoftVinilData.BUFFSTATUSNUM.MAXSUTAMINA:
            case SoftVinilData.BUFFSTATUSNUM.SUTAMINA_RECHARGE_SPEED:
                return null; // 表示しない

            default:
                return null;
        }
    }

    void AddBuffLine(System.Text.StringBuilder sb, string buffName, int value)
    {
        if (string.IsNullOrEmpty(buffName))
            return;

        if (sb.Length > 0)
            sb.AppendLine();

        sb.Append(buffName)
          .Append("  +")
          .Append(value);
    }

    public void setText(SoftVinilData data)
    {
        Text text = transform.GetChild(0).GetComponent<Text>();
        text.supportRichText = true;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        // ★ 追加：一行目に固定テキスト
        sb.AppendLine("選択中ソフビステータス");
        AddBuffLine(sb, GetBuffColoredName(data.buffMainstatus), data.BuffMainParameter);
        AddBuffLine(sb, GetBuffColoredName(data.buffSubstatus1), data.BuffSubParameter1);
        AddBuffLine(sb, GetBuffColoredName(data.buffSubstatus2), data.BuffSubParameter2);
        AddBuffLine(sb, GetBuffColoredName(data.buffSubstatus3), data.BuffSubParameter3);

        text.text = sb.ToString();

        SetSofviManegerSc.ComTextmgSc.UpdateWindowSize();

        Debug.Log("ウィンドウサイズを自動調整した");
    }
}

