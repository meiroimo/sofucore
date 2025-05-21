using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statuspanel : MonoBehaviour
{
    [Header ("ソフビステータスのテキスト")]public Text statusText;
    [Header("セレクトソフビデータ参照")] public softVinyl SelectsoftVinyldata;

    public string[] themeText;//themeの文字列配列
    public string[] skillText;//skillの文字列配列


    void Start()
    {
        themeText = new string[21];
        skillText = new string[5]; 
        themeTextset();
        skillTextset();

        //子オブジェクトのテキストコンポーネントを取得
        statusText = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        settext();

    }

    //テキストをセット
    void settext()
    {
        statusText.text =
       themeText[(int)SelectsoftVinyldata.theme] + "\nコスト" + SelectsoftVinyldata.cost + "\n"+skillText[(int)SelectsoftVinyldata.skill]
       + "\n"+ SelectsoftVinyldata.ListNumber;

    }
    void themeTextset()//テーマテキストをセット
    {
        themeText[1] = "テーマ１";
        themeText[2] = "テーマ２";
        themeText[3] = "テーマ３";
        themeText[4] = "テーマ４";
        themeText[5] = "テーマ５";
        themeText[6] = "テーマ６";
        themeText[7] = "テーマ７";
        themeText[8] = "テーマ８";
        themeText[9] = "テーマ９";
        themeText[10] = "テーマ１０";
        themeText[11] = "テーマ１１";
        themeText[12] = "テーマ１２";
        themeText[13] = "テーマ１３";
        themeText[14] = "テーマ１４";
        themeText[15] = "テーマ１５";
        themeText[16] = "テーマ１６";
        themeText[17] = "テーマ１７";
        themeText[18] = "テーマ１８";
        themeText[19] = "テーマ１９";
        themeText[20] = "テーマ２０";

    }
    void skillTextset()//スキルテキストのセット
    {

        skillText[1] = "スキル１";
        skillText[2] = "スキル２";
        skillText[3] = "スキル３";
        skillText[4] = "スキル４";

    }
}
