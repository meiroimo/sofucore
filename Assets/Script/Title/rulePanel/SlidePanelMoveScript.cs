using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePanelMoveScript : MonoBehaviour
{
    [SerializeField, Header("スライドスピード")] float speed;
    [SerializeField] SlidePanelGeneratorScript generatorScript;

    RectTransform rectTransform;    //スライドパネルのトランスフォーム
    float goalPosX;                 //スライドするときの目標のポジション
    Vector3 panelPos;               //現在のパネルのポジション
    int nowPanelCount;              //現在の表示されているのが何枚目か
    int maxPanelCount;              //パネルの最大枚数
    bool isAddMove;                 //右に移動するか　true:移動する false;移動しない
    bool isReduceMove;              //左に移動するか　true:移動する false;移動しない
    float panelSize;                //1パネルの横サイズ
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        panelPos = rectTransform.localPosition;
        isAddMove = false;
        isReduceMove = false;
        nowPanelCount = 0;
        goalPosX = rectTransform.localPosition.x;
        panelSize = generatorScript.panelPrefabOBJ.GetComponent<RectTransform>().sizeDelta.x;
        maxPanelCount = generatorScript.panelCount;
    }

    void Update()
    {
        if (!isAddMove && !isReduceMove) return;
        if (isAddMove)
        {
            if (goalPosX < panelPos.x)
            {
                panelPos.x -= speed;
                rectTransform.localPosition = panelPos;
            }
            else
            {
                isAddMove = false;
                panelPos.x = goalPosX;
                rectTransform.localPosition = panelPos;

            }

        }
        if (isReduceMove)
        {
            if (goalPosX > panelPos.x)
            {
                panelPos.x += speed;
                rectTransform.localPosition = panelPos;
            }
            else
            {
                isReduceMove = false;
                panelPos.x = goalPosX;
                rectTransform.localPosition = panelPos;

            }

        }

    }
    //右が押される
    public void nextSlideBotton()
    {
        nowPanelCount++;
        if (maxPanelCount <= nowPanelCount)
        {
            nowPanelCount = maxPanelCount - 1;
            return;
        }
        goalPosX -= panelSize;
        isAddMove = true;

    }
    //左が押される
    public void retunSlideBotton()
    {
        nowPanelCount--;
        if (nowPanelCount < 0)
        {
            nowPanelCount = 0;
            return;
        }
        goalPosX += panelSize;
        isReduceMove = true;

    }

}
