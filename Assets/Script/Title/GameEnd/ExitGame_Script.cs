using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame_Script : MonoBehaviour
{
    /// <summary>
    /// �Q�[�����I������
    /// </summary>
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Unity�G�f�B�^�[�ł̓���
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ���ۂ̃Q�[���I������
        Application.Quit();
#endif
    }
}