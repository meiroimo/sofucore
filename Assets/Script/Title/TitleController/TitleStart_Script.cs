using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TitleController_Script;

/// <summary>
/// スタート画面に関する処理を書くスクリプト
/// </summary>
public class TitleStart_Script : MonoBehaviour
{
    private TitleController_Script titleController;
    private FlowerGuard2 inputActions;

    private void Awake()
    {
        titleController = GetComponent<TitleController_Script>();
        inputActions = new FlowerGuard2();
        inputActions.Enable();

    }

    /// <summary>
    /// スタート画面 → セレクト画面へ 遷移する関数 <br/>
    /// マウス左クリックでセレクト画面へ遷移<br/>
    /// START → SELECT
    /// </summary>
    public void StartProcessing()
    {
        // ボタンが押されていたら実行
        if (inputActions.UI.Submit.triggered)
        {
            titleController.subScene = TitleSubScene.SELECT;
            titleController.IndicationTitleUI();
        }
    }
}
