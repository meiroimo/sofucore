using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CameraCoverTransparentScript : MonoBehaviour
{
    [SerializeField, Header("��ʑ�")] Transform playerTransform;
    [SerializeField, Header("��Q���I�u�W�F�N�g")] List<GameObject> coverOBJ;
    [SerializeField, Header("�Օ����̃��b�V��")] List<MeshRenderer> coverMesh;

    int mapLayerMask;
    RaycastHit[] hits;
    List<GameObject> tmpHitOBJ;

    void Start()
    {
        InitCoverOBJ();
        mapLayerMask = 1 << LayerMask.NameToLayer("Map");
    }
    void Update()
    {
        // ray���g�p����Q�����擾
        RayCastCover();

        //�O�t���[���Ə�Q�����ꏏ�Ȃ�return
       // if (Enumerable.SequenceEqual(tmpHitOBJ.OrderBy(e => e.name), coverOBJ.OrderBy(e => e.name))) return;

        //���b�V��������(��U�S���\��)
        InitCoverMesh();

        //���ۂɃ��b�V���̕\��������
        NotDisplayed();

    }

    //ray���g�p����Q�����擾
    void RayCastCover()
    {
        // �J�����Ɣ�ʑ̂����� ray ���쐬
        Vector3 difference = (playerTransform.transform.position - this.transform.position);
        Vector3 direction = difference.normalized;
        Ray ray = new Ray(this.transform.position, direction);

        hits = Physics.RaycastAll(ray, difference.magnitude, mapLayerMask);     //��Q����S���擾
        tmpHitOBJ = new List<GameObject>();
        for (int i = 0; i < hits.Length; i++)
        {
            tmpHitOBJ.Add(hits[i].transform.gameObject);        //��Ŕ�r���邽�߂�List�ɓ����
        }

    }

    //��Q���֌W�̃��X�g�̏�����
    void InitCoverOBJ()
    {
        coverOBJ = new List<GameObject>();
        coverMesh = new List<MeshRenderer>();

    }

    //��Q���̃��b�V��������(��U�S���\��)
    void InitCoverMesh()
    {
        for (int i = 0; i < coverMesh.Count; i++)
        {
            coverMesh[i].enabled = true;
        }

        InitCoverOBJ();
    }

    //���ۂɃ��b�V���̕\��������
    void NotDisplayed()
    {

        for (int i = 0; i < hits.Length; i++)
        {
            GameObject tmpOBJ = hits[i].transform.gameObject;
            if (tmpOBJ.tag == "Floor") continue;
            coverOBJ.Add(tmpOBJ);
            MeshRenderer tmpMesh = tmpOBJ.GetComponent<MeshRenderer>();
            tmpMesh.enabled = false;
            coverMesh.Add(tmpMesh);
        }

    }
}
