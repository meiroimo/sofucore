using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject GameMainCanvas;//ゲームメインシーンキャンパス
    [SerializeField] private GameObject SetCanvas;//設置シーンキャンパス

    //[SerializeField] private GameObject PanelUIBox;//パネルUIOBJ
    //[SerializeField] private GameObject PlayingUIBox;//プレイングUIOBJ



    bool SetUIFlg;//開いているか判定
    void Start()
    {
        var gameObject = GameObject.Find("SetSceneCanvas");
        if (gameObject != null)
        {
            GameMainCanvas = GameObject.Find("GameMainCanvas");
            SetCanvas = GameObject.Find("SetSceneCanvas");

            SetUIFlg = true;
            SetCanvas.SetActive(false);//初めはセットシーンのUIは非表示
        }
      

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
            if (SetUIFlg)
            {
                UIOpen();

            }
            else
            {
                UIClose();
            }
        }
    }
    public void UIOpen()//設置シーンUIを開く関数
    {
        SetUIFlg = false;
        SetCanvas.SetActive(true);
        GameMainCanvas.SetActive(false);
    }

    public void UIClose()//設置シーンUIを閉じる関数
    {
        SetUIFlg = true;
        SetCanvas.SetActive(false);
        GameMainCanvas.SetActive(true);


    }

}
