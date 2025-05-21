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
    public softVinyl selectSofvi;//�Z���N�g���̃\�t�r�̃f�[�^
    public GameObject popupTextOBJ;//�|�b�v�A�b�v�E�B���h�E�e�L�X�g�I�u�W�F
    private RectTransform popupTextRectTrs;

    public Text selectSofviText;
    public Text ComparisonSofiviText;
    public int WindowOfsetx;
    public int WindowOfsety;
    public Vector2 MousePos_Window;

    void Start()
    {
        cam = Camera.main;
        ofsetx = 30;
        ofsety = -30;
        ImageRectTrs = ImageOBJ.gameObject.GetComponent<RectTransform>();
        WindowOfsetx = -150;
        WindowOfsety = 150;
        popupTextRectTrs = popupTextOBJ.gameObject.GetComponent<RectTransform>();

        selectImage = ImageOBJ.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MouseViewportPoint = cam.ScreenToViewportPoint(Input.mousePosition);
        MousePos.x = (Basepanel.sizeDelta.x * MouseViewportPoint.x) + ofsetx;
        MousePos.y = (Basepanel.sizeDelta.y * MouseViewportPoint.y) + ofsety;
        ImageRectTrs.anchoredPosition = new Vector2(MousePos.x, MousePos.y);
        MousePos_Window.x = (Basepanel.sizeDelta.x * MouseViewportPoint.x) + WindowOfsetx;
        MousePos_Window.y = (Basepanel.sizeDelta.y * MouseViewportPoint.y) + WindowOfsety;
        popupTextRectTrs.anchoredPosition = new Vector2(MousePos_Window.x, MousePos_Window.y);

        debugText.text = "\n" + ofsetx+ "\n" + ofsety;

        if(selectSofvi.selectCheck)
        {
            selectImage.sprite = selectSofvi.sofviImage;
            ImageOBJ.SetActive(true);
        }
        else
        {
            ImageOBJ.SetActive(false);

        }

    }
}
