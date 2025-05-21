using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GetDevicesExample : MonoBehaviour
{
    //[SerializeField] private PlayerInput _playerInput;
    private List<string> connectionDevice = new List<string>();
    //private List<bool> connectionDeviceFlg = new List<bool>();
    int deviceCount;
    bool connectionDeviceFlg;

    public Image cursor;

    //DualShock4GamepadHID
    private void Start()
    {
        connectionDeviceFlg = false;

        // �f�o�C�X�ꗗ���擾
        foreach (var device in InputSystem.devices)
        {
            connectionDevice.Add(device.name);
            // �f�o�C�X�������O�o��
            Debug.Log(device.name);

            //Debug.Log(connectionDevice[deviceCount]);
            //connectionDevice[deviceCount] = device.name;
            deviceCount++;
        }

        CheckConnectionController();
    }

    private void Update()
    {
        StartCoroutine(CheckConnectionController());
    }

    /// <summary>
    /// �R���g���[���[���𔻒f����֐�
    /// </summary>
    IEnumerator CheckConnectionController()
    {
        // �S�f�o�C�X���擾
        var devices = InputSystem.devices;
        connectionDeviceFlg = false;
        yield return null;
        foreach (var device in devices)
        {
            if (device is Gamepad)
            {//�f�o�C�X���Q�[���p�b�h(�R���g���[���[)�̎���������
                Gamepad gamepad = device as Gamepad;
                Debug.Log($"�R���g���[���[���o: {gamepad.displayName}");
                connectionDeviceFlg = true;
            }
        }
        //if (connectionDeviceFlg)
        //{
        //    foreach (string name in connectionDevice)
        //    {
        //        if (name.Equals("DualShock4GamepadHID"))
        //        {
        //            Debug.Log("hogehoge");
        //            yield return null;
        //        }
        //    }
        //}
        StartCoroutine(OnCursor());
    }
    //�f�o�C�X�̕ύX��������
    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (device is Gamepad)
        {//�f�o�C�X���Q�[���p�b�h(�R���g���[���[)�̎���������
            switch (change)
            {
                case InputDeviceChange.Added:
                    Debug.Log($"�R���g���[���[�ڑ�: {device.displayName}");
                    break;
                case InputDeviceChange.Removed:
                    Debug.Log($"�R���g���[���[�ؒf: {device.displayName}");
                    break;
            }
        }
    }

    IEnumerator OnCursor()
    {
        yield return null;
        Debug.Log(connectionDeviceFlg);
        if (connectionDeviceFlg)
        {
            cursor.enabled = true;
            yield return null;
        }
        else 
        {
            cursor.enabled = false;
            yield return null;
        }
    }
}