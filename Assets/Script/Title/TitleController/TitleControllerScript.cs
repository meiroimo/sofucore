using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleControllerScript : MonoBehaviour
{
    [SerializeField] GameObject startOBJ;

    enum MouseClick
    {
        LEFT = 0,   //���N���b�N
        RIGHT,      //�E�N���b�N
        MIDDLE
    }

    void Start()
    {
        if (!startOBJ.activeSelf) startOBJ.SetActive(true);//�^�C�g����ʂ�t����

    }

    void Update()
    {
        CheakStartPanel();
    }

    //�^�C�g����ʂŃN���b�N���ꂽ��^�C�g����ʏ���
    void CheakStartPanel()
    {
        if (!startOBJ.activeSelf) return;

        if (Input.GetMouseButtonDown((int)MouseClick.LEFT))
        {
            startOBJ.SetActive(false);
        }

    }
}
