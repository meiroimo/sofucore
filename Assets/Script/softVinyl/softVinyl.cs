using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ソフビ1体のパラメータデータを保持（モデル、スキル、テーマ、バフ値など）。
/// UIボタンや設置場所オブジェクトにも付与されている。
/// </summary>
public class softVinyl : MonoBehaviour
{
   // [Header("ソフビデータ")] public SofviDataScriptable SofviDataScriptable;
    [Header("ソフビデータ")] public SoftVinilData SofviData;

    void Start()
    {
        if (SofviData == null)
        {
            SofviData = new SoftVinilData();
            SofviData.ResetParameter();
        }
    }

  
}
