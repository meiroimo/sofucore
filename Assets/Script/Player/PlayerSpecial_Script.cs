using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecial_Script : MonoBehaviour
{
    public GameObject gauge;
    private RectTransform gaugeRect;


    public int maxGauge;//SP最大値
    private float gauge1;//1SPの値
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
        //スプライトの幅を最大SPで割って1SPあたりの幅をもとめる
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
    /// 変身ゲームの自動回復
    /// 毎秒１回復
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
    /// 変身ゲージ使用
    /// １０秒で０へ
    /// 変更できるようにしたい
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
    /// ドロップするSPの1SPあたりの幅をもとめる
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
