using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSliderScript : MonoBehaviour
{
    [SerializeField, Header("�X�^�~�i�o�[")] Slider staminaSlider;

    PlayerStatus_Script playerStatus_Script;

    float initMaxStamina;
    float maxStamina;
    float nowStamina;

    void Start()
    {
        playerStatus_Script = GetComponent<PlayerStatus_Script>();
        initMaxStamina = playerStatus_Script.player_MaxSutamina; 
        maxStamina = playerStatus_Script.player_MaxSutamina;
        nowStamina = maxStamina;
        SetStaminaUI();
    }

    //UI(slider)�ɔ��f
    public void SetStaminaUI()
    {
        float staminaValue = nowStamina / maxStamina;

        staminaSlider.value = staminaValue;
    }

    //�ő�l���Z�b�g�{UI���f
    public void SetMaxStamina(float h_maxHealth)
    {
        maxStamina = h_maxHealth;

        SetStaminaUI();
    }

    //���ݒl���Z�b�g�{UI���f
    public void SetNowStamina(float h_nowhealth)
    {
        nowStamina = h_nowhealth;
        SetStaminaUI();
    }

    //�ő�l��n��
    public float GetMaxStamina()
    {
        return maxStamina;
    }

    //���ݒl��n��
    public float GetNowStamina()
    {
        return nowStamina;
    }
}
