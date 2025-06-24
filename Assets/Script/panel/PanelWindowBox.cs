using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelWindowBox : MonoBehaviour
{
    public Camera cam;//main�J����


    public RectTransform Basepanel;//�p�l���E�B���h�E�S�̂̃x�[�X�p�l��
    public GameObject ImageOBJ;//�\���C���[�W�̃��N�g�g�����X�t�H�[��
    private RectTransform ImageRectTrs;
    private Image selectImage;
    public Text debugText;
    public int ofsetx;
    public int ofsety;
    public Vector2 MousePos;
    public Vector2 MouseViewPort;
    public Vector2 MousePointPos;
    public softVinyl selectSofvi;//�Z���N�g���̃\�t�r�̃f�[�^
    public GameObject popupTextOBJ;//�|�b�v�A�b�v�E�B���h�E�e�L�X�g�I�u�W�F
    private RectTransform popupTextRectTrs;

    public Text selectSofviText;
    public Text ComparisonSofiviText;
    public int WindowOfsetx;
    public int WindowOfsety;
    public Vector2 MousePos_Window;
    public GameObject ImgStrage;//�C���[�W�摜�X�g���[�W�X�N���v�g
    ImgStrageScript ImgStrageScriptdata;//�C���[�W�摜�f�[�^�X�g���[�W


    void Start()
    {
        ImgStrage = GameObject.Find("ImgStrage");
        ImgStrageScriptdata = ImgStrage.GetComponent<ImgStrageScript>();

        cam = Camera.main;
        ofsetx = 30;
        ofsety = -30;
        ImageRectTrs = ImageOBJ.gameObject.GetComponent<RectTransform>();
        WindowOfsetx = -150;
        WindowOfsety = 150;
    //    popupTextRectTrs = popupTextOBJ.gameObject.GetComponent<RectTransform>();

        selectImage = ImageOBJ.transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        MousePointPos = Input.mousePosition;//��ʏ�̃}�E�X�̈ʒu���擾
        ImageRectTrs.position = new Vector2(MousePointPos.x, MousePointPos.y);//�����_�[���[�h��oberlay���Ƃ��̂܂܃}�E�X�̈ʒu�������鎖���ł���
      //  popupTextRectTrs.anchoredPosition = new Vector2(MousePos.x, MousePos.y);

        debugText.text = "\n" + ofsetx+ "\n" + ofsety;

        if(selectSofvi.selectCheck)
        {
            selectImage.sprite = ImgStrageScriptdata.sprites[(int)selectSofvi.sofviImage];
            ImageOBJ.SetActive(true);
        }
        else
        {
            ImageOBJ.SetActive(false);

        }

    }
}
