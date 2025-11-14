using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSEBox : MonoBehaviour
{
    [Header("プレイヤーSEの入れ物")]
    public AudioClip[] Player_audioClips;

    public enum SENAME
    {
        MOVE,
        ATTACK,
        HIT,
        AVOID,
        CHARGE,
        ITEMGET
    }

    public AudioSource playerAudioSource; // SE を鳴らす AudioSource

    public void PlayPlayerSE(SENAME seName)
    {
        int index = (int)seName;

        if (index < 0 || index >= Player_audioClips.Length)
        {
            Debug.LogWarning($"SE {seName} は登録されていません！");
            return;
        }

        playerAudioSource.PlayOneShot(Player_audioClips[index]);
    }

    public void StopPlayerSE()
    {
        playerAudioSource.Stop();
    }
}
