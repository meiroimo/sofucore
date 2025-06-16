using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEffectScript : MonoBehaviour
{
    [SerializeField, Header("�G�t�F�N�g�I�u�W�F�N�g")] GameObject[] playerEffect;

    public enum EffectName
    {
        AVOIDANCE = 0,
        SMOKE,
        SLASH,
        AURA
    }

    void Start()
    {
        Init();
    }

    void Update()
    {

    }

    //�S����ғ��ɂ���
    private void Init()
    {
        for (int i = 0; i < playerEffect.Length; i++)
        {
            playerEffect[i].SetActive(false);
        }
    }

    public void PlayEffect(int effectNo)
    {
        playerEffect[effectNo].SetActive(true);

    }

    public void StopSmokeEffect()
    {
        playerEffect[(int)EffectName.SMOKE].SetActive(false);
    }

    public void StopAvoidanceEffect()
    {
        playerEffect[(int)EffectName.AVOIDANCE].SetActive(false);
    }
}
