using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePanelMoveScript : MonoBehaviour
{
    [SerializeField, Header("�X���C�h�X�s�[�h")] float speed;
    [SerializeField] SlidePanelGeneratorScript generatorScript;

    RectTransform rectTransform;    //�X���C�h�p�l���̃g�����X�t�H�[��
    float goalPosX;                 //�X���C�h����Ƃ��̖ڕW�̃|�W�V����
    Vector3 panelPos;               //���݂̃p�l���̃|�W�V����
    int nowPanelCount;              //���݂̕\������Ă���̂������ڂ�
    int maxPanelCount;              //�p�l���̍ő喇��
    bool isAddMove;                 //�E�Ɉړ����邩�@true:�ړ����� false;�ړ����Ȃ�
    bool isReduceMove;              //���Ɉړ����邩�@true:�ړ����� false;�ړ����Ȃ�
    float panelSize;                //1�p�l���̉��T�C�Y
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
    //�E���������
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
    //�����������
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
