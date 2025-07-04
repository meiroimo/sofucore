using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSEBox : MonoBehaviour
{
    [Header("�v���C���[SE�̓��ꕨ")]
    public AudioClip[] Player_audioClips;

    public enum SENAME
    {
        MOVE,
        ATTACK,
        HIT,
        AVOID,
        CHARGE
    }

    public AudioSource playerAudioSource; // SE ��炷 AudioSource

    public void PlayPlayerSE(SENAME seName)
    {
        int index = (int)seName;

        if (index < 0 || index >= Player_audioClips.Length)
        {
            Debug.LogWarning($"SE {seName} �͓o�^����Ă��܂���I");
            return;
        }

        playerAudioSource.PlayOneShot(Player_audioClips[index]);
    }

    public void StopPlayerSE()
    {
        playerAudioSource.Stop();
    }
}
