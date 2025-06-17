using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statuspanel : MonoBehaviour
{
    [Header ("ソフビステータスのテキスト")]public Text statusText;
    [Header("デバックテキストobj")] public GameObject debagTextobj;

    [Header("デバックテキスト")] public Text debagText;

    [Header("セレクトソフビデータ参照")] public softVinyl SelectsoftVinyldata;
    
    public string[] themeText;//themeの文字列配列
    public string[] skillText;//skillの文字列配列
    public PlayerStatus_Script debagstatus;

    void Start()
    {
        debagText = debagTextobj.GetComponent<Text>();
        themeText = new string[21];
        skillText = new string[5]; 
        themeTextset();
        skillTextset();

        //子オブジェクトのテキストコンポーネントを取得
        statusText = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();

        debagstatus = GameObject.Find("lough_model").GetComponent<PlayerStatus_Script>();//  直接名前検索しているのでプレイヤーobjの名前が変わるとここも変更させる

    }

    // Update is called once per frame
    void Update()
    {
        settext();
        setdebagtext();
    }

    //テキストをセット
    void settext()
    {
        statusText.text =
       themeText[(int)SelectsoftVinyldata.theme] + "\nコスト" + SelectsoftVinyldata.cost + "\n"+skillText[(int)SelectsoftVinyldata.skill]
       + "\n"+ SelectsoftVinyldata.ListNumber;

    }
    void setdebagtext()
    {
       
        debagText.text = "デバック用テキスト\n" +
       "追加最大体力" + debagstatus.add_Player_MaxHealth + "\n"
        +"追加スタミナ" + debagstatus.add_Player_MaxSutamina + "\n"
        + "追加攻撃力" + debagstatus.add_Player_Attack_Power + "\n"
        + "追加防御力" + debagstatus.add_Player_Defense + "\n"
        + "追加移動速度" + debagstatus.add_Player_Speed + "\n"
        + "追加会心率" + debagstatus.add_Player_Critical + "\n"
        + "追加会心ダメ率" + debagstatus.add_Player_Critical_Damage + "\n";

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
