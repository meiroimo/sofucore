using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class setWindow : MonoBehaviour
{
    Transform Parent;//親オブジェクト
    public softVinyl selectSofviData;//子オブジェクトのソフビスクリプト
    [Header("セレクト中のソフビ")] public GameObject selectSofviDataOBJ;//子オブジェクト、セレクト中のソフビデータ保存場所
     public GameObject selectSofvibutton;//セレクト中のソフビ一覧のボタン
    bool checkSetSelectSofviData;//セレクトソフビデータがセットされているか
    public GameObject grandChild;
    private int renCount=4;//ソフビ台の段数
    public GameObject[] renOBJ;//セットする台の段obj
    public GameObject[,] setpositionOBJ;//セットする場所のOBJ二次元配列,孫OBJ
    //public GameObject[] setpositionOBJ;//セットする場所のOBJ配列

    void Start()
    {

        Parent = this.gameObject.transform;
        renOBJ = new GameObject[renCount];
        setpositionOBJ = new GameObject[renCount,4];

        selectSofviDataOBJ = new GameObject();
        //selectSofviData = new softVinyl();
        selectSofviDataOBJ = transform.Find("selectSofvi").gameObject;
        selectSofviData = selectSofviDataOBJ.GetComponent<softVinyl>();
        //孫（子オブジェクトの子オブジェクト)を取得する。
        //以下の場合なら自身の子オブジェクトChildの子オブジェクトGrandChildを取得
         //grandChild = transform.Find("Step1/GameObject").gameObject;
        //renOBJ[0] = Parent.GetChild(0).gameObject;
        getsofivisetposition();
    }

    public void getsofivisetposition()//設置台のソフビが設置できるポイントを掴む
    {
        for(int i=0;i<renCount;i++)
        {
            renOBJ[i] = Parent.GetChild(i).gameObject;
            for (int j = 0; j < Parent.GetChild(i).gameObject.transform.childCount; j ++)
            {

                setpositionOBJ[i,j] = renOBJ[i].transform.GetChild(j).gameObject;//孫objの取得
               // Debug.Log(setpositionOBJ[i, j]);

            }


        }


    }


    void Update()
    {
        
    }
    public void selectSofviSet()//選んでいるソフビのデータをセットする
    {
        
    }
}
