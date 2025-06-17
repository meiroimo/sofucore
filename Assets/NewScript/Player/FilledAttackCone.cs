using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class FilledAttackCone : MonoBehaviour
{
    public float radius = 5f;
    public float angle = 60f;
    public int segments = 30;
    public float yOffset = 0.05f;

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
            float currentAngle = -halfAngle + step * i;
            Quaternion rot = Quaternion.Euler(0, currentAngle, 0);
            Vector3 dir = rot * Vector3.forward * radius;
            dir.y = yOffset;
            vertices[i + 1] = dir;
        }

        // �O�p�`���X�g
        int[] triangles = new int[segments * 3];
        for (int i = 0; i < segments; i++)
        {
            triangles[i * 3 + 0] = 0;         // ���S
            triangles[i * 3 + 1] = i + 1;     // 1�ڂ̓_
            triangles[i * 3 + 2] = i + 2;     // 2�ڂ̓_
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
}