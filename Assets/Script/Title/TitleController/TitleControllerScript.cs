using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TitleControllerScript : MonoBehaviour
{
    [SerializeField] GameObject startOBJ;//タイトルパネル

    [Header("最初に選択されるボタン")]
    [SerializeField] private Button firstButton;//最初に選択されるボタン
    [SerializeField] private Button gameEndButton;//止めるボタン
    [SerializeField] private Button settingButton;//設定ボタン
    [SerializeField] private Button explanationButton;//遊び方ボタン

    enum MouseClick
    {
        LEFT = 0,   //左クリック
        RIGHT,      //右クリック
        MIDDLE
    }

    void Start()
    {
        if (!startOBJ.activeSelf) startOBJ.SetActive(true);//タイトル画面を付ける

    }

    void Update()
    {
        CheakStartPanel();
    }

    //タイトル画面でクリックorボタン押下されたらタイトル画面消す
    void CheakStartPanel()
    {
        if (!startOBJ.activeSelf) return;

        // マウス左クリック
        if (Mouse.current?.leftButton.wasPressedThisFrame == true)
        {
            startOBJ.SetActive(false);
            StartCoroutine(SelectFirstButtonNextFrame(firstButton));
            return;
        }

        // コントローラー/キーボードのSubmitアクション
        if (Keyboard.current?.enterKey.wasPressedThisFrame == true ||
            Keyboard.current?.spaceKey.wasPressedThisFrame == true ||
            Gamepad.current?.buttonSouth.wasPressedThisFrame == true) //Aボタン(PSなら×)
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
    /// 止めるボタンを押したとき
    /// </summary>
    public void OnSelectGameEndButton()
    {
        StartCoroutine(SelectFirstButtonNextFrame(gameEndButton));
    }

    /// <summary>
    /// 設定ボタンを押したとき
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
    /// 操作するボタンを選択する
    /// ボタンをキーボードやコントローラーで操作する
    /// </summary>
    /// <param name="button"></param>
    /// <returns></returns>
    private IEnumerator SelectFirstButtonNextFrame(Button button)
    {
        yield return null; // 1フレーム待つ
        if (button != null)
        {
            EventSystem.current.SetSelectedGameObject(null); //念のため一回解除
            EventSystem.current.SetSelectedGameObject(button.gameObject);
        }
    }


}
