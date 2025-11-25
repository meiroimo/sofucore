using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ストレージ (sofviSotrage) からソフビデータを取得し、一覧UI（子ボタン）に反映する。
/// </summary>
public class SofviVinylList : MonoBehaviour
{
    Transform Parent;//親オブジェクト
    public GameObject[] children;//子オブジェクトの配列
    public PanelButton[] childrenPanelScript;//子オブジェクトのパネルスクリプトの配列
   public softVinyl[] childrensoftVinyl; //子オブジェクトのパラメータのスクリプト

    public int storageCount;//ストレージ参照の個数
    public List<SoftVinilData> softVinylData;//ソフビデータをストレージからコピー


    void Start()
    {
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
    public void setSofiDataButton()//各ボタンにソフビデータをセット
    {

        softVinylData = sofviSotrage.sofviStrageList;


        if (softVinylData == null)
        {
            Debug.Log("nullだったよ");

        }
        //ストレージに入っているデータ分だけ表示されるボタンのデータ更新
        for (int i = 0; i < sofviSotrage.MAXSofviCount; i++)
        {
            if (softVinylData[i] == null) continue;
            childrensoftVinyl[i].SofviData = softVinylData[i];

           
        }

    }
    // Update is called once per frame
    void Update()
    {
        if(sofviSotrage.ListUpdate)
        {
            setSofiDataButton();
            Debug.Log("表示されるソフビのリストを更新");
            sofviSotrage.ListUpdate = false;
        }
     
    }
}
