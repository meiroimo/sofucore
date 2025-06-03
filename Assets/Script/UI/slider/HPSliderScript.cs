using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSliderScript : MonoBehaviour
{
    [SerializeField, Header("HPバー")] Slider HPSlider;
    [SerializeField, Header("最大体力テキスト")] Text maxhealthText;

    PlayerStatus_Script playerStatus_Script;

    float initMaxHealth;    //初期体力
    float maxHealth;        //現在の最大体力
    float nowHealth;        //現在の体力

    void Start()
    {
        playerStatus_Script = GetComponent<PlayerStatus_Script>();
        maxHealth = playerStatus_Script.player_MaxHealth;
        initMaxHealth = maxHealth;
        nowHealth = maxHealth;
        SetHealthUI();
        setHealthText();

    }

    //UI(slider)に反映
    public void SetHealthUI()
    {
        float HPValue = nowHealth / maxHealth;

        HPSlider.value = HPValue;
    }

    //最大値をセット＋UI反映
    public void SetMaxHealth(float h_maxHealth)
    {
        maxHealth = h_maxHealth;
        setHealthText();
        SetHealthUI();
    }

    //現在値をセット＋UI反映
    public void SetNowHealth(float h_nowhealth)
    {
        nowHealth = h_nowhealth;
        SetHealthUI();
    }

    //最大値を渡す
    public float GetMaxHealth()
    {
        return maxHealth;
    }

    //現在値を渡す
    public float GetNowHealth()
    {
        return nowHealth;
    }

    void setHealthText()
    {
        float addHealth = maxHealth - initMaxHealth;

        maxhealthText.text = maxHealth + "(" + addHealth + ")";
    }
}
