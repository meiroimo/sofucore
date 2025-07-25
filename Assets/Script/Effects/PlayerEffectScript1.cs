using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEffectScript : MonoBehaviour
{
    [SerializeField, Header("エフェクトオブジェクト")] GameObject[] playerEffect;

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

    //全部非稼働にする
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

    public void StopEffect(int effectNo)
    {
        playerEffect[effectNo].SetActive(false);
    }
}
