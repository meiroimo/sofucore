using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofviVinylList : MonoBehaviour
{
    Transform Parent;//親オブジェクト
    public GameObject[] children;//子オブジェクトの配列
    public softVinyl[] childrensoftVinyl;//子オブジェクトのソフビスクリプトの配列
    public PanelButton[] childrenPanelScript;//子オブジェクトのパネルスクリプトの配列

    public sofviStrage sofviStrage;//ストレージ配列を参照
    public int storageCount;//ストレージ参照の個数
    public List<softVinyl> softVinylData;//ソフビデータをストレージからコピー

    void Start()
    {
        Parent = this.gameObject.transform;
      
        int childCount = Parent.childCount;
        //  Debug.Log(aaa);
        children = new GameObject[childCount];
        childrensoftVinyl = new softVinyl[childCount];
        childrenPanelScript = new PanelButton[childCount];

        Storechildren();
    }

    void Storechildren()//子オブジェクトの取得
    {
        // 子を順番に配列に格納
        for (int i = 0; i < Parent.childCount; i++)
        {
            children[i] = Parent.GetChild(i).gameObject;
            childrensoftVinyl[i] = children[i].gameObject.GetComponent<softVinyl>();
            
            childrenPanelScript[i] = children[i].gameObject.GetComponent<PanelButton>();
        }
    }
    void setSofiDataButton()//各ボタンにソフビデータをセット
    {




        for (int i = 0; i < 105; i++)
        {
            //個数分ボタンにソフビデータをセット
            if (i < sofviStrage.sofviStrageListConut)
            {
               

                childrensoftVinyl[i].skill = sofviStrage.sofviStrageList[i].skill;
                childrensoftVinyl[i].theme = sofviStrage.sofviStrageList[i].theme;
                childrensoftVinyl[i].sofviImage = sofviStrage.sofviStrageList[i].sofviImage;
                childrensoftVinyl[i].cost = sofviStrage.sofviStrageList[i].cost;
                childrensoftVinyl[i].ListNumber = i;//配列番号を付与

                childrensoftVinyl[i].sofviName = sofviStrage.sofviStrageList[i].sofviName;
                childrensoftVinyl[i].buffMainstatus = sofviStrage.sofviStrageList[i].buffMainstatus;
                childrensoftVinyl[i].buffSubstatus1 = sofviStrage.sofviStrageList[i].buffSubstatus1;
                childrensoftVinyl[i].buffSubstatus2 = sofviStrage.sofviStrageList[i].buffSubstatus2;
                childrensoftVinyl[i].buffSubstatus3 = sofviStrage.sofviStrageList[i].buffSubstatus3;

                childrensoftVinyl[i].Buffparameter = sofviStrage.sofviStrageList[i].Buffparameter;
                childrensoftVinyl[i].Buffparameter1 = sofviStrage.sofviStrageList[i].Buffparameter1;
                childrensoftVinyl[i].Buffparameter2 = sofviStrage.sofviStrageList[i].Buffparameter2;
                childrensoftVinyl[i].Buffparameter3 = sofviStrage.sofviStrageList[i].Buffparameter3;

                childrensoftVinyl[i].buffName = sofviStrage.sofviStrageList[i].buffName;
                childrensoftVinyl[i].buffName1 = sofviStrage.sofviStrageList[i].buffName1;
                childrensoftVinyl[i].buffName2 = sofviStrage.sofviStrageList[i].buffName2;
                childrensoftVinyl[i].buffName3 = sofviStrage.sofviStrageList[i].buffName3;

            }

        }

       

    }
    // Update is called once per frame
    void Update()
    {
       setSofiDataButton();
     
    }
}
