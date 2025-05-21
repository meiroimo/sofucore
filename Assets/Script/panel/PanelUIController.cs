using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelUIController : MonoBehaviour
{
    [SerializeField] private GameObject PanelUIBox;//パネルUIOBJ
    [SerializeField] private GameObject PlayingUIBox;//プレイングUIOBJ



    bool panelUIFlg;//開いているか判定
    void Start()
    {
        panelUIFlg = true;
        PanelUIBox.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        PauseKey();
    }
    private void PauseKey()//キー入力を得る関数
    {
        if (Input.GetKeyDown(KeyCode.Tab) )//tab押したら
        {
            if (panelUIFlg)
            {
                UIOpen();
               
            }
            else
            {
                UIClose();
            }
        }
    }
    private void UIOpen()//パネルウィンドウを開く関数
    {
        panelUIFlg = false;
        Time.timeScale = 0;  // 時間停止
        PanelUIBox.SetActive(true);
        PlayingUIBox.SetActive(false);
    }

    public void UIClose()//パネルウィンドウを閉じる関数
    {
        panelUIFlg = true;
        Time.timeScale = 1;  // 再開
        PanelUIBox.SetActive(false);
        PlayingUIBox.SetActive(true);


    }

}
