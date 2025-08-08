using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �U���͈͂̕\���i���͕����ɐ��������j
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class FilledAttackCone : MonoBehaviour
{
    public float radius = 5f;
    public float angle = 60f;
    public int segments = 30;
    public float yOffset = 0.05f;
    public Transform player; // �v���C���[�ʒu�i��̋N�_�j

    private MeshFilter meshFilter;
    private Vector2 inputDirection; // �U�������i�E�X�e�B�b�N�j

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = GenerateConeMesh();
    }

    private void Update()
    {
        // �U������������Ƃ������\���E�����X�V
        if (inputDirection.sqrMagnitude > 0.01f)
        {
            Vector3 flatDirection = new Vector3(inputDirection.x, 0f, inputDirection.y).normalized;

            // ��]�����ĕ�������������
            transform.rotation = Quaternion.LookRotation(flatDirection);

            // �v���C���[�̏�����Ɉʒu���Z�b�g
            transform.position = player.position + Vector3.up * yOffset;

            //gameObject.SetActive(true);
        }
        else
        {
            //gameObject.SetActive(false); // ���͂������Ƃ���\��
        }
    }

    // �O������������Z�b�g����p�iInputSystem�Ȃǂ���Ăԁj
    public void SetDirection(Vector2 dir)
    {
        inputDirection = dir;
    }

    private Mesh GenerateConeMesh()
    {
        Mesh mesh = new Mesh();

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

        int[] triangles = new int[segments * 3];
        for (int i = 0; i < segments; i++)
        {
            triangles[i * 3 + 0] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
}
