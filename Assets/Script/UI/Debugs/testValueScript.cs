using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testValueScript : MonoBehaviour
{
    [SerializeField]HPSliderScript hpSliderScript;
    [SerializeField]StaminaSliderScript staminaSliderScript;
    [SerializeField] PlayerSkillSlider skillSlider;

    float maxHealth;
    float nowHealth;
    float maxStamina;
    float nowStamina;

    float nowSkillPoint;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            nowHealth = hpSliderScript.GetNowHealth();

            nowHealth -= 20;
            hpSliderScript.SetNowHealth(nowHealth);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            maxStamina = staminaSliderScript.GetMaxStamina();
            nowStamina = staminaSliderScript.GetNowStamina();

            nowStamina -= 20;
            staminaSliderScript.SetNowStamina(nowStamina);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            maxHealth = hpSliderScript.GetMaxHealth();

            maxHealth += 20;
            hpSliderScript.SetMaxHealth(maxHealth);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            maxStamina = staminaSliderScript.GetMaxStamina();

            maxStamina += 20;
            staminaSliderScript.SetMaxStamina(maxStamina);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!skillSlider.isUseSkill()) return;
            nowSkillPoint = skillSlider.getNowSkillPoint();
            nowSkillPoint = 0;
            skillSlider.setNowPoint(nowSkillPoint);

        }

    }
}
