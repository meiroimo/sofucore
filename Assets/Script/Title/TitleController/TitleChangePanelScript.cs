using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleChangePanelScript : MonoBehaviour
{
    [SerializeField, Header("それぞれのパネル")] GameObject[] changePanel;

    public enum PanelName
    {
        SELECT_PANEL,       //セレクト画面
        GAME_HOW_TO_PANEL,  //遊び方画面
        SETTING_PANEL,      //設定画面
        EXIT                //終了画面
    }

    void Start()
    {
        //セレクト画面を付けておく
        ChangeButtonPanel((int)PanelName.SELECT_PANEL); 
    }

    //引数の値のパネルを付け、それ以外を消す
    public void ChangeButtonPanel(int nextPanel)
    {
        for(int i = 0; i < changePanel.Length; i++)
        {
            if (i == (int)nextPanel)
            {
                changePanel[i].SetActive(true);
            }
            else
            {
                changePanel[i].SetActive(false);
            }
        }
    }
}
