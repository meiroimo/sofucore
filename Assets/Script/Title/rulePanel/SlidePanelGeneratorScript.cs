using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePanelGeneratorScript : MonoBehaviour
{
    [Header("�����p�l��prefab")] public GameObject panelPrefabOBJ;
    [Header("�������鐔")] public int panelCount = 0;
    [Header("�e�I�u�W�F�N�g")]public Transform parent;
    [Header("�p�l���̉��T�C�Y")]public float panelSize;
    Vector2 parentSize; //�e�I�u�W�F�N�g

    [HideInInspector]   //���������p�l����ێ�
    public List<GameObject> generatedPanels = new List<GameObject>();
    float startPosX;    //�p�l����ݒu����|�W�V����X

    //�p�l������
    public void GeneratePanels()
    {
        ClearPanels();  //������

        for(int i = 0; i < panelCount; i++)
        {
            GameObject panel = Instantiate(panelPrefabOBJ, parent);

            // ���ɂ��炵�ĕ��ׂ�i��F2�P�ʊԊu�j
            panel.transform.localPosition = new Vector3(startPosX, 0, 0);
            startPosX += panelSize;
            // ���X�g�ɒǉ����ĊǗ�
            generatedPanels.Add(panel);
        }
    }

    // ���łɐ�������Ă���p�l����S�č폜����
    public void ClearPanels()
    {
        foreach (GameObject panel in generatedPanels)
        {
            if (panel != null)
                DestroyImmediate(panel); // ���s������Ȃ�����Destroy�ł͂Ȃ�DestroyImmediate���g�p
        }
        //�e�p�l���̃T�C�Y�ύX
        parentSize = panelPrefabOBJ.GetComponent<RectTransform>().sizeDelta;
        panelSize = parentSize.x;
        parentSize.x = panelSize * panelCount;
        parent.GetComponent<RectTransform>().sizeDelta = parentSize;
        //�q�ɂ���p�l���̏����ʒu
        startPosX = -panelSize / 2 * (panelCount-1);
        //�e�p�l���̏����ʒu
        parent.GetComponent<RectTransform>().localPosition = new Vector3(-startPosX, 0, 0);
        generatedPanels.Clear(); // ���X�g����
    }
}
