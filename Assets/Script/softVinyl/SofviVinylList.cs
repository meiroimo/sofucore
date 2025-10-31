using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofviVinylList : MonoBehaviour
{
    Transform Parent;//親オブジェクト
    public GameObject[] children;//子オブジェクトの配列
    public PanelButton[] childrenPanelScript;//子オブジェクトのパネルスクリプトの配列
   public softVinyl[] childrensoftVinyl; //子オブジェクトのパラメータのスクリプト

    public GameObject playerStorage;//ストレージオブジェクト
    public sofviStrage sofviStrageScript;//ストレージ配列を参照
    public int storageCount;//ストレージ参照の個数
    public List<softVinyl> softVinylData;//ソフビデータをストレージからコピー


    void Start()
    {
        playerStorage = GameObject.Find("Player_Storage");
        sofviStrageScript= playerStorage.GetComponent<sofviStrage>();
        Parent = this.gameObject.transform;
      
        int childCount = Parent.childCount;
        children = new GameObject[childCount];
        childrenPanelScript = new PanelButton[childCount];
        childrensoftVinyl = new softVinyl[childCount];
        Storechildren();
      
    }

    void Storechildren()//子オブジェクトの取得
    {
        // 子を順番に配列に格納
        for (int i = 0; i < children.Length; i++)
        {
            children[i] = Parent.GetChild(i).gameObject;
            childrensoftVinyl[i] = children[i].gameObject.GetComponent<softVinyl>();
            children[i].gameObject.GetComponent<PanelButton>().Number = i;
            childrenPanelScript[i] = children[i].gameObject.GetComponent<PanelButton>();
        }
    }
    void setSofiDataButton()//各ボタンにソフビデータをセット
    {
         softVinylData = sofviStrage.sofviStrageList;

        if (softVinylData == null)
        {
           
            Debug.Log("nullだったよ");

        }
        //ストレージに入っているデータ分だけ表示されるボタンのデータ更新
        for (int i = 0; i < softVinylData.Count; i++)
        {
          
            childrensoftVinyl[i].sofvimodel = softVinylData[i].sofvimodel;
            childrensoftVinyl[i].skill = softVinylData[i].skill;
            childrensoftVinyl[i].theme = softVinylData[i].theme;
            childrensoftVinyl[i].ListNumber = softVinylData[i].ListNumber;
            childrensoftVinyl[i].buffSubstatus1 = softVinylData[i].buffSubstatus1;
            childrensoftVinyl[i].buffSubstatus2 = softVinylData[i].buffSubstatus2;
            childrensoftVinyl[i].buffSubstatus3 = softVinylData[i].buffSubstatus3;
            childrensoftVinyl[i].Buffparameter = softVinylData[i].Buffparameter;
            childrensoftVinyl[i].Buffparameter1 = softVinylData[i].Buffparameter1;
            childrensoftVinyl[i].Buffparameter2 = softVinylData[i].Buffparameter2;
            childrensoftVinyl[i].Buffparameter3 = softVinylData[i].Buffparameter3;
           

        }

    }
    // Update is called once per frame
    void Update()
    {
        if(sofviStrage.ListUpdate)
        {
            setSofiDataButton();
            Debug.Log("表示されるソフビのリストを更新");
            sofviStrage.ListUpdate = false;
        }
     
    }
}
