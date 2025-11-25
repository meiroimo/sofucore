using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject GameMainCanvas;//ゲームメインシーンキャンパス
    [SerializeField] private GameObject SetCanvas;//設置シーンキャンパス

    //[SerializeField] private GameObject PanelUIBox;//パネルUIOBJ
    //[SerializeField] private GameObject PlayingUIBox;//プレイングUIOBJ



    bool setUIFlg;//開いているか判定

    public bool SetUIFlg { get => setUIFlg; set => setUIFlg = value; }

    void Start()
    {
        GameObject gameObject = GameObject.Find("SetSceneCanvas");
        if (gameObject != null)
        {
            GameMainCanvas = GameObject.Find("GameMainCanvas");
            SetCanvas = GameObject.Find("SetSceneCanvas");

            setUIFlg = true;
            SetCanvas.SetActive(false);//初めはセットシーンのUIは非表示
        }
        //SetCanvas.SetActive(false);//初めはセットシーンのUIは非表示
        UIClose();

    }

    // Update is called once per frame
    void Update()
    {
       // PauseKey();
    }
    private void PauseKey()//キー入力を得る関数
    {
        if (Input.GetKeyDown(KeyCode.Tab))//tab押したら
        {
            if (setUIFlg)
            {
                UIOpen();
                //表示のソフビリストの更新
            }
            else
            {
                UIClose();
            }
        }
    }
    public void UIOpen()//設置シーンUIを開く関数
    {
        sofviSotrage.ListUpdate = true;
        setUIFlg = false;
        SetCanvas.SetActive(true);
        GameMainCanvas.SetActive(false);
    }

    public void UIClose()//設置シーンUIを閉じる関数
    {
        setUIFlg = true;
        SetCanvas.SetActive(false);
        GameMainCanvas.SetActive(true);


    }

}
