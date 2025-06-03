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
    /// �~�߂�{�^��������<br/>
    /// �Q�[���I���I���p�l����\��
    /// </summary>
    public void OnCavantPanel()
    {
        _title.SelectedEndMenu();
        CavantPanel.SetActive(true);
    }
    /// <summary>
    /// �Q�[���I���I���p�l���̂������{�^��������<br/>
    /// �Z���N�g��ʂɖ߂�
    /// </summary>
    public void OffCavantPanel()
    {
        _title.SelectedMenu();
        CavantPanel.SetActive(false);
    }
}
