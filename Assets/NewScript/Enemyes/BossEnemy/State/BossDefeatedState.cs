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
        Debug.Log("boss‚ð“|‚µ‚½I");
        PlayerStatusCache.LastStatusSave(boss.Playerstatus);

        DestroyAllEnemies();

    }

    public override void Update(BossController boss)
    {
        elapsed += Time.unscaledDeltaTime;

        if (elapsed >= delayBeforeResult)
        {
            Time.timeScale = 1f;
            ResultClear.Instance.isGameClear = true;
            boss.gameObject.SetActive(false);
        }
    }

    public override void Exit(BossController boss)
    {
        Time.timeScale = 1f;
    }

    private void DestroyAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }
    }
}
