using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �U���͈͂̕\��(�O�p�`�Ő�^�̍U���͈͂��쐬)
/// </summary>
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class FilledAttackCone : MonoBehaviour
{
    public float radius = 5f;//��̔��a(�ǂꂭ�炢�����܂œ͂���)
    public float angle = 60f;//��̊p�x
    public int segments = 30;//����\������O�p�`�̐�
    public float yOffset = 0.05f;//�n�ʂ��班���������鍂��

    private void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = GenerateConeMesh();
    }

    private Mesh GenerateConeMesh()
    {
        Mesh mesh = new Mesh();

        // ���_���X�g�i���S + ��`�̒[�j
        Vector3[] vertices = new Vector3[segments + 2];
        vertices[0] = new Vector3(0, yOffset, 0); // ���S

        float halfAngle = angle / 2f;
        float step = angle / segments;

        for (int i = 0; i <= segments; i++)
        {
            //-halfAngle ���� +halfAngle �܂Ŋp�x�����炵�Ȃ���_��z�u�B
            float currentAngle = -halfAngle + step * i;
            //uaternion.Euler �ŉ�]�����āAVector3.forward ����]���A�����������ĉ~�ʏ�ɓ_����ׂĂ���B
            Quaternion rot = Quaternion.Euler(0, currentAngle, 0);
            Vector3 dir = rot * Vector3.forward * radius;
            dir.y = yOffset;
            vertices[i + 1] = dir;
        }

        // �O�p�`���X�g
        //���S + �O��2�_ �Łu��`�̎O�p�`�v������āA����� n ��J��Ԃ��B
        int[] triangles = new int[segments * 3];
        for (int i = 0; i < segments; i++)
        {
            triangles[i * 3 + 0] = 0;         // ���S
            triangles[i * 3 + 1] = i + 1;     // 1�ڂ̓_
            triangles[i * 3 + 2] = i + 2;     // 2�ڂ̓_
        }

        //���_�ƎO�p�`�����b�V���ɃZ�b�g
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
}