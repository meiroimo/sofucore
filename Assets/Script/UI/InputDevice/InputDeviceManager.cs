using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// ���g���Ă���f�o�C�X�����ʂł���悤�ɂ���
/// �Q�l��
/// https://nekocha.hatenablog.com/entry/2024/03/28/212705
/// </summary>
public class InputDeviceManager : MonoBehaviour
{
    //�V���O���g��
    public static InputDeviceManager Instance { get; private set; }

    /// <summary>
    /// ���̓f�o�C�X�̎��
    /// </summary>
    public enum InputDeviceType
    {
        Keyboard,   //�L�[�{�[�h�E�}�E�X
        DualShock4, //DualShock(PS4)
        Switch,     //Switch��Pro�R���g���[���[
    }

    //���߂ɑ��삳�ꂽ���̓f�o�C�X�^�C�v
    public InputDeviceType CurrentDeviceType { get; private set; } = InputDeviceType.Keyboard;

    //�e�f�o�C�X�̑S�ẴL�[��1�Ƀo�C���h����InputAction(�L�[��ʌ��m�p)
    private InputAction keyboardAnyKey = new InputAction(type: InputActionType.PassThrough, binding: "<Keyboard>/AnyKey", interactions: "Press");
    private InputAction mouseAnyKey = new InputAction(type: InputActionType.PassThrough, binding: "<Mouse>/*", interactions: "Press");
    private InputAction dualShock4AnyKey = new InputAction(type: InputActionType.PassThrough, binding: "<Mouse>/*", interactions: "Press");
}
