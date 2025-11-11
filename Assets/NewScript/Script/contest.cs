using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class contest : MonoBehaviour
{
    private void Update()
    {
        if (Gamepad.current == null)
        {
            Debug.Log("ゲームパッドが接続されていません。");
            return;
        }

        // 左スティックの入力を取得
        Vector2 leftStick = Gamepad.current.leftStick.ReadValue();
        if (leftStick != Vector2.zero)
        {
            Debug.Log($"左スティック: {leftStick}");
        }

        // 右スティックの入力を取得
        Vector2 rightStick = Gamepad.current.rightStick.ReadValue();
        if (rightStick != Vector2.zero)
        {
            Debug.Log($"右スティック: {rightStick}");
        }

        // Aボタン（南ボタン）を押したかどうか
        if (Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            Debug.Log("Aボタンが押されました。");
        }

        // トリガーの確認
        if (Gamepad.current.rightTrigger.ReadValue() > 0.1f)
        {
            Debug.Log($"右トリガー: {Gamepad.current.rightTrigger.ReadValue()}");
        }

        if (Gamepad.current.leftTrigger.ReadValue() > 0.1f)
        {
            Debug.Log($"左トリガー: {Gamepad.current.leftTrigger.ReadValue()}");
        }
    }
}
