using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofviVinylList : MonoBehaviour
{
    Transform Parent;//�e�I�u�W�F�N�g
    public GameObject[] children;//�q�I�u�W�F�N�g�̔z��
    public softVinyl[] childrensoftVinyl;//�q�I�u�W�F�N�g�̃\�t�r�X�N���v�g�̔z��
    public PanelButton[] childrenPanelScript;//�q�I�u�W�F�N�g�̃p�l���X�N���v�g�̔z��

    public sofviStrage sofviStrage;//�X�g���[�W�z����Q��
    public int storageCount;//�X�g���[�W�Q�Ƃ̌�
    public List<softVinyl> softVinylData;//�\�t�r�f�[�^���X�g���[�W����R�s�[

    void Start()
    {
        Parent = this.gameObject.transform;
      
        int childCount = Parent.childCount;
        //  Debug.Log(aaa);
        children = new GameObject[childCount];
        childrensoftVinyl = new softVinyl[childCount];
        childrenPanelScript = new PanelButton[childCount];

        Storechildren();
    }

    void Storechildren()//�q�I�u�W�F�N�g�̎擾
    {
        // �q�����Ԃɔz��Ɋi�[
        for (int i = 0; i < Parent.childCount; i++)
        {
            children[i] = Parent.GetChild(i).gameObject;
            childrensoftVinyl[i] = children[i].gameObject.GetComponent<softVinyl>();
            
            childrenPanelScript[i] = children[i].gameObject.GetComponent<PanelButton>();
        }
    }
    void setSofiDataButton()//�e�{�^���Ƀ\�t�r�f�[�^���Z�b�g
    {




        for (int i = 0; i < 105; i++)
        {
            //�����{�^���Ƀ\�t�r�f�[�^���Z�b�g
            if (i < sofviStrage.sofviStrageListConut)
            {
               

                childrensoftVinyl[i].skill = sofviStrage.sofviStrageList[i].skill;
                childrensoftVinyl[i].theme = sofviStrage.sofviStrageList[i].theme;
                childrensoftVinyl[i].sofviImage = sofviStrage.sofviStrageList[i].sofviImage;
                childrensoftVinyl[i].cost = sofviStrage.sofviStrageList[i].cost;
                childrensoftVinyl[i].ListNumber = i;//�z��ԍ���t�^

                childrensoftVinyl[i].sofviName = sofviStrage.sofviStrageList[i].sofviName;
                childrensoftVinyl[i].buffMainstatus = sofviStrage.sofviStrageList[i].buffMainstatus;
                childrensoftVinyl[i].buffSubstatus1 = sofviStrage.sofviStrageList[i].buffSubstatus1;
                childrensoftVinyl[i].buffSubstatus2 = sofviStrage.sofviStrageList[i].buffSubstatus2;
                childrensoftVinyl[i].buffSubstatus3 = sofviStrage.sofviStrageList[i].buffSubstatus3;

                childrensoftVinyl[i].Buffparameter = sofviStrage.sofviStrageList[i].Buffparameter;
                childrensoftVinyl[i].Buffparameter1 = sofviStrage.sofviStrageList[i].Buffparameter1;
                childrensoftVinyl[i].Buffparameter2 = sofviStrage.sofviStrageList[i].Buffparameter2;
                childrensoftVinyl[i].Buffparameter3 = sofviStrage.sofviStrageList[i].Buffparameter3;

                childrensoftVinyl[i].buffName = sofviStrage.sofviStrageList[i].buffName;
                childrensoftVinyl[i].buffName1 = sofviStrage.sofviStrageList[i].buffName1;
                childrensoftVinyl[i].buffName2 = sofviStrage.sofviStrageList[i].buffName2;
                childrensoftVinyl[i].buffName3 = sofviStrage.sofviStrageList[i].buffName3;

            }

        }

       

    }
    // Update is called once per frame
    void Update()
    {
       setSofiDataButton();
     
    }
}
