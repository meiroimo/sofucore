using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject GameMainCanvas;//�Q�[�����C���V�[���L�����p�X
    [SerializeField] private GameObject SetCanvas;//�ݒu�V�[���L�����p�X

    //[SerializeField] private GameObject PanelUIBox;//�p�l��UIOBJ
    //[SerializeField] private GameObject PlayingUIBox;//�v���C���OUIOBJ



    bool SetUIFlg;//�J���Ă��邩����
    void Start()
    {
        var gameObject = GameObject.Find("SetSceneCanvas");
        if (gameObject != null)
        {
            GameMainCanvas = GameObject.Find("GameMainCanvas");
            SetCanvas = GameObject.Find("SetSceneCanvas");

            SetUIFlg = true;
            SetCanvas.SetActive(false);//���߂̓Z�b�g�V�[����UI�͔�\��
        }
      

    }

    // Update is called once per frame
    void Update()
    {
       // PauseKey();
    }
    private void PauseKey()//�L�[���͂𓾂�֐�
    {
        if (Input.GetKeyDown(KeyCode.Tab))//tab��������
        {
            if (SetUIFlg)
            {
                UIOpen();

            }
            else
            {
                UIClose();
            }
        }
    }
    public void UIOpen()//�ݒu�V�[��UI���J���֐�
    {
        SetUIFlg = false;
        SetCanvas.SetActive(true);
        GameMainCanvas.SetActive(false);
    }

    public void UIClose()//�ݒu�V�[��UI�����֐�
    {
        SetUIFlg = true;
        SetCanvas.SetActive(false);
        GameMainCanvas.SetActive(true);


    }

}
