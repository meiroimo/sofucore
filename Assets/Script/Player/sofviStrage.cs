using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mesh;

public class sofviStrage : MonoBehaviour
{
    [Header("�l���\�t�r�i�[���X�g")] public static List<softVinyl> sofviStrageList = new List<softVinyl>();//�\�t�r�̃X�g���[�W
    [Header("�l���\�t�r��")] public int sofviStrageListConut;
    public GameObject testdata;//�e�X�g�f�[�^�I�u�W�F�N�g
    
    public void deletelist(int listnumber)
    {
        sofviStrageList.RemoveAt(listnumber);

    }
    public void addSofvi(softVinyl softVinylData)
    {
        var dataobj = new GameObject("SoftVinyl");
        dataobj.transform.parent = this.transform.parent;
        softVinyl sofvidata = dataobj.AddComponent<softVinyl>();
        // softVinyl sofvidata = new softVinyl();//�C���X�^���X�̐�������肭�����Ȃ��@���R�@UnityEngine.Object �n�iMonoBehaviour / ScriptableObject�j������ ����B
        //Unity �� Object �n�͕��ʂ� C# �I�u�W�F�N�g�Ɛ������[�����Ⴄ�̂ŁA���������������Ȃ��� �g����ہh �����ɂȂ��� Debug.Log �� null �Ɍ�����B
        Debug.Log(sofvidata);
      //  sofvidata = softVinylData;
        sofvidata.name = softVinylData.name;
        sofvidata.sofvimodel = softVinylData.sofvimodel;
        sofvidata.skill = softVinylData.skill;
        sofvidata.theme = softVinylData.theme;
        sofvidata.buffMainstatus = softVinylData.buffMainstatus;
        sofvidata.buffSubstatus1 = softVinylData.buffSubstatus1;
        sofvidata.buffSubstatus2 = softVinylData.buffSubstatus2;
        sofvidata.buffSubstatus3 = softVinylData.buffSubstatus3;
        sofvidata.Buffparameter = softVinylData.Buffparameter;
        sofvidata.Buffparameter1 = softVinylData.Buffparameter1;
        sofvidata.Buffparameter2 = softVinylData.Buffparameter2;
        sofvidata.Buffparameter3 = softVinylData.Buffparameter3;
        sofvidata.buffName = softVinylData.buffName;
        sofvidata.buffName1 = softVinylData.buffName1;
        sofvidata.buffName2 = softVinylData.buffName2;
        sofvidata.buffName3 = softVinylData.buffName3;
        sofviStrageList.Add(sofvidata);


    }

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
