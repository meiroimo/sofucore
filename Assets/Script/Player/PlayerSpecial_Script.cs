using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecial_Script : MonoBehaviour
{
    public GameObject gauge;
    private RectTransform gaugeRect;


    public int maxGauge;//SP�ő�l
    private float gauge1;//1SP�̒l
    //private float timer;
    private float autoGauge;
    private float maxGaugeRect;
    public float transformerTimer = 10;
    private bool specialflg;
    private Vector2 minGaugeRect;
    private Vector2 nowsafes;

    private void Awake()
    {
        gaugeRect = gauge.GetComponent<RectTransform>();
        //�X�v���C�g�̕����ő�SP�Ŋ�����1SP������̕������Ƃ߂�
        gauge1 = gaugeRect.sizeDelta.x / maxGauge;
        autoGauge = gauge1 * 1;
        maxGaugeRect = gaugeRect.sizeDelta.x;
        minGaugeRect = new Vector2(0, 10);
        gaugeRect.sizeDelta = minGaugeRect;
        nowsafes = gaugeRect.sizeDelta;
        specialflg = false;
    }

    void Start()
    {
        Debug.Log(minGaugeRect);
        StartCoroutine(PursueGauge());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) && specialflg)
        {
            specialflg = false;
            StartCoroutine(SpecialMode());
            Debug.Log(gaugeRect.sizeDelta.x);
        }
        //timer += Time.deltaTime;
    }

    /// <summary>
    /// �ϐg�Q�[���̎�����
    /// ���b�P��
    /// </summary>
    /// <returns></returns>

    IEnumerator PursueGauge()
    {
        //timer = 0;
        while (true)
        {
            nowsafes.x += 20;//autoGauge;
            yield return new WaitForSeconds(1f);
            gaugeRect.sizeDelta = nowsafes;

            if (gaugeRect.sizeDelta.x < maxGaugeRect)
            {
                specialflg = true;
                continue;
            }
            break;
        }
    }

    /// <summary>
    /// �ϐg�Q�[�W�g�p
    /// �P�O�b�łO��
    /// �ύX�ł���悤�ɂ�����
    /// </summary>
    /// <returns></returns>
    IEnumerator SpecialMode()
    {
        float trs1Time = transformerTimer / maxGaugeRect;
        //timer = 0;
        while (true)
        {
            nowsafes.x -= gauge1;
            //yield return null;
            yield return new WaitForSeconds(trs1Time);
            gaugeRect.sizeDelta = nowsafes;
            if (nowsafes.x > 0)
            {
                continue;
            }
            nowsafes.x = 0;
            break;
        }
        yield return null;
        StartCoroutine(PursueGauge());
    }

    /// <summary>
    /// �h���b�v����SP��1SP������̕������Ƃ߂�
    /// </summary>
    /// <param name="specialpoint"></param>
    public void BeInjured(int specialpoint)
    {
        float sp = gauge1 * specialpoint;

        GetSpPoint(sp);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sp"></param>
    public void GetSpPoint(float sp)
    {
        if (gaugeRect.sizeDelta.x >= maxGaugeRect)
        {
            nowsafes.x = maxGaugeRect;
            gaugeRect.sizeDelta = nowsafes;
            return;
        }
        nowsafes.x += sp;//autoGauge;
        gaugeRect.sizeDelta = nowsafes;
    }
}
