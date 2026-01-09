using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// 今使っているデバイスを識別できるようにする
/// 参考↓
/// https://nekocha.hatenablog.com/entry/2024/03/28/212705
/// </summary>
public class InputDeviceManager : MonoBehaviour
{
    //シングルトン
    public static InputDeviceManager Instance { get; private set; }

    /// <summary>
    /// 入力デバイスの種別
    /// </summary>
    public enum InputDeviceType
    {
        Keyboard,   //キーボード・マウス
        DualShock4, //DualShock(PS4)
        Switch,     //SwitchのProコントローラー
    }

    //直近に操作された入力デバイスタイプ
    public InputDeviceType CurrentDeviceType { get; private set; } = InputDeviceType.Keyboard;

    //各デバイスの全てのキーを1つにバインドしたInputAction(キー種別検知用)
    private InputAction keyboardAnyKey = new InputAction(type: InputActionType.PassThrough, binding: "<Keyboard>/AnyKey", interactions: "Press");
    private InputAction mouseAnyKey = new InputAction(type: InputActionType.PassThrough, binding: "<Mouse>/*", interactions: "Press");
    private InputAction dualShock4AnyKey = new InputAction(type: InputActionType.PassThrough, binding: "<Mouse>/*", interactions: "Press");
}
