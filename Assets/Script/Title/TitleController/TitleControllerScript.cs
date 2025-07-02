using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleControllerScript : MonoBehaviour
{
    [SerializeField] GameObject startOBJ;

    enum MouseClick
    {
        LEFT = 0,   //左クリック
        RIGHT,      //右クリック
        MIDDLE
    }

    void Start()
    {
        if (!startOBJ.activeSelf) startOBJ.SetActive(true);//タイトル画面を付ける

    }

    void Update()
    {
        CheakStartPanel();
    }

    //タイトル画面でクリックされたらタイトル画面消す
    void CheakStartPanel()
    {
        if (!startOBJ.activeSelf) return;

        if (Input.GetMouseButtonDown((int)MouseClick.LEFT))
        {
            startOBJ.SetActive(false);
        }

    }
}
