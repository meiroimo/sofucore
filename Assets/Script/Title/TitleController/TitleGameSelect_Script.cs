using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleGameSelect_Script : MonoBehaviour
{
    private TitleController_Script titleController;
    private TitleGameSetting_Script titleGameSetting;

    private void Awake()
    {
        titleController = GetComponent<TitleController_Script>();
        titleGameSetting = GetComponent<TitleGameSetting_Script>();
    }


    /// <summary>
    /// �{�^����L�[�����������̏������܂Ƃ߂��֐�
    /// </summary>
    public void CheckPushButtonAll()
    {

    }
}
