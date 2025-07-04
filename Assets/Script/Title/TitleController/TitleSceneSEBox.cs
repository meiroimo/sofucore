using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneSEBox : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip pushSE;

    public void PlayPushSE()
    {
        audioSource.PlayOneShot(pushSE);
    }
}
