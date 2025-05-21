using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class VirtualMouseManager : MonoBehaviour
{
    private InputDevice virtualMouse;
    private static VirtualMouseManager instance;


    private void Awake()
    {
        // シングルトンパターンの実装
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject); // シーン遷移してもオブジェクトを破棄しない

        // 仮想マウスの初期化
        InitializeVirtualMouse();
    }

    private void Start()
    {
        StartCoroutine(WaitAndCheckMouse());
    }

    private void InitializeVirtualMouse()
    {
        // すでに登録されている場合はスキップ
        if (virtualMouse != null) return;

        virtualMouse = InputSystem.AddDevice("VirtualMouse");

        if (virtualMouse == null)
        {
            Debug.LogError("Failed to create Virtual Mouse!");
        }
    }

    private void OnDestroy()
    {
        // シングルトンが削除される場合、InputSystem から Virtual Mouse を削除
        if (virtualMouse != null)
        {
            InputSystem.RemoveDevice(virtualMouse);
        }
    }

    private IEnumerator WaitAndCheckMouse()
    {
        yield return new WaitForSeconds(0.1f); // 100ms 待つ

        virtualMouse = InputSystem.GetDevice("VirtualMouse");
        if (virtualMouse == null)
        {
            Debug.LogWarning("Virtual Mouse is not yet initialized. Adding now...");
            virtualMouse = InputSystem.AddDevice("VirtualMouse");
        }

        if (virtualMouse != null)
        {
            Debug.Log("Virtual Mouse successfully initialized!");
        }
        else
        {
            Debug.LogError("Failed to initialize Virtual Mouse.");
        }
    }
}
