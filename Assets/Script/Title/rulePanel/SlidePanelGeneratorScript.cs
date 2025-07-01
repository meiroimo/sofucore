using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePanelGeneratorScript : MonoBehaviour
{
    [Header("生成パネルprefab")] public GameObject panelPrefabOBJ;
    [Header("生成する数")] public int panelCount = 0;
    [Header("親オブジェクト")]public Transform parent;
    [Header("パネルの横サイズ")]public float panelSize;
    Vector2 parentSize; //親オブジェクト

    [HideInInspector]   //生成したパネルを保持
    public List<GameObject> generatedPanels = new List<GameObject>();
    float startPosX;    //パネルを設置するポジションX

    //パネル生成
    public void GeneratePanels()
    {
        ClearPanels();  //初期化

        for(int i = 0; i < panelCount; i++)
        {
            GameObject panel = Instantiate(panelPrefabOBJ, parent);

            // 横にずらして並べる（例：2単位間隔）
            panel.transform.localPosition = new Vector3(startPosX, 0, 0);
            startPosX += panelSize;
            // リストに追加して管理
            generatedPanels.Add(panel);
        }
    }

    // すでに生成されているパネルを全て削除する
    public void ClearPanels()
    {
        foreach (GameObject panel in generatedPanels)
        {
            if (panel != null)
                DestroyImmediate(panel); // 実行中じゃないからDestroyではなくDestroyImmediateを使用
        }
        //親パネルのサイズ変更
        parentSize = panelPrefabOBJ.GetComponent<RectTransform>().sizeDelta;
        panelSize = parentSize.x;
        parentSize.x = panelSize * panelCount;
        parent.GetComponent<RectTransform>().sizeDelta = parentSize;
        //子にするパネルの初期位置
        startPosX = -panelSize / 2 * (panelCount-1);
        //親パネルの初期位置
        parent.GetComponent<RectTransform>().localPosition = new Vector3(-startPosX, 0, 0);
        generatedPanels.Clear(); // リストも空
    }
}
