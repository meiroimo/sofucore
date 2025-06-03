using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveatExitGame_Script : MonoBehaviour
{
    private TitleController_Script _title;
    public GameObject CavantPanel;

    private void Awake()
    {
        _title = GetComponent<TitleController_Script>();
    }

    /// <summary>
    /// 止めるボタンを押す<br/>
    /// ゲーム終了選択パネルを表示
    /// </summary>
    public void OnCavantPanel()
    {
        _title.SelectedEndMenu();
        CavantPanel.SetActive(true);
    }
    /// <summary>
    /// ゲーム終了選択パネルのいいえボタンを押す<br/>
    /// セレクト画面に戻る
    /// </summary>
    public void OffCavantPanel()
    {
        _title.SelectedMenu();
        CavantPanel.SetActive(false);
    }
}
