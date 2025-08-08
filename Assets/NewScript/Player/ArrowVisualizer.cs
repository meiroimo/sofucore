using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(LineRenderer))]
public class ArrowVisualizer : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
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
        // Gamepadが接続されていない場合は無効化
        if (Gamepad.current == null)
        {
            lineRenderer.enabled = false;
            return;
        }

        // 右スティックの入力を取得
        Vector2 rightStickInput = Gamepad.current.rightStick.ReadValue();

        // 入力が小さすぎる場合は矢印を非表示
        if (rightStickInput.magnitude < 0.1f)
        {
            lineRenderer.enabled = false;
            return;
        }

        // 入力方向を使って矢印の表示を更新
        Vector3 inputDir = new Vector3(rightStickInput.x, 0f, rightStickInput.y).normalized;
        Vector3 startPos = player.position + Vector3.up * 1f;
        Vector3 endPos = startPos + inputDir * arrowLength;

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
