using UnityEngine;

public class LineBox : MonoBehaviour
{
    void Start()
    {
        var line = gameObject.AddComponent<LineRenderer>();

        // ���̕�
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;

        // ���̒��_���i�l�p�`�{�n�_�ɖ߂�p��5�_�j
        line.positionCount = 5;

        // �������[�v������i�n�_�ɖ߂�j
        line.loop = true;

        // ���̐F�i�}�e���A�����Ȃ���΂�����L���j
        line.startColor = new Color(0, 1, 0, 0.5f); // ��������
        line.endColor = new Color(0, 1, 0, 0.5f);

        // �}�e���A���i�����Ȑ��p�j

        // ���W��ݒ�iXZ���ʂɐ����`�j
        line.SetPositions(new Vector3[] {
            new Vector3(-0.5f, 0, -0.5f),
            new Vector3(0.5f, 0, -0.5f),
            new Vector3(0.5f, 0, 0.5f),
            new Vector3(-0.5f, 0, 0.5f),
            new Vector3(-0.5f, 0, -0.5f), // �n�_�ɖ߂�
        });
    }
}
