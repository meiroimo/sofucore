using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sofviStrage : MonoBehaviour
{
    [Header("�l���\�t�r�i�[���X�g")] public List<softVinyl> sofviStrageList;//�\�t�r�̃X�g���[�W
    [Header("�l���\�t�r��")] public int sofviStrageListConut;
    public GameObject testdata;//�e�X�g�f�[�^�I�u�W�F�N�g
    public void deletelist(int listnumber)
    {
        sofviStrageList.RemoveAt(listnumber);
     

    }
    public void addMagicCircle(softVinyl softVinyldata)
    {
        sofviStrageList.Add(softVinyldata);
      

    }
    void Start()
    {
        sofviStrageListConut = 0;
        setTestData();
    }

    
    void Update()
    {
        sofviStrageListConut = sofviStrageList.Count;


    }
    void setTestData()
    {
        for (int i = 0; i < testdata.gameObject.transform.childCount; i++)
        {
            addMagicCircle(testdata.gameObject.transform.GetChild(i).gameObject.GetComponent<softVinyl>());
        }


    }
}
