using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class transitionScript : MonoBehaviour
{
    [SerializeField, Header("��ʂ��S��������悤�ɂȂ�T�C�Y")] int MaxScale;
    [SerializeField, Header("1�t���[���ɂł�������l")] float addScale;
    [SerializeField, Header("�O���X�N���v�g����G��@true:FadeIn false:FadeOut")] public bool isFadein;
    [SerializeField, Header("�X�P�[���G��I�u�W�F�N�g��transform")] Transform unmaskTransform;
    [SerializeField] loadingScript Loading;
    float nowScale;

    public void Start()
    {
        if (isFadein)
        {
            nowScale = MaxScale;
            addScale *= -1;
        }
        else nowScale = 0;

    }

    void Update()
    {

        nowScale += addScale;

        unmaskTransform.localScale = new Vector3(nowScale, nowScale, nowScale);

        if (MaxScale <= nowScale) gameObject.SetActive(false);
        if (nowScale <= 0 && isFadein) 
        {
            Loading.NextScene();
            gameObject.SetActive(false);
        }
    }

}
