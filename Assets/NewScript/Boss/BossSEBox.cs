using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSEBox : MonoBehaviour
{
    [Header("�v���C���[SE�̓��ꕨ")]
    public AudioClip[] Boss_audioClips;

    public enum SENAME
    {
        ATTACK,
        HIT,
    }

    public AudioSource bossAudioSource; // SE ��炷 AudioSource

    public void PlayBossSE(SENAME seName)
    {
        int index = (int)seName;

        if (index < 0 || index >= Boss_audioClips.Length)
        {
            Debug.LogWarning($"SE {seName} �͓o�^����Ă��܂���I");
            return;
        }

        bossAudioSource.PlayOneShot(Boss_audioClips[index]);
    }

    public void StopBossSE()
    {
        bossAudioSource.Stop();
    }
}
