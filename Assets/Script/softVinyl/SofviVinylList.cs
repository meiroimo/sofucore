using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofviVinylList : MonoBehaviour
{
    Transform Parent;//�e�I�u�W�F�N�g
    public GameObject[] children;//�q�I�u�W�F�N�g�̔z��
    public PanelButton[] childrenPanelScript;//�q�I�u�W�F�N�g�̃p�l���X�N���v�g�̔z��
   public softVinyl[] childrensoftVinyl; //�q�I�u�W�F�N�g�̃p�����[�^�̃X�N���v�g

    public GameObject playerStorage;//�X�g���[�W�I�u�W�F�N�g
    public sofviStrage sofviStrageScript;//�X�g���[�W�z����Q��
    public int storageCount;//�X�g���[�W�Q�Ƃ̌�
    public List<softVinyl> softVinylData;//�\�t�r�f�[�^���X�g���[�W����R�s�[

    void Start()
    {
        playerStorage = GameObject.Find("Player_Storage");
        sofviStrageScript= playerStorage.GetComponent<sofviStrage>();
        Parent = this.gameObject.transform;
      
        int childCount = Parent.childCount;
        children = new GameObject[childCount];
        childrenPanelScript = new PanelButton[childCount];

        childrensoftVinyl = new softVinyl[childCount];


        Storechildren();
    }

    void Storechildren()//�q�I�u�W�F�N�g�̎擾
    {
        // �q�����Ԃɔz��Ɋi�[
        for (int i = 0; i < children.Length; i++)
        {
            children[i] = Parent.GetChild(i).gameObject;
            childrensoftVinyl[i] = children[i].gameObject.GetComponent<softVinyl>();
            children[i].gameObject.GetComponent<PanelButton>().Number = i;
            childrenPanelScript[i] = children[i].gameObject.GetComponent<PanelButton>();
        }
    }
    void setSofiDataButton()//�e�{�^���Ƀ\�t�r�f�[�^���Z�b�g
    {
         softVinylData = sofviStrage.sofviStrageList;

        if (softVinylData == null)
        {
           
            Debug.Log("null��������");

        }




        //�����{�^���Ƀ\�t�r�f�[�^���Z�b�g


        for (int i = 0; i < softVinylData.Count; i++)
        {
          //  childrensoftVinyl[i] = softVinylData[i];

            Debug.Log(childrensoftVinyl[i].buffName1);
            Debug.Log(softVinylData[i].buffName1);
        //    childrensoftVinyl[i].name = softVinylData[i].name;
            childrensoftVinyl[i].buffName1 = softVinylData[i].buffName1;
            childrensoftVinyl[i].buffName2 = softVinylData[i].buffName2;
            childrensoftVinyl[i].buffName3 = softVinylData[i].buffName3;

            Debug.Log(childrensoftVinyl[i].buffName1);
            Debug.Log(softVinylData[i].buffName1);





            childrensoftVinyl[i].sofvimodel = softVinylData[i].sofvimodel;
            childrensoftVinyl[i].skill = softVinylData[i].skill;
            childrensoftVinyl[i].theme = softVinylData[i].theme;
            //childrensoftVinyl[i].sofviImage = softVinylData[i].sofviImage;
            //childrensoftVinyl[i].sofviImage = softVinylData[i].sofviImage;
            //childrensoftVinyl[i].sofviName = softVinylData[i].sofviName;
            //childrensoftVinyl[i].buffMainstatus = softVinylData[i].buffMainstatus;
            childrensoftVinyl[i].buffSubstatus1 = softVinylData[i].buffSubstatus1;
            childrensoftVinyl[i].buffSubstatus2 = softVinylData[i].buffSubstatus2;
            childrensoftVinyl[i].buffSubstatus3 = softVinylData[i].buffSubstatus3;
            childrensoftVinyl[i].Buffparameter = softVinylData[i].Buffparameter;
            childrensoftVinyl[i].Buffparameter1 = softVinylData[i].Buffparameter1;
            childrensoftVinyl[i].Buffparameter2 = softVinylData[i].Buffparameter2;
            childrensoftVinyl[i].Buffparameter3 = softVinylData[i].Buffparameter3;
            childrensoftVinyl[i].buffName = softVinylData[i].buffName;
            childrensoftVinyl[i].buffName1 = softVinylData[i].buffName1;
            childrensoftVinyl[i].buffName2 = softVinylData[i].buffName2;
            childrensoftVinyl[i].buffName3 = softVinylData[i].buffName3;





            childrensoftVinyl[i].ListNumber = i;//�z��ԍ���t�^



        }

       

    }
    // Update is called once per frame
    void Update()
    {
       setSofiDataButton();
     
    }
}
