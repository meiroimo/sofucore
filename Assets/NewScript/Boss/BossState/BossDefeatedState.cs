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
        Debug.Log("boss��|�����I");
        PlayerStatusCache.LastStatusSave(boss.Playerstatus);
        //�����ɂ��ꂽ���̃A�j���[�V����

        // �X���[���o�i�C�Ӂj
        //Time.timeScale = 0.3f;

    }

    public override void Update(BossController boss)
    {
        elapsed += Time.unscaledDeltaTime;

        if (elapsed >= delayBeforeResult)
        {
            Time.timeScale = 1f;
            BGMManager.Instance.StopBGM();
            ResultClear.Instance.isGameClear = true;
            boss.gameObject.SetActive(false);
            // �����ŃN���A�t���O��ۑ�
            //SceneManager.LoadScene("ResultScene");
        }
    }

    public override void Exit(BossController boss)
    {
        Time.timeScale = 1f;
    }
}
