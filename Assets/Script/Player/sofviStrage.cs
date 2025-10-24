using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.Mesh;

public class sofviStrage : MonoBehaviour
{
    [Header("獲得ソフビ格納リスト")] public static List<softVinyl> sofviStrageList = new List<softVinyl>();//ソフビのストレージ
    [Header("獲得ソフビ個数")] public int sofviStrageListConut;
    public GameObject testdata;//テストデータオブジェクト
    
   

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
