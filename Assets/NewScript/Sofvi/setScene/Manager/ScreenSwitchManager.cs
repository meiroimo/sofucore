using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSwitchManager : MonoBehaviour
{
    public SetSofviManeger SetSofviManegerSc;
    public GameObject UIManagerObject;
    private UIManager UIManegeScript;
    public GameObject CameraManegerObject;
    private CameraManager CameraManegerScript;
    public bool SetFlg = false;//äJÇ¢ÇƒÇ¢ÇÈÇ©îªíË

    private PlayPauseMenu pauseMenu;


    void Start()
    {

        UIManagerObject = GameObject.Find("UIManeger");
        UIManegeScript = UIManagerObject.GetComponent<UIManager>();
        CameraManegerObject = GameObject.Find("CameraManager");
        CameraManegerScript = CameraManegerObject.GetComponent<CameraManager>();

        pauseMenu = FindObjectOfType<PlayPauseMenu>();

    }
  
    // Update is called once per frame
    void Update()
    {
        PauseKey();
    }

    public void OpenSetScene()
    {
        UIManegeScript.UIOpen();
        CameraManegerScript.changeCamera();
        SetFlg = true;
    }

    public void CloseSetScene()
    {
        UIManegeScript.UIClose();
        CameraManegerScript.changeCamera();
        SetFlg = false;

    }

    private void PauseKey()//ÉLÅ[ì¸óÕÇìæÇÈä÷êî
    {
        if (Input.GetKeyDown(KeyCode.Tab))//tabâüÇµÇΩÇÁ
        {
            if (pauseMenu.IsPaused) return;
            if (!SetFlg)
            {
                Time.timeScale = 0f;
                OpenSetScene();
            }
            else
            {
                if(!SetSofviManegerSc.selectSoftVinylData.SofviData.selectCheck)
                {
                    Time.timeScale = 1f;
                    SetSofviManegerSc.selectSoftVinylData.SofviData = SetSofviManegerSc.selectSoftVinylData.SofviData.copy();
                    SetSofviManegerSc.selectSoftVinylData.SofviData.ResetParameter();
                    SetSofviManegerSc.TextWindowManegerSc.OnHoverExit();
                    CloseSetScene();


                }
            }
        }
    }
}
