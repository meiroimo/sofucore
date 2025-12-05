using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
    static float secondsToMaxDifficulty = 120;
    static float startTime = 0f;//開始時間を保存する

    public static void ResetDifficulty()
    {
        startTime = Time.time;//今の時間を開始基準にする
    }

    public static float GetDifficultyPercent()
    {
        float t = Mathf.Clamp01((Time.time - startTime) / secondsToMaxDifficulty);
        //return Mathf.Clamp01(Time.time / secondsToMaxDifficulty);
        return Mathf.Pow(t, 3f);
    }
}
