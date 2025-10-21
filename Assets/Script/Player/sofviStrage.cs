using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mesh;

public class sofviStrage : MonoBehaviour
{
    [Header("獲得ソフビ格納リスト")] public static List<softVinyl> sofviStrageList = new List<softVinyl>();//ソフビのストレージ
    [Header("獲得ソフビ個数")] public int sofviStrageListConut;
    public GameObject testdata;//テストデータオブジェクト
    
    public void deletelist(int listnumber)
    {
        sofviStrageList.RemoveAt(listnumber);

    }
    public void addSofvi(softVinyl softVinylData)
    {
        var dataobj = new GameObject("SoftVinyl");
        dataobj.transform.parent = this.transform.parent;
        softVinyl sofvidata = dataobj.AddComponent<softVinyl>();
        // softVinyl sofvidata = new softVinyl();//インスタンスの生成が上手くいかない　理由　UnityEngine.Object 系（MonoBehaviour / ScriptableObject）だから だよ。
        //Unity の Object 系は普通の C# オブジェクトと生成ルールが違うので、正しい作り方をしないと “空っぽ” 扱いになって Debug.Log で null に見える。
        Debug.Log(sofvidata);
      //  sofvidata = softVinylData;
        sofvidata.name = softVinylData.name;
        sofvidata.sofvimodel = softVinylData.sofvimodel;
        sofvidata.skill = softVinylData.skill;
        sofvidata.theme = softVinylData.theme;
        sofvidata.buffMainstatus = softVinylData.buffMainstatus;
        sofvidata.buffSubstatus1 = softVinylData.buffSubstatus1;
        sofvidata.buffSubstatus2 = softVinylData.buffSubstatus2;
        sofvidata.buffSubstatus3 = softVinylData.buffSubstatus3;
        sofvidata.Buffparameter = softVinylData.Buffparameter;
        sofvidata.Buffparameter1 = softVinylData.Buffparameter1;
        sofvidata.Buffparameter2 = softVinylData.Buffparameter2;
        sofvidata.Buffparameter3 = softVinylData.Buffparameter3;
        sofvidata.buffName = softVinylData.buffName;
        sofvidata.buffName1 = softVinylData.buffName1;
        sofvidata.buffName2 = softVinylData.buffName2;
        sofvidata.buffName3 = softVinylData.buffName3;
        sofviStrageList.Add(sofvidata);


    }

    void setTestData()
    {
        for (int i = 0; i < testdata.gameObject.transform.childCount; i++)
        {
            //addSofvi(testdata.gameObject.transform.GetChild(i).gameObject.GetComponent<softVinyl>());
        }


    }
    void Start()
    {
        sofviStrageListConut = 0;
    }

    
    void Update()
    {
        sofviStrageListConut = sofviStrageList.Count;
    }
  
}
