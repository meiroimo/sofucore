using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class setWindow : MonoBehaviour
{
    Transform Parent;//�e�I�u�W�F�N�g
    public softVinyl selectSofviData;//�q�I�u�W�F�N�g�̃\�t�r�X�N���v�g
    [Header("�Z���N�g���̃\�t�r")] public GameObject selectSofviDataOBJ;//�q�I�u�W�F�N�g�A�Z���N�g���̃\�t�r�f�[�^�ۑ��ꏊ
     public GameObject selectSofvibutton;//�Z���N�g���̃\�t�r�ꗗ�̃{�^��
    bool checkSetSelectSofviData;//�Z���N�g�\�t�r�f�[�^���Z�b�g����Ă��邩
    public GameObject grandChild;
    private int renCount=4;//�\�t�r��̒i��
    public GameObject[] renOBJ;//�Z�b�g�����̒iobj
    public GameObject[,] setpositionOBJ;//�Z�b�g����ꏊ��OBJ�񎟌��z��,��OBJ
    //public GameObject[] setpositionOBJ;//�Z�b�g����ꏊ��OBJ�z��

    void Start()
    {

        Parent = this.gameObject.transform;
        renOBJ = new GameObject[renCount];
        setpositionOBJ = new GameObject[renCount,4];

        selectSofviDataOBJ = new GameObject();
        //selectSofviData = new softVinyl();
        selectSofviDataOBJ = transform.Find("selectSofvi").gameObject;
        selectSofviData = selectSofviDataOBJ.GetComponent<softVinyl>();
        //���i�q�I�u�W�F�N�g�̎q�I�u�W�F�N�g)���擾����B
        //�ȉ��̏ꍇ�Ȃ玩�g�̎q�I�u�W�F�N�gChild�̎q�I�u�W�F�N�gGrandChild���擾
         //grandChild = transform.Find("Step1/GameObject").gameObject;
        //renOBJ[0] = Parent.GetChild(0).gameObject;
        getsofivisetposition();
    }

    public void getsofivisetposition()//�ݒu��̃\�t�r���ݒu�ł���|�C���g��͂�
    {
        for(int i=0;i<renCount;i++)
        {
            renOBJ[i] = Parent.GetChild(i).gameObject;
            for (int j = 0; j < Parent.GetChild(i).gameObject.transform.childCount; j ++)
            {

                setpositionOBJ[i,j] = renOBJ[i].transform.GetChild(j).gameObject;//��obj�̎擾
               // Debug.Log(setpositionOBJ[i, j]);

            }


        }


    }


    void Update()
    {
        
    }
    public void selectSofviSet()//�I��ł���\�t�r�̃f�[�^���Z�b�g����
    {
        
    }
}
