using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseExample : MonoBehaviour
{
    private void Update()
    {
        //���݂̃}�E�X���
        var current = Mouse.current;

        //�}�E�X�ڑ��`�F�b�N
        if(current == null)
        {
            //�}�E�X���ڑ�����Ă��Ȃ���
            //Mouse.current��null�ɂȂ�
            return;
        }

        //ReadValue():�X�N���[�����W�擾

        //�}�E�X�J�[�\���ʒu�擾
        var cursorPosition = current.position.ReadValue();

        //���{�^���̓��͏�Ԏ擾
        var leftButton = current.leftButton;

        //���{�^���������ꂽ�u�Ԃ��ǂ���
        if(leftButton.wasPressedThisFrame)
        {
            Debug.Log($"�{�^���������ꂽ�I{cursorPosition}");
        }

        //���{�^���������ꂽ�u�Ԃ��ǂ���
        if(leftButton.wasReleasedThisFrame)
        {
            Debug.Log($"�{�^���������ꂽ�I{cursorPosition}");
        }

        //���{�^����������Ă��邩�ǂ���
        if(leftButton.isPressed)
        {
            Debug.Log($"�{�^����������Ă���I{cursorPosition}");
        }
    }
}
