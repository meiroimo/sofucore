using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSliderScript : MonoBehaviour
{
    [SerializeField, Header("�X�^�~�i�o�[")] Slider staminaSlider;
    [SerializeField, Header("�ő�̗̓e�L�X�g")] Text maxStaminaText;


    PlayerStatus_Script playerStatus_Script;

    float initMaxStamina;
    float maxStamina;
    float nowStamina;

    public void Init()
    {
        playerStatus_Script = GetComponent<PlayerStatus_Script>();
        initMaxStamina = playerStatus_Script.player_MaxSutamina;
        maxStamina = playerStatus_Script.player_MaxSutamina;
        nowStamina = maxStamina;
        SetStaminaUI();
        setHealthText();
        //InvokeRepeating("���\�b�h��", �J�n�܂ł̒x������, �J��Ԃ��Ԋu);
        InvokeRepeating(nameof(HealStamina), 1.0f, 1.0f);

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

        setHealthText();

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

    void setHealthText()
    {
        float addStamina = maxStamina - initMaxStamina;

        maxStaminaText.text = maxStamina + "(" + addStamina + ")";
    }

    void HealStamina()
    {
        float currentStamina = GetNowStamina();
        currentStamina += 3;
        if(currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
        SetNowStamina(currentStamina);
    }
}
