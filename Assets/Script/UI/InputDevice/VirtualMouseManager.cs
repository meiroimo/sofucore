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
        // �V���O���g���p�^�[���̎���
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject); // �V�[���J�ڂ��Ă��I�u�W�F�N�g��j�����Ȃ�

        // ���z�}�E�X�̏�����
        InitializeVirtualMouse();
    }

    private void Start()
    {
        StartCoroutine(WaitAndCheckMouse());
    }

    private void InitializeVirtualMouse()
    {
        // ���łɓo�^����Ă���ꍇ�̓X�L�b�v
        if (virtualMouse != null) return;

        virtualMouse = InputSystem.AddDevice("VirtualMouse");

        if (virtualMouse == null)
        {
            Debug.LogError("Failed to create Virtual Mouse!");
        }
    }

    private void OnDestroy()
    {
        // �V���O���g�����폜�����ꍇ�AInputSystem ���� Virtual Mouse ���폜
        if (virtualMouse != null)
        {
            InputSystem.RemoveDevice(virtualMouse);
        }
    }

    private IEnumerator WaitAndCheckMouse()
    {
        yield return new WaitForSeconds(0.1f); // 100ms �҂�

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
