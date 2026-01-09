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

        // デバイス一覧を取得
        foreach (var device in InputSystem.devices)
        {
            connectionDevice.Add(device.name);
            // デバイス名をログ出力
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
    /// コントローラーかを判断する関数
    /// </summary>
    IEnumerator CheckConnectionController()
    {
        // 全デバイスを取得
        var devices = InputSystem.devices;
        connectionDeviceFlg = false;
        yield return null;
        foreach (var device in devices)
        {
            if (device is Gamepad)
            {//デバイスがゲームパッド(コントローラー)の時だけ処理
                Gamepad gamepad = device as Gamepad;
                Debug.Log($"コントローラー検出: {gamepad.displayName}");
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
    //デバイスの変更があった
    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (device is Gamepad)
        {//デバイスがゲームパッド(コントローラー)の時だけ処理
            switch (change)
            {
                case InputDeviceChange.Added:
                    Debug.Log($"コントローラー接続: {device.displayName}");
                    break;
                case InputDeviceChange.Removed:
                    Debug.Log($"コントローラー切断: {device.displayName}");
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