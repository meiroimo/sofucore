using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelWindowBox : MonoBehaviour
{
    public Camera cam;//mainカメラ


    public RectTransform Basepanel;//パネルウィンドウ全体のベースパネル
    public GameObject ImageOBJ;//表示イメージのレクトトランスフォーム
    private RectTransform ImageRectTrs;
    private Image selectImage;
    public Text debugText;
    public int ofsetx;
    public int ofsety;
    public Vector2 MousePos;
    public Vector2 MouseViewPort;
    public Vector2 MousePointPos;
    public softVinyl selectSofvi;//セレクト中のソフビのデータ
    public GameObject popupTextOBJ;//ポップアップウィンドウテキストオブジェ
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
    //    popupTextRectTrs = popupTextOBJ.gameObject.GetComponent<RectTransform>();

        selectImage = ImageOBJ.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        MousePointPos = Input.mousePosition;//画面上のマウスの位置を取得
        ImageRectTrs.position = new Vector2(MousePointPos.x, MousePointPos.y);//レンダーモードがoberlayだとそのままマウスの位置を代入する事ができる
      //  popupTextRectTrs.anchoredPosition = new Vector2(MousePos.x, MousePos.y);

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
