using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultStatus : MonoBehaviour
{
    [Header("�\������X�e�[�^�X�e�L�X�g�i���ԂɁj")]
    public Text[] statusTexts;

    void Start()
    {
        var data = DataManager.Instance.data;

        string[] labels = {
            "�U����: ",
            "�ő�̗�: ",
            "�X�s�[�h: "
            // �K�v�ɉ����đ��̃X�e�[�^�X���������ɒǉ�
        };

        float[] values = {
            data.attackPower,
            data.maxHealth,
            data.player_Speed
            // �K�v�ɉ����đ��̃f�[�^���ǉ�
        };

        for (int i = 0; i < statusTexts.Length && i < labels.Length; i++)
        {
            statusTexts[i].text = labels[i] + values[i].ToString("F0");
        }
    }
}
