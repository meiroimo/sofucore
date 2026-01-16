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

    private float nextStaminaDecreaseTime;
    private float staminaDecrease = 1;
    float staminaHeal;

    public void Init()
    {
        playerStatus_Script = GetComponent<PlayerStatus_Script>();
        initMaxStamina = playerStatus_Script.player_MaxSutamina;
        maxStamina = playerStatus_Script.player_MaxSutamina;
        nowStamina = maxStamina;
        SetStaminaUI();
        setStaminaText();
        staminaHeal = maxStamina / 10.0f / 60.0f;

        //InvokeRepeating("メソッド名", 開始までの遅延時間, 繰り返し間隔);
        //InvokeRepeating(nameof(HealStamina), 1.0f, 1.0f);

    }

    public void MaxStaminaUpdate()
    {
        maxStamina = playerStatus_Script.player_MaxSutamina;
    }

    //UI(slider)に反映
    public void SetStaminaUI()
    {
        float staminaValue = nowStamina / maxStamina;

        staminaSlider.value = staminaValue;
    }

    //最大値をセット＋UI反映
    public void SetMaxStamina(float h_maxStamina)
    {
        maxStamina = h_maxStamina;

        setStaminaText();
        SetStaminaUI();
    }

    //現在値をセット＋UI反映
    public void SetNowStamina(float h_nowStamina)
    {
        nowStamina = h_nowStamina;
        setStaminaText();
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

    void setStaminaText()
    {
        maxStaminaText.text = maxStamina + "(" + playerStatus_Script.add_Player_MaxSutamina + ")";
    }

    public void HealStamina()
    {
        if (Time.time > nextStaminaDecreaseTime)
        {
            nextStaminaDecreaseTime = Time.time + staminaDecrease;
            float currentStamina = GetNowStamina();
            currentStamina += staminaHeal;
            if (currentStamina > maxStamina)
            {
                currentStamina = maxStamina;
            }
            SetNowStamina(currentStamina);
        }

    }
}
