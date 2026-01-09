using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySEBox : MonoBehaviour
{
    [Header("エネミーSEの入れ物")]
    public AudioClip[] Enemy_audioClips;

    public enum SENAME
    {
        ATTACK,
        HIT,
    }

    public AudioSource EnemyAudioSource; // SE を鳴らす AudioSource

    public void PlayEnemySE(SENAME seName)
    {
        int index = (int)seName;

        if (index < 0 || index >= Enemy_audioClips.Length)
        {
            Debug.LogWarning($"SE {seName} は登録されていません！");
            return;
        }

        EnemyAudioSource.PlayOneShot(Enemy_audioClips[index]);
    }

    public void StopEnemySE()
    {
        EnemyAudioSource.Stop();
    }
}
