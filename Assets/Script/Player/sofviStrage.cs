using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.Mesh;

public class sofviStrage : MonoBehaviour
{
    [Header("�l���\�t�r�i�[���X�g")] public static List<softVinyl> sofviStrageList = new List<softVinyl>();//�\�t�r�̃X�g���[�W
    [Header("�l���\�t�r��")] public int sofviStrageListConut;
    public GameObject testdata;//�e�X�g�f�[�^�I�u�W�F�N�g
    
   

    void setTestData()
    {
        for (int i = 0; i < testdata.gameObject.transform.childCount; i++)
        {
            //addSofvi(testdata.gameObject.transform.GetChild(i).gameObject.GetComponent<softVinyl>());
        }


    }
    void Start()
    {
        sofviStrageListConut = 0;
    }

    
    void Update()
    {
        sofviStrageListConut = sofviStrageList.Count;
    }
  
}
