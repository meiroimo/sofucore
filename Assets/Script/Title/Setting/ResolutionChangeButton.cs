using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionChangeButton : MonoBehaviour
{
    //public GameObject screenButton;

    private void Awake()
    {
        //screenButton.SetActive(true);
        SetResolution720p();
    }

    public void SetResolution(int width, int height)
    {
        // ��3�����ɂ̓t���X�N���[�����ǂ������w��ł��܂��B
        // ���݂̃t���X�N���[����Ԃ��ێ��������ꍇ��Screen.fullScreen��n���܂��B
        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    public void SetResolution1080p()
    {
        SetResolution(1920, 1080);
    }

    public void SetResolution720p()
    {
        SetResolution(1280, 720);
    }

    public void OnClickFullScreenMode()
    {
        // �t���X�N���[�����[�h�ɐ؂�ւ��܂�
        Screen.fullScreen = true;
        //screenButton.SetActive(true);
    }

    public void OnClickWindowMode()
    {
        // �t���X�N���[�����[�h�ɐ؂�ւ��܂�
        Screen.fullScreen = false;
        //screenButton.SetActive(false);
    }
}
