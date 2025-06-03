using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSliderScript : MonoBehaviour
{
    [SerializeField, Header("スタミナバー")] Slider staminaSlider;

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

    //UI(slider)に反映
    public void SetStaminaUI()
    {
        float staminaValue = nowStamina / maxStamina;

        staminaSlider.value = staminaValue;
    }

    //最大値をセット＋UI反映
    public void SetMaxStamina(float h_maxHealth)
    {
        maxStamina = h_maxHealth;

        SetStaminaUI();
    }

    //現在値をセット＋UI反映
    public void SetNowStamina(float h_nowhealth)
    {
        nowStamina = h_nowhealth;
        SetStaminaUI();
    }

    //最大値を渡す
    public float GetMaxStamina()
    {
        return maxStamina;
    }

    //現在値を渡す
    public float GetNowStamina()
    {
        return nowStamina;
    }
}
