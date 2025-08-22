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

        // �N�����̐ڑ��󋵂ň�x�`�F�b�N
        UpdateClearMessage();

        // �f�o�C�X�̐ڑ�/�ؒf���Ď�
        InputSystem.onDeviceChange += OnDeviceChange;

    }

    private void Update()
    {
        if(ResultClear.Instance.isGameClear)
        {
            clearTextPanel.SetActive(true);
            if (Keyboard.current?.enterKey.wasPressedThisFrame == true ||
           Keyboard.current?.spaceKey.wasPressedThisFrame == true ||
           Gamepad.current?.buttonSouth.wasPressedThisFrame == true) // A�{�^��(PS�Ȃ�~)
            {
                SceneManager.LoadScene("ResultScene");
                return;
            }
        }
    }


    /// <summary>
    /// �f�o�C�X�́u�ǉ��v�܂��́u�폜�v�����o
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
        if (Gamepad.current != null) // �Q�[���p�b�h������ꍇ
        {
            clearText.text = "A�{�^���Ői��";
        }
        else // �L�[�{�[�h�̂�
        {
            clearText.text = "space�L�[�Ői��";
        }
    }
}
