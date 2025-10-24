using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TitleControllerScript : MonoBehaviour
{
    [SerializeField] GameObject startOBJ;//�^�C�g���p�l��

    [Header("�ŏ��ɑI�������{�^��")]
    [SerializeField] private Button firstButton;//�ŏ��ɑI�������{�^��
    [SerializeField] private Button gameEndButton;//�~�߂�{�^��
    [SerializeField] private Button settingButton;//�ݒ�{�^��
    [SerializeField] private Button explanationButton;//�V�ѕ��{�^��

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

    //�^�C�g����ʂŃN���b�Nor�{�^���������ꂽ��^�C�g����ʏ���
    void CheakStartPanel()
    {
        if (!startOBJ.activeSelf) return;

        // �}�E�X���N���b�N
        if (Mouse.current?.leftButton.wasPressedThisFrame == true)
        {
            startOBJ.SetActive(false);
            StartCoroutine(SelectFirstButtonNextFrame(firstButton));
            return;
        }

        // �R���g���[���[/�L�[�{�[�h��Submit�A�N�V����
        if (Keyboard.current?.enterKey.wasPressedThisFrame == true ||
            Keyboard.current?.spaceKey.wasPressedThisFrame == true ||
            Gamepad.current?.buttonSouth.wasPressedThisFrame == true) //A�{�^��(PS�Ȃ�~)
        {
            startOBJ.SetActive(false);
            StartCoroutine(SelectFirstButtonNextFrame(firstButton));
            return;
        }


        //if (Input.GetMouseButtonDown((int)MouseClick.LEFT))
        //{
        //    startOBJ.SetActive(false);
        //}

    }

    /// <summary>
    /// �~�߂�{�^�����������Ƃ�
    /// </summary>
    public void OnSelectGameEndButton()
    {
        StartCoroutine(SelectFirstButtonNextFrame(gameEndButton));
    }

    /// <summary>
    /// �ݒ�{�^�����������Ƃ�
    /// </summary>
    public void OnSelectGameSettingButton()
    {
        StartCoroutine(SelectFirstButtonNextFrame(settingButton));
    }

    public void OnSelectExplanationButton()
    {
        StartCoroutine(SelectFirstButtonNextFrame(explanationButton));
    }

    /// <summary>
    /// ���삷��{�^����I������
    /// �{�^�����L�[�{�[�h��R���g���[���[�ő��삷��
    /// </summary>
    /// <param name="button"></param>
    /// <returns></returns>
    private IEnumerator SelectFirstButtonNextFrame(Button button)
    {
        yield return null; // 1�t���[���҂�
        if (button != null)
        {
            EventSystem.current.SetSelectedGameObject(null); //�O�̂��߈�����
            EventSystem.current.SetSelectedGameObject(button.gameObject);
        }
    }


}
