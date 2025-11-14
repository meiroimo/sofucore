using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.Mesh;

public class sofviStrage : MonoBehaviour
{
    [Header("獲得ソフビ格納リスト")] public static List<softVinyl> sofviStrageList = new List<softVinyl>(MAXSofviCount);//ソフビのストレージ
    public static int MAXSofviCount = 18;//ストレージの最大数
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
