using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelUIController : MonoBehaviour
{
    [SerializeField] private GameObject PanelUIBox;//�p�l��UIOBJ
    [SerializeField] private GameObject PlayingUIBox;//�v���C���OUIOBJ



    bool panelUIFlg;//�J���Ă��邩����
    void Start()
    {
        panelUIFlg = true;
        PanelUIBox.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        PauseKey();
    }
    private void PauseKey()//�L�[���͂𓾂�֐�
    {
        if (Input.GetKeyDown(KeyCode.Tab) )//tab��������
        {
            if (panelUIFlg)
            {
                UIOpen();
               
            }
            else
            {
                UIClose();
            }
        }
    }
    private void UIOpen()//�p�l���E�B���h�E���J���֐�
    {
        panelUIFlg = false;
        Time.timeScale = 0;  // ���Ԓ�~
        PanelUIBox.SetActive(true);
        PlayingUIBox.SetActive(false);
    }

    public void UIClose()//�p�l���E�B���h�E�����֐�
    {
        panelUIFlg = true;
        Time.timeScale = 1;  // �ĊJ
        PanelUIBox.SetActive(false);
        PlayingUIBox.SetActive(true);


    }

}
