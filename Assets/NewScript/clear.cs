using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class clear : MonoBehaviour
{
    public GameObject clearTextPanel;
    public Text clearText;

    private void Start()
    {
        clearTextPanel.SetActive(false);

        // 起動時の接続状況で一度チェック
        UpdateClearMessage();

        // デバイスの接続/切断を監視
        InputSystem.onDeviceChange += OnDeviceChange;

    }

    private void Update()
    {
        if(ResultClear.Instance.isGameClear)
        {
            clearTextPanel.SetActive(true);
            if (Keyboard.current?.enterKey.wasPressedThisFrame == true ||
           Keyboard.current?.spaceKey.wasPressedThisFrame == true ||
           Gamepad.current?.buttonSouth.wasPressedThisFrame == true) // Aボタン(PSなら×)
            {
                resetStrage();//スタティックのストレージリストをクリア
                SceneManager.LoadScene("ResultScene");
                return;
            }
        }
    }


    /// <summary>
    /// デバイスの「追加」または「削除」を検出
    /// </summary>
    /// <param name="device"></param>
    /// <param name="change"></param>
    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (change == InputDeviceChange.Added || change == InputDeviceChange.Removed)
        {
            UpdateClearMessage();
        }
    }

    private void UpdateClearMessage()
    {
        if (Gamepad.current != null) // ゲームパッドがある場合
        {
            clearText.text = "Aボタンで進む";
        }
        else // キーボードのみ
        {
            clearText.text = "spaceキーで進む";
        }
    }
    private void resetStrage()
    {
        sofviStrage.sofviStrageList.Clear();
    }
}
