using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSliderScript : MonoBehaviour
{
    [SerializeField, Header("スタミナバー")] Slider staminaSlider;
    [SerializeField, Header("最大体力テキスト")] Text maxStaminaText;


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
        //InvokeRepeating("メソッド名", 開始までの遅延時間, 繰り返し間隔);
        InvokeRepeating(nameof(HealStamina), 1.0f, 1.0f);

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

        setHealthText();

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

    void setHealthText()
    {

        maxStaminaText.text = maxStamina + "(" + playerStatus_Script.add_Player_MaxSutamina + ")";
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
