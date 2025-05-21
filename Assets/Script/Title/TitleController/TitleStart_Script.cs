using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TitleController_Script;

/// <summary>
/// �X�^�[�g��ʂɊւ��鏈���������X�N���v�g
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
    /// �X�^�[�g��� �� �Z���N�g��ʂ� �J�ڂ���֐� <br/>
    /// �}�E�X���N���b�N�ŃZ���N�g��ʂ֑J��<br/>
    /// START �� SELECT
    /// </summary>
    public void StartProcessing()
    {
        // �{�^����������Ă�������s
        if (inputActions.UI.Submit.triggered)
        {
            titleController.subScene = TitleSubScene.SELECT;
            titleController.IndicationTitleUI();
        }
    }
}
