using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayPauseMenu : MonoBehaviour
{
    public ScreenSwitchManager ScreenSwitchManagerSc;//画面切り替えスクリプト
    public GameObject settingsMenu;
    private bool isPaused = false;

    public bool IsPaused { get => isPaused; set => isPaused = value; }

    private void Start()
    {
        settingsMenu.SetActive(isPaused);
    }

    void Update()
    {
        // Escキーを押したら切り替え,tabメニューを開いているときは押せない
        if (Keyboard.current.escapeKey.wasPressedThisFrame&&!ScreenSwitchManagerSc.SetFlg)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        settingsMenu.SetActive(isPaused);

        //メニューの表示切り替え
        if (isPaused == true)
        {
            settingsMenu.SetActive(true);
        }
        else
        {
            settingsMenu.SetActive(false);
        }

        //ゲーム全体の時間を止める
        if (isPaused == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }

    public void PauseLoadTitleScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene_Mei");

    }
}

