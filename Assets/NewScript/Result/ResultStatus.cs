using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultStatus : MonoBehaviour
{
    [Header("�\������X�e�[�^�X�e�L�X�g�i���ԂɁj")]
    public Text[] statusTexts;

    [Header("�N���A���Q�[���I�[�o�[�̃e�L�X�g")]
    [SerializeField] Text resultText;

    void Start()
    {
        if (ResultClear.Instance.isGameClear)
        {
            resultText.text = "�Q�[���N���A�I";
        }
        else
        {
            resultText.text = "�Q�[���I�[�o�[�c";
        }

        var data = DataManager.Instance.data;

        string[] labels = 
        {
            "�U����: ",
            "�̗�: ",
            "�X�s�[�h: ",
            "�X�^�~�i: ",
            "�U���͈�: ",
            "�X�L���`���[�W: "
            // �K�v�ɉ����đ��̃X�e�[�^�X���������ɒǉ�
        };

        float[] values =
        {
            PlayerStatusCache.lastattackPower,
            PlayerStatusCache.lastmaxHealth,
            PlayerStatusCache.lastspeed,
            PlayerStatusCache.lastMaxSutamina,
            PlayerStatusCache.lastAttack_Range,
            PlayerStatusCache.lastSkill_Charge
            // �K�v�ɉ����đ��̃f�[�^���ǉ�
        };

        string[] unit =
        {
            "",
            "",
            "",
            "",
            "%",
            "s"
        };

        for (int i = 0; i < statusTexts.Length && i < labels.Length; i++)
        {
            statusTexts[i].text = labels[i] + values[i].ToString("F0") + unit[i];
        }
    }
}
