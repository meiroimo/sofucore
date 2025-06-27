using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mesh;

public class sofviStrage : MonoBehaviour
{
    [Header("獲得ソフビ格納リスト")] public List<softVinyl> sofviStrageList;//ソフビのストレージ
    [Header("獲得ソフビ個数")] public int sofviStrageListConut;
    public GameObject testdata;//テストデータオブジェクト
    public void deletelist(int listnumber)
    {
        sofviStrageList.RemoveAt(listnumber);
     

    }
    public void addSofvi(softVinyl softVinyldata)
    {
        sofviStrageList.Add(softVinyldata);
      

    }

    void setTestData()
    {
        for (int i = 0; i < testdata.gameObject.transform.childCount; i++)
        {
            addSofvi(testdata.gameObject.transform.GetChild(i).gameObject.GetComponent<softVinyl>());
        }


    }
    void Start()
    {
        sofviStrageListConut = 0;

        //testdata = GameObject.Find("testdeta");
        //setTestData();
    }

    
    void Update()
    {
        sofviStrageListConut = sofviStrageList.Count;


    }
  
}
