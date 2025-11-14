using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGMScript : MonoBehaviour
{
    [SerializeField] AudioClip stageBGM;
    [SerializeField] AudioClip testBGM;
    //[SerializeField] BGMManager bgm;

    void Start()
    {
        //bgm.PlayBGM(stageBGM);
        if (BGMManager.Instance != null)
        {
            BGMManager.Instance.PlayBGM(stageBGM);
        }
    }
}
