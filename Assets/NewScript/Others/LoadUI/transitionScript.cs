using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class transitionScript : MonoBehaviour
{
    [SerializeField, Header("画面が全部見えるようになるサイズ")] int MaxScale;
    [SerializeField, Header("1フレームにでかくする値")] float addScale;
    [SerializeField, Header("外部スクリプトから触る　true:FadeIn false:FadeOut")] public bool isFadein;
    [SerializeField, Header("スケール触るオブジェクトのtransform")] Transform unmaskTransform;
    [SerializeField] loadingScript Loading;
    float nowScale;

    public void Start()
    {
        if (isFadein)
        {
            addScale *= -1;

            maxScale();
        }
        else nowScale = 0;

    }

    void Update()
    {

        nowScale += addScale;

        unmaskTransform.localScale = new Vector3(nowScale, nowScale, nowScale);

        if (MaxScale < nowScale) gameObject.SetActive(false);
        if (nowScale < 0 && isFadein) 
        {
            Loading.NextScene();
            gameObject.SetActive(false);
        }
    }

    public void maxScale()
    {
        nowScale = MaxScale;
        unmaskTransform.localScale = new Vector3(nowScale, nowScale, nowScale);
    }

}
