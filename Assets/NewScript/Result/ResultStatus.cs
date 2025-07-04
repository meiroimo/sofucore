using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultStatus : MonoBehaviour
{
    [Header("表示するステータステキスト（順番に）")]
    public Text[] statusTexts;

    [Header("クリアかゲームオーバーのテキスト")]
    [SerializeField] Text resultText;

    void Start()
    {
        if (ResultClear.Instance.isGameClear)
        {
            resultText.text = "ゲームクリア！";
        }
        else
        {
            resultText.text = "ゲームオーバー…";
        }

        var data = DataManager.Instance.data;

        string[] labels = {
            "攻撃力: ",
            "最大体力: ",
            "スピード: "
            // 必要に応じて他のステータス名もここに追加
        };

        float[] values = {
            data.attackPower,
            data.maxHealth,
            data.player_Speed
            // 必要に応じて他のデータも追加
        };

        for (int i = 0; i < statusTexts.Length && i < labels.Length; i++)
        {
            statusTexts[i].text = labels[i] + values[i].ToString("F0");
        }
    }
}
