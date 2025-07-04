using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGMScript : MonoBehaviour
{
    [SerializeField] AudioClip stageBGM;

    void Start()
    {
        if (BGMManager.Instance != null)
        {
            BGMManager.Instance.PlayBGM(stageBGM);
        }
    }
}
