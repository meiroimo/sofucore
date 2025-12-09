using System;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float spawnTime = 60;
    private float currentTime = 0f;
    public Text timerText;

    public event Action OnTimeReached;
    public event Action<int> OnTimeIntervalReached; // 経過時間帯イベント

    private bool triggered = false;

    private int lastInterval = 0; // 前回通知した時間帯

    private void Start()
    {
        Difficulty.ResetDifficulty();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        float remainingTime = Mathf.Max(0f, spawnTime - currentTime);

        if (timerText != null)
            timerText.text = "Time: " + remainingTime.ToString("F1") + "秒";

        if (!triggered && currentTime >= spawnTime)
        {
            triggered = true;
            OnTimeReached?.Invoke();
        }

        // 20秒ごとの間隔イベント
        //int currentInterval = Mathf.FloorToInt(currentTime / 20f);
        //if (currentInterval != lastInterval)
        //{
        //    lastInterval = currentInterval;
        //    OnTimeIntervalReached?.Invoke(currentInterval);
        //}
    }
}
