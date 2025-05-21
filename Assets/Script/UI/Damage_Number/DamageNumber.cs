using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public TextMeshProUGUI damageText;

    public float lifeTime = 2f;　     //表示時間
    private float lifeCounter;   //表示時間を記憶する変数
    public float alpha = 1;//1=255 1=100%
    public float fadeSpeed = 0.01f;
    private int switchCriticalColor;
    private float test;

    public float floatSpeed = 1f;//ダメージ表記を上にあげる速度


    // Start is called before the first frame update
    void Start()
    {
        lifeCounter = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeCounter > 0)
        {
            lifeCounter -= Time.deltaTime;
            alpha -= fadeSpeed;
            if (lifeCounter <= 1) alpha -= fadeSpeed;

            if (lifeCounter <= 0)
            {
                alpha = 1f;
                //Destroy(gameObject);

                DamageNumberController.instance.PlaceInPool(this);
            }
        }

        transform.position += Vector3.up * floatSpeed * Time.deltaTime;
        damageText.color = new Color(1, 1, test, alpha);
    }

    IEnumerator ChangeColor()
    {
        alpha -= fadeSpeed;
        yield return null;
        damageText.color = new Color(1, 1, 1, alpha);
    }

    public void SetUp(int damageDisplay, float cr)
    {
        lifeCounter = lifeTime;

        damageText.text = damageDisplay.ToString();
        test = cr;
    }
}
