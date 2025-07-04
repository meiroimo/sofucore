using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDefeatedState : BossState
{
    private float elapsed = 0f;
    private float delayBeforeResult = 3f;
    private bool animationPlayed = false;

    public override void Enter(BossController boss)
    {
        boss.Agent.isStopped = true;
        Debug.Log("bossを倒した！");
        ResultClear.Instance.isGameClear = true;
        BGMManager.Instance.StopBGM();
        //ここにやられた時のアニメーション

        // スロー演出（任意）
        //Time.timeScale = 0.3f;

    }

    public override void Update(BossController boss)
    {
        elapsed += Time.unscaledDeltaTime;

        if (elapsed >= delayBeforeResult)
        {
            Time.timeScale = 1f;
            // ここでクリアフラグを保存
            SceneManager.LoadScene("ResultScene");
        }
    }

    public override void Exit(BossController boss)
    {
        Time.timeScale = 1f;
    }
}
