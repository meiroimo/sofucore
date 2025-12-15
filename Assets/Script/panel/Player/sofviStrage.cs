using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sofviSotrage : MonoBehaviour
{
    //[Header("獲得ソフビ格納リスト")] public static List<SofviDataScriptable> sofviStrageList = new List<SofviDataScriptable>(MAXSofviCount);//ソフビのストレージ
    [Header("獲得ソフビ格納リスト")] public static List<SoftVinilData> sofviStrageList = new List<SoftVinilData>(MAXSofviCount);//ソフビのストレージ

    public static int MAXSofviCount = 15;//ストレージの最大数
    public static bool ListUpdate=false;
   

    void Start()
    {

        for (int i = 0; i < 18; i++)
        {
            sofviStrageList.Add(null);
        }
    }


    void Update()
    {
    }
  
}
