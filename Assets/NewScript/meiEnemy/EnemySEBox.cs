using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySEBox : MonoBehaviour
{
    [Header("�G�l�~�[SE�̓��ꕨ")]
    public AudioClip[] Enemy_audioClips;

    public enum SENAME
    {
        ATTACK,
        HIT,
    }

    public AudioSource EnemyAudioSource; // SE ��炷 AudioSource

    public void PlayEnemySE(SENAME seName)
    {
        int index = (int)seName;

        if (index < 0 || index >= Enemy_audioClips.Length)
        {
            Debug.LogWarning($"SE {seName} �͓o�^����Ă��܂���I");
            return;
        }

        EnemyAudioSource.PlayOneShot(Enemy_audioClips[index]);
    }

    public void StopEnemySE()
    {
        EnemyAudioSource.Stop();
    }
}
