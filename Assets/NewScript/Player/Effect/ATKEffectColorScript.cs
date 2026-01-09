using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKEffectColorScript : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;

    [SerializeField] Color[] preColor;

    ParticleSystem.MainModule main;
    ParticleSystem.ColorOverLifetimeModule col;
    void Start()
    {
        main = particle.main;
        col = particle.colorOverLifetime;
    }

    void Update()
    {
        
    }

    public void ATKChangeColor(int effectColor)
    {
        main.startColor = new ParticleSystem.MinMaxGradient(preColor[effectColor]);
        if (effectColor == 5)ApplyRainbowColor();
    }

    void ApplyRainbowColor()
    {
        Gradient gradient = new Gradient();
        // ===== 虹色（色相を均等に配置）=====
        GradientColorKey[] colorKeys = new GradientColorKey[]
        {
            new GradientColorKey(Color.red,     0.00f),
            new GradientColorKey(Color.yellow,  0.16f),
            new GradientColorKey(Color.green,   0.33f),
            new GradientColorKey(Color.cyan,    0.50f),
            new GradientColorKey(Color.blue,    0.66f),
            new GradientColorKey(Color.magenta, 0.83f),
            new GradientColorKey(Color.red,     1.00f),
        };

        // ===== アルファ指定 =====
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[]
        {
            new GradientAlphaKey(0.0f, 0.00f), // 0%
            new GradientAlphaKey(1.0f, 0.20f), // 20%
            new GradientAlphaKey(1.0f, 0.54f), // 54%
            new GradientAlphaKey(0.0f, 1.00f), // 100%
        };

        gradient.SetKeys(colorKeys, alphaKeys);

        col.color = new ParticleSystem.MinMaxGradient(gradient);
    }
}
