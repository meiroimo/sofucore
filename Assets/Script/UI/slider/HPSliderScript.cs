using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSliderScript : MonoBehaviour
{
    [SerializeField, Header("HP�o�[")] Slider HPSlider;

    PlayerStatus_Script playerStatus_Script;

    float maxHealth;        //���݂̍ő�̗�
    float nowHealth;        //���݂̗̑�
    

    void Start()
    {
        playerStatus_Script = GetComponent<PlayerStatus_Script>();
        maxHealth = playerStatus_Script.player_MaxHealth;
        nowHealth = maxHealth;
        SetHealthUI();

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

}
