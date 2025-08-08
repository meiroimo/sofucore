using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(LineRenderer))]
public class ArrowVisualizer : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform
    public float arrowLength = 2f;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    void Update()
    {
        // Gamepad���ڑ�����Ă��Ȃ��ꍇ�͖�����
        if (Gamepad.current == null)
        {
            lineRenderer.enabled = false;
            return;
        }

        // �E�X�e�B�b�N�̓��͂��擾
        Vector2 rightStickInput = Gamepad.current.rightStick.ReadValue();

        // ���͂�����������ꍇ�͖����\��
        if (rightStickInput.magnitude < 0.1f)
        {
            lineRenderer.enabled = false;
            return;
        }

        // ���͕������g���Ė��̕\�����X�V
        Vector3 inputDir = new Vector3(rightStickInput.x, 0f, rightStickInput.y).normalized;
        Vector3 startPos = player.position + Vector3.up * 1f;
        Vector3 endPos = startPos + inputDir * arrowLength;

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
