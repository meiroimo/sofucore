using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class TreasureChestDropScript : MonoBehaviour
{
    /*
     �G�ɒ���t����X�N���v�g
     ���ʂƂ��Ɋm���Ń\�t�r�E�󔠂𗎂Ƃ�
     �������炻������m���Ń��A���e�B�t����
     */
    [SerializeField, Header("�h���b�v����I�u�W�F�N�g-dropOBJ<���A���e�B<���A���e�B����OBJ>>-")]
    List<RarityOBJ> dropOBJ;

    [System.Serializable]
    public class RarityOBJ
    {
        public List<GameObject> objType;
    }

    [SerializeField, Header("�h���b�v����m�� %�œ���"), Range(0, 100)]
    int dropRate;

    [SerializeField, Header("���A���e�B���� %�œ��́@���A���e�B�������œ����")]
    int[] rarityRate;
    

    void Start()
    {
    }

    void Update()
    {
        
    }

    public void Drop()
    {
        int tmp = Random.Range(0, 100);

        if (dropRate < tmp) return;//�����邩����

        tmp = Random.Range(0, 100);

        for (int i = 0; i < rarityRate.Length; i++)
        {
            if (tmp < rarityRate[i])//�����郌�A���e�B����
            {
                GameObject tmpOBJ = dropOBJ[i].objType[0];  //��U0�Ō��ߑł�
                Vector3 dropPosition = transform.root.position; // �G�̐e�̃��[���h���W���擾
                GameObject droppedItem = Instantiate(tmpOBJ, dropPosition, Quaternion.identity); // �����ňʒu���w�肵�Đ���
                return;
            }
        }
    }
}
