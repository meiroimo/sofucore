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
        // 第3引数にはフルスクリーンかどうかを指定できます。
        // 現在のフルスクリーン状態を維持したい場合はScreen.fullScreenを渡します。
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
        // フルスクリーンモードに切り替えます
        Screen.fullScreen = true;
        //screenButton.SetActive(true);
    }

    public void OnClickWindowMode()
    {
        // フルスクリーンモードに切り替えます
        Screen.fullScreen = false;
        //screenButton.SetActive(false);
    }
}
