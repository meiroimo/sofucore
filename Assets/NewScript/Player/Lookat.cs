using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�e���V���[���Fhttps://tsubakit1.hateblo.jp/entry/2017/07/02/232453
public class Lookat : MonoBehaviour
{
    Plane plane = new Plane();
    float distance = 0;
    Vector3 lookPoint;

    public float Distance { get => distance; set => distance = value; }
    public Vector3 LookPoint { get => lookPoint; set => lookPoint = value; }

    void Update()
    {
        // �J�����ƃ}�E�X�̈ʒu������Ray������
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // �v���C���[�̍�����Plane���X�V���āA�J�����̏������ɒn�ʔ��肵�ċ������擾
        plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
        if (plane.Raycast(ray, out distance))
        {
            //if (Input.GetKeyDown(KeyCode.I))
            {
                // ���������Ɍ�_���Z�o���āA��_�̕�������
                //var lookPoint = ray.GetPoint(distance);
                lookPoint = ray.GetPoint(distance);
                transform.LookAt(lookPoint);

            }
        }
    }
}
