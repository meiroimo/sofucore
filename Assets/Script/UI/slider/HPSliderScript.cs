using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSliderScript : MonoBehaviour
{
    [SerializeField, Header("HP�o�[")] Slider HPSlider;
    [SerializeField, Header("�ő�̗̓e�L�X�g")] Text maxhealthText;

    PlayerStatus_Script playerStatus_Script;

    float initMaxHealth;    //�����̗�
    float maxHealth;        //���݂̍ő�̗�
    float nowHealth;        //���݂̗̑�

    void Start()
    {
        playerStatus_Script = GetComponent<PlayerStatus_Script>();
        maxHealth = playerStatus_Script.player_MaxHealth;
        initMaxHealth = maxHealth;
        nowHealth = maxHealth;
        SetHealthUI();
        setHealthText();

    }

    //UI(slider)�ɔ��f
    public void SetHealthUI()
    {
        float HPValue = nowHealth / maxHealth;

        HPSlider.value = HPValue;
    }

    //�ő�l���Z�b�g�{UI���f
    public void SetMaxHealth(float h_maxHealth)
    {
        maxHealth = h_maxHealth;
        setHealthText();
        SetHealthUI();
    }

    //���ݒl���Z�b�g�{UI���f
    public void SetNowHealth(float h_nowhealth)
    {
        nowHealth = h_nowhealth;
        SetHealthUI();
    }

    //�ő�l��n��
    public float GetMaxHealth()
    {
        return maxHealth;
    }

    //���ݒl��n��
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
