using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultStatus : MonoBehaviour
{
    [Header("表示するステータステキスト（順番に）")]
    public Text[] statusTexts;

    [Header("クリアかゲームオーバーのImage")]
    [SerializeField] GameObject clearImage;
    [SerializeField] GameObject overImage;

    void Start()
    {
        clearImage.SetActive(false);
        overImage.SetActive(false);

        if (ResultClear.Instance.isGameClear)
        {
            clearImage.SetActive(true);
        }
        else
        {
            overImage.SetActive(true);
        }

        var data = DataManager.Instance.data;

        string[] labels = 
        {
            "攻撃力: ",
            "体力: ",
            "スピード: ",
            "回避距離: ",
            "攻撃範囲: ",
            "スキル威力倍率: ",
            "倒した敵の数",
            "入手したソフビの数"
            // 必要に応じて他のステータス名もここに追加
        };

        float[] values =
        {
            PlayerStatusCache.lastattackPower,
            PlayerStatusCache.lastmaxHealth,
            PlayerStatusCache.lastspeed,
            PlayerStatusCache.lastAvoidance_Distance,
            PlayerStatusCache.lastAttack_Range,
            PlayerStatusCache.lastSkill_Power_Multiplier,
            PlayerStatusCache.enemy_Defats,
            PlayerStatusCache.catchSofviCount
            // 必要に応じて他のデータも追加
        };

        string[] unit =
        {
            "",
            "",
            "",
            "",
            "",
            "",
            "体",
            "個"
        };

        for (int i = 0; i < statusTexts.Length && i < values.Length; i++)
        {
            //statusTexts[i].text = labels[i] + values[i].ToString("F0") + unit[i];
            statusTexts[i].text = values[i].ToString("F0") + unit[i];
        }
    }
}
