using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleChangePanelScript : MonoBehaviour
{
    [SerializeField, Header("���ꂼ��̃p�l��")] GameObject[] changePanel;

    public enum PanelName
    {
        SELECT_PANEL,       //�Z���N�g���
        GAME_HOW_TO_PANEL,  //�V�ѕ����
        SETTING_PANEL,      //�ݒ���
        EXIT                //�I�����
    }

    void Start()
    {
        //�Z���N�g��ʂ�t���Ă���
        ChangeButtonPanel((int)PanelName.SELECT_PANEL); 
    }

    //�����̒l�̃p�l����t���A����ȊO������
    public void ChangeButtonPanel(int nextPanel)
    {
        for(int i = 0; i < changePanel.Length; i++)
        {
            if (i == (int)nextPanel)
            {
                changePanel[i].SetActive(true);
            }
            else
            {
                changePanel[i].SetActive(false);
            }
        }
    }
}
