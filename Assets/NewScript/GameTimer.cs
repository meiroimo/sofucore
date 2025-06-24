using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Header("仮の目標時間(秒)")] public float spawnTime = 60;
    private float currentTime = 0f;
    public Text timerText;// タイマー表示用

    public event Action OnTimeReached;

    private bool triggered = false;

    private PlayerController playerController;
    bool player_LifeOrdeath;//プレイヤーが生きてるか
    bool clearFlg;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        float remainingTime = Mathf.Max(0f, spawnTime - currentTime);

        if (timerText != null)
        {
            timerText.text = "Time: " + remainingTime.ToString("F1") + "秒";
        }

        if (!triggered && currentTime >= spawnTime)
        {
            triggered = true;
            OnTimeReached?.Invoke();//登録された関数を呼び出す
        }
    }

    /// <summary>
    /// リザルトシーンに遷移
    /// </summary>
    private void GoToResult()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
