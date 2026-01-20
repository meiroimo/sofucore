using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySEBox : MonoBehaviour
{
    [Header("エネミーSEの入れ物")]
    public AudioClip[] Enemy_audioClips;

    [Header("敵の死んだときのSE")]
    public AudioClip[] Enemy_Deth_audioClips;

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

    public void PlayEnemyDethSE()
    {
        int tmp = Random.Range(0, Enemy_Deth_audioClips.Length);

        EnemyAudioSource.PlayOneShot(Enemy_Deth_audioClips[tmp]);

    }

    public void StopEnemySE()
    {
        EnemyAudioSource.Stop();
    }
}
