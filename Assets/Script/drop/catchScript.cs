using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchScript : MonoBehaviour
{
    /*
     �v���C���[�ɓ\��t����
    �@�������\�t�r�E�󔠂�����X�N���v�g

    ��������\�t�r�A�󔠂�catchSofvi�AcatchTreasureChest�Ƀ��A���e�B���ƂɃJ�E���g
    �v�f��:
    0:SR 
    1:R
    2:N
     */
    //��������\�t�r�̐�
    public int[] catchSofvi;
    //��������󔠂̐�
    public int[] catchTreasureChest;
    string[] rarityTagName = { "superRare", "Rare", "Normal" };
    void Start()
    {
        catchSofvi = new int[3];
        catchTreasureChest = new int[3];
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        string objTagName = other.tag;
        //����Ώۂł͂Ȃ����return
        if (!objTagName.Contains("box") && !objTagName.Contains("sofvi")) return;

        for (int i = 0; i < rarityTagName.Length; i++)
        {
            if (!objTagName.Contains(rarityTagName[i])) continue;//���A���e�B���Ⴄ��continue

            //���ꂼ��Ώۂ̕����J�E���g
            if (objTagName.Contains("box"))
            {

                catchTreasureChest[i]++;
            }
            else
            {
                if(other.GetComponent<softVinyl>() != null)
                {
                    other.GetComponent<softVinyl>().ListNumber = sofviStrage.sofviStrageList.Count ;
                    sofviStrage.sofviStrageList.Add(other.GetComponent<softVinyl>());
                }
                catchSofvi[i]++;
            }

            //�J�E���g���������
            Destroy(other.gameObject);
        }

    }
}
