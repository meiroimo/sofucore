using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MousePointerpos : MonoBehaviour
{
    //�摜
    public Image Mouse_Image;
    //Canvas�̕ϐ�
    public Canvas canvas;
    //�L�����o�X���̃��N�g�g�����X�t�H�[��
    public RectTransform canvasRect;
    //�}�E�X�̈ʒu�̍ŏI�I�Ȋi�[��
    public Vector2 MousePos;

    void Start()
    {
        //�}�E�X�|�C���^�[��\��
        Cursor.visible = false;

        //Hierarchy�ɂ���Canvas�I�u�W�F�N�g��T����canvas�ɓ��ꂢ��
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        //canvas���ɂ���RectTransform��canvasRect�ɓ����
        canvasRect = canvas.GetComponent<RectTransform>();

        //Canvas���ɂ���MouseImage��T����Mouse_Image�ɓ����
        Mouse_Image = GameObject.Find("Cursor").GetComponent<Image>();
    }

    void Update()
    {
        /*
         * Canvas��RectTransform���ɂ���}�E�X�̈ʒu��RectTransform�̃��[�J���|�W�V�����ɕϊ�����
         * canvas.worldCamera�̓J����
         * �o�͐��MousePos
         */
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect,
                Input.mousePosition, canvas.worldCamera, out MousePos);

        /*
         * Mouse_Image��\������ʒu��MousePos���g��
         */
        Mouse_Image.GetComponent<RectTransform>().anchoredPosition
             = new Vector2(MousePos.x, MousePos.y);
    }
}
