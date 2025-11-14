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
    public PlayerStatus_Script PleyerStatus;

    void Start()
    {
        debagText = debagTextobj.GetComponent<Text>();
        //子オブジェクトのテキストコンポーネントを取得
        statusText = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        PleyerStatus = GameObject.Find("Player").GetComponent<PlayerStatus_Script>();//  直接名前検索しているのでプレイヤーobjの名前が変わるとここも変更させる

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
      "HP:" + PleyerStatus.player_MaxHealth + "攻撃力:" + PleyerStatus.player_Attack_Power + "スタミナ:" + PleyerStatus.player_MaxSutamina + "\n"
      + "スキルチャージ(毎秒):" + PleyerStatus.player_Skill_Charge+"スタミナ回復(毎秒)"+3;

    }
  
}
