using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelButton : MonoBehaviour
{
    [SerializeField] private GameObject PanelImage;//パネルイメージOBJ
    [SerializeField] private GameObject PanelUI;//パネルウィンドウUI
    [SerializeField] public softVinyl SetSofvidata;//設置ソフビデータ

    public GameObject selectSofviOBJ;//選択中のソフビデータオブジェ
    public softVinyl selectSofviDeta;//選択中のソフビデータオブジェ
    private Outline outline;

    bool selectPanel;//パネルを選択判定
    public bool selectCheck;
    public GameObject PoptextWindowObj;//ポップアップウィンドウオブジェ
    public Text PopTextSelect;//ポップアップテキストセレクトソフビ
    public Text PopTextonpointar;//ポップアップテキスト重なったソフビ
    public string[] themeText;//themeの文字列配列
    public string[] skillText;//skillの文字列配列
    public string[] nameText;//nameの文字列配列
    public int Number;//ボタン番号
    public GameObject ImgStrage;//イメージ画像ストレージスクリプト
    ImgStrageScript ImgStrageScriptdata;//イメージ画像データストレージ
    // Start is called before the first frame update
    void Start()
    {
        ImgStrage = GameObject.Find("ImgStrage");
        ImgStrageScriptdata = ImgStrage.GetComponent<ImgStrageScript>();

        selectPanel = false;
        PanelImage = gameObject.transform.GetChild(0).gameObject;
        SetSofvidata = this.gameObject.GetComponent<softVinyl>();//自身のソフビスクリプトを掴む
        //Debug.Log(SetSofvidata);
        selectSofviDeta = selectSofviOBJ.GetComponent<softVinyl>();

        outline = gameObject.GetComponent<Outline>();
        outline.enabled = false;
  //      PopTextSelect =PoptextWindowObj.transform.GetChild(0).gameObject.GetComponent<Text>();
       // PopTextonpointar = PoptextWindowObj.transform.GetChild(1).gameObject.GetComponent<Text>();
        themeText = new string[21];
        skillText = new string[5];
        nameText = new string[102];
        themeTextset();
        skillTextset();
        nameTextset();
    }

    // Update is called once per frame
    void Update()
    {
        
        setImage();

        if (selectSofviDeta.selectButton != this.gameObject)
        {
            selectPanel = false;
            outline.enabled = false;

        }
    }
    public void onclickButton()
    {

        if(!selectPanel && SetSofvidata.sofvimodel!= softVinyl.SOFVINUMBER.NULL)
        {
            setselectSofviData();
            selectPanel = true;
            outline.enabled = true;
       //     PoptextWindowObj.SetActive(false);
        }
        else
        {

            if (selectSofviDeta.selectButton==this.gameObject)
            {
                againClick();
                Debug.Log("同じボタン押された");

                //    PoptextWindowObj.SetActive(false);
            }
        }

        Debug.Log("押された");
    }
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    if (selectSofviDeta.selectButton != this.gameObject&& selectSofviDeta.selectCheck)
    //    {
    //        setTextPopTextWindow();

    //        PoptextWindowObj.SetActive(true);
    //    }
    //    else
    //    {
    //        PoptextWindowObj.SetActive(false);
    //    }


    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    PoptextWindowObj.SetActive(false);
    //}

    void setImage()
    {



        PanelImage.GetComponent<Image>().sprite = ImgStrageScriptdata.sprites[(int)SetSofvidata.sofvimodel];


    }
    void againClick()//セレクトデータをリセット
    {
        selectSofviDeta.cost = 0;
        selectSofviDeta.skill = softVinyl.SKILLNUM.NULL;
        selectSofviDeta.theme =softVinyl.themeNuｍ.NULL;
        selectSofviDeta.ListNumber = 0;
        selectSofviDeta.buffMainstatus = softVinyl.BUFFSTATUSNUM.NULL;
        selectSofviDeta.buffSubstatus1 = softVinyl.BUFFSTATUSNUM.NULL;
        selectSofviDeta.buffSubstatus2 = softVinyl.BUFFSTATUSNUM.NULL;
        selectSofviDeta.buffSubstatus3 = softVinyl.BUFFSTATUSNUM.NULL;
        selectSofviDeta.Buffparameter = 0;
        selectSofviDeta.Buffparameter1 = 0;
        selectSofviDeta.Buffparameter2 = 0;
        selectSofviDeta.Buffparameter3 = 0;
        selectSofviDeta.buffName = null;
        selectSofviDeta.buffName1 = null;
        selectSofviDeta.buffName2 = null;
        selectSofviDeta.buffName3 = null;
        selectSofviDeta.selectButton = null;
        selectSofviDeta.selectCheck = false;
        selectPanel = false;
        outline.enabled = false;

    }
    private void setselectSofviData()
    {


        // selectSofviDeta = SetSofvidata;
        

        selectSofviDeta.sofvimodel = SetSofvidata.sofvimodel;


        selectSofviDeta.cost = SetSofvidata.cost;
        selectSofviDeta.skill = SetSofvidata.skill;
        selectSofviDeta.theme = SetSofvidata.theme;
        selectSofviDeta.ListNumber = SetSofvidata.ListNumber;
        selectSofviDeta.buffMainstatus = SetSofvidata.buffMainstatus;
        selectSofviDeta.buffSubstatus1 = SetSofvidata.buffSubstatus1;
        selectSofviDeta.buffSubstatus2 = SetSofvidata.buffSubstatus2;
        selectSofviDeta.buffSubstatus3 = SetSofvidata.buffSubstatus3;
        selectSofviDeta.Buffparameter = SetSofvidata.Buffparameter;
        selectSofviDeta.Buffparameter1 = SetSofvidata.Buffparameter1;
        selectSofviDeta.Buffparameter2 = SetSofvidata.Buffparameter2;
        selectSofviDeta.Buffparameter3 = SetSofvidata.Buffparameter3;
        selectSofviDeta.buffName = SetSofvidata.buffName;
        selectSofviDeta.buffName1 = SetSofvidata.buffName1;
        selectSofviDeta.buffName2 = SetSofvidata.buffName2;
        selectSofviDeta.buffName3 = SetSofvidata.buffName3;
        selectSofviDeta.selectButton = this.gameObject;
        selectSofviDeta.selectCheck =true;
       // Debug.Log(selectSofviDeta.Buffparameter);

    }
    void setTextPopTextWindow()//ポップアップウィンドウのテキストをセット
    {

        PopTextSelect.text = "選択中："+ nameText[(int)selectSofviDeta.sofvimodel] + "\n" + themeText[(int)selectSofviDeta.theme] + "\n" + skillText[(int)selectSofviDeta.skill] + "\n" + "コスト" +selectSofviDeta.cost ;
        PopTextonpointar.text = "比較中：" + nameText[(int)SetSofvidata.sofvimodel] + "\n" + themeText[(int)SetSofvidata.theme] + "\n" + skillText[(int)SetSofvidata.skill] + "\n" + "コスト" + SetSofvidata.cost;

    }

    void themeTextset()//テーマテキストをセット
    {
        themeText[1] = "テーマ１";
        themeText[2] = "テーマ２";
        themeText[3] = "テーマ３";
        themeText[4] = "テーマ４";
        themeText[5] = "テーマ５";
        themeText[6] = "テーマ６";
        themeText[7] = "テーマ７";
        themeText[8] = "テーマ８";
        themeText[9] = "テーマ９";
        themeText[10] = "テーマ１０";
        themeText[11] = "テーマ１１";
        themeText[12] = "テーマ１２";
        themeText[13] = "テーマ１３";
        themeText[14] = "テーマ１４";
        themeText[15] = "テーマ１５";
        themeText[16] = "テーマ１６";
        themeText[17] = "テーマ１７";
        themeText[18] = "テーマ１８";
        themeText[19] = "テーマ１９";
        themeText[20] = "テーマ２０";

    }
    void skillTextset()//スキルテキストのセット
    {

        skillText[1] = "スキル１";
        skillText[2] = "スキル２";
        skillText[3] = "スキル３";
        skillText[4] = "スキル４";

    }

    void nameTextset()//スキルテキストのセット
    {
        for(int i=1;i<(int)softVinyl.SOFVINUMBER.MAX;i++)
        {
            nameText[i] = "名前"+i;

        }

        
    }
}
