using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMoveEffectScript : MonoBehaviour
{
    [SerializeField] GameObject leftEffect;
    [SerializeField] GameObject rightEffect;
    [SerializeField] GameObject auraEffect;

    void Start()
    {
        leftEffect.SetActive(false);
        rightEffect.SetActive(false);
    }

    public void StartLeftEffect()
    {
        leftEffect.SetActive(false);
        leftEffect.SetActive(true);
    }

    public void StartRightEffect()
    {
        rightEffect.SetActive(false);
        rightEffect.SetActive(true);
    }

    public void StopAuraEffect()
    {
        auraEffect.SetActive(false);
    }
}
