using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/// <summary>
/// ソフビ一覧の各ボタン
/// </summary>
public class PanelButton : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    [Header("ソフビ一覧の各ボタンにソフビデータを入れるスクリプト")]

    [SerializeField] private GameObject TextWindowManegerObj;//パネルイメージOBJ
    [SerializeField] private TextWindow TextWindowManegerSc;//パネルイメージ

    [SerializeField] private GameObject PanelImageobj;//パネルイメージOBJ
    [SerializeField] private Image PanelImage;//パネルイメージ

    public softVinyl SetSofvidata;//設置ソフビデータ

    [SerializeField] private GameObject selectSofviOBJ;//選択中のソフビデータオブジェ
    [SerializeField] private softVinyl selectSofviDeta;//選択中のソフビデータ
    private Outline outline;

    private bool selectPanel;//パネルを選択判定 
    public int Number;//ボタン番号
    [SerializeField] private GameObject ImgStrage;//イメージ画像ストレージスクリプト
    private ImgStrageScript ImgStrageScriptdata;//イメージ画像データストレージ

    [SerializeField] private GameObject SelectTextObj;//セレクトソフビのテキストオブジェクト
    [SerializeField] private SelectText SelectTextSc;//セレクトソフビのクラス

    void Start()
    {
        SelectTextObj = GameObject.Find("SelectStetasText");
        SelectTextSc = SelectTextObj.GetComponent<SelectText>();
        TextWindowManegerObj = GameObject.Find("TextWindowManeger");
        TextWindowManegerSc = TextWindowManegerObj.GetComponent<TextWindow>();
        ImgStrage = GameObject.Find("ImgStrage");
        ImgStrageScriptdata = ImgStrage.GetComponent<ImgStrageScript>();
        selectSofviOBJ = GameObject.Find("selectSofvi");
        PanelImageobj = gameObject.transform.GetChild(0).gameObject;
        PanelImage = PanelImageobj.GetComponent<Image>();
        SetSofvidata = this.gameObject.GetComponent<softVinyl>();
        selectSofviDeta = selectSofviOBJ.GetComponent<softVinyl>();
        outline = gameObject.GetComponent<Outline>();
        outline.enabled = false;
        selectPanel = false;

    }

    void Update()
    {
        setImage();
        if (selectSofviDeta.selectButton != this.gameObject)
        {
            selectPanel = false;
            outline.enabled = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)//マウスが重なったら
    {
        SelectTextSc.setText(SetSofvidata);
        TextWindowManegerSc.OnHoverEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TextWindowManegerSc.OnHoverExit();
    }
    public void onclickButton()
    {
        if(!selectPanel && SetSofvidata.sofvimodel!= softVinyl.SOFVINUMBER.NULL)
        {
            setselectSofviData();
            selectPanel = true;
            outline.enabled = true;
        }
        else
        {
            if (selectSofviDeta.selectButton==this.gameObject)
            {
                againClick();
            }
        }
    }
    public void setImage()
    {
        //ソフビデータがなかった場合は×表示
        if (SetSofvidata == null)
        {
            PanelImage.sprite = ImgStrageScriptdata.sprites[0];
        }
        //表示している画像とデータの画像が違う場合に変更
        else if (PanelImage.sprite!= ImgStrageScriptdata.sprites[(int)SetSofvidata.sofvimodel])
        {
            PanelImage.sprite = ImgStrageScriptdata.sprites[(int)SetSofvidata.sofvimodel];
        }
    }
    void againClick()//セレクトデータをリセット
    {
        selectSofviDeta.ResetParameter();
        selectPanel = false;
        outline.enabled = false;
    }
    private void setselectSofviData()//選択ソフビデータに自分のデータを渡す。
    {
        selectSofviDeta.sofvimodel = SetSofvidata.sofvimodel;
        selectSofviDeta.cost = SetSofvidata.cost;
        selectSofviDeta.skill = SetSofvidata.skill;
        selectSofviDeta.theme = SetSofvidata.theme;
        selectSofviDeta.ListNumber = SetSofvidata.ListNumber;
        selectSofviDeta.buffMainstatus = SetSofvidata.buffMainstatus;
        selectSofviDeta.buffSubstatus1 = SetSofvidata.buffSubstatus1;
        selectSofviDeta.buffSubstatus2 = SetSofvidata.buffSubstatus2;
        selectSofviDeta.buffSubstatus3 = SetSofvidata.buffSubstatus3;
        selectSofviDeta.BuffMainParameter = SetSofvidata.BuffMainParameter;
        selectSofviDeta.BuffSubparameter1 = SetSofvidata.BuffSubparameter1;
        selectSofviDeta.Buffparameter2 = SetSofvidata.Buffparameter2;
        selectSofviDeta.Buffparameter3 = SetSofvidata.Buffparameter3;
        selectSofviDeta.selectButton = this.gameObject;
        selectSofviDeta.selectCheck =true;
    }
}
