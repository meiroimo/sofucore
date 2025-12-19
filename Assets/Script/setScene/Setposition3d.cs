using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Setposition3d : MonoBehaviour
{
    // Start is called before the first frame update
    public bool checkmodelset = false;//クリックされてセットされるルカ判定
    public softVinyl softVinylData;
    public BoxCollider boxCollider;//設置個所のボックスコライダー
    public SetSofviManeger SetSofviManeger;//ステータスアップ反映関数を使用するため、掴む
    public SofviVinylList sofviVinylListSc;//ソフビリストスクリプト
    [Header("半透明マテリアル")] public Material translucent;
    public bool translucentflg=false;//半透明表示判定
    public bool rathit = false;//レイが当たっていたら判定
    public int setpotionNumber=0;
    [SerializeField] private GameObject SetSofviModelBox;//設置するソフビの全モデル
    [SerializeField] private SetSofviBox SetSofviBoxScript;//設置するソフビの全モデルが入ってるスクリプト



    Camera mainCamera; // 撮影したいカメラ
    void Start()
    {
        SetSofviModelBox = GameObject.Find("modelBox");//モデルボックスのオブジェクトの掴む
        SetSofviBoxScript = SetSofviModelBox.GetComponent<SetSofviBox>();//設置すルソフビの全モデルが入っているスクリプトを掴む
        softVinylData = gameObject.GetComponent<softVinyl>();//自分のソフビクラスコンポーネントを掴む
        boxCollider = gameObject.GetComponent<BoxCollider>();//自分のボックスコライダ―を掴む
        GameObject setsofvimanegarobj = GameObject.Find("SetsofviManeger");//ソフビマネージャーのオブジェクトの掴む
        SetSofviManeger = setsofvimanegarobj.GetComponent<SetSofviManeger>();//ソフビマネージャーのスクリプトを掴む

    }

    // Update is called once per frame
    void Update()
    {
        DestryTranslucentSofvi();
        if (checkmodelset) //クリックされてcheckmodelsetがtrueにされたら(SetSofviManegerで)、ソフビを生成
        {
            SofviIns();
        }
    }

    public void Reset()
    {
        checkmodelset = false;
        translucentflg = false;
        rathit = false;


    }


    void SofviIns()　//ソフビ生成
    {

        setpositionsofviDeta();//selectしたソフビデータを設置場所に反映
                               //３Ðモデルを空箱に生成
        GameObject ins = Instantiate(SetSofviBoxScript.SetSofviModelPrefabs[(int)SetSofviManeger.selectSofviDeta.SofviData.sofvimodel], this.transform.position, Quaternion.identity);
        ins.transform.parent = this.transform;
        ins.transform.rotation = this.transform.rotation;
        ins.transform.localPosition = new Vector3(0.0f, -0.5f, 0.0f);
        ins.GetComponent<BoxCollider>().enabled = false;//生成したモデルの当たり判定をオフ
        checkmodelset = false;//生成するクリック判定をfalse
       // ColloderOff();//設置場所のコライダーオフ再度クリックされないように
        softVinylData.SofviData.checksetpotion = true;//セットされたかの判定をオンに
        if(!SetSofviManeger.selectSofviDeta.SofviData.isSelectStandSofvi)
        {
            //ステータスアップ反映
            SetSofviManeger.statusup();
            //ストレージからデータの削除
            sofviSotrage.sofviStrageList[softVinylData.SofviData.ListNumber] = null;

            //ボタンのソフビデータもリセット
            sofviVinylListSc.childrensoftVinyl[softVinylData.SofviData.ListNumber].SofviData.ResetParameter();
            //セレクトデータのリセット
            SetSofviManeger.selectSofviDeta.SofviData.ResetParameter();
        }
        else
        {
            int resetpotionnum = SetSofviManeger.selectSoftVinylData.SofviData.selectButton.GetComponent<Setposition3d>().setpotionNumber;
            Destroy(SetSofviManeger.AllSetobject.transform.GetChild(resetpotionnum).gameObject.transform.GetChild(1).gameObject);
            SetSofviManeger.setSoftVinylData[resetpotionnum].SofviData.ResetParameter();
            SetSofviManeger.statusup();

        }


        //スクショ
        StartCoroutine(CaptureAndGo());

    }
    private IEnumerator CaptureAndGo()
    {
        if(mainCamera == null) mainCamera = GameObject.Find("SetSceneCamera").GetComponent<Camera>();
        yield return null;

        yield return ScreenshotManagerScript.CaptureFromCamera(mainCamera);
    }
    public   void TranslucentSofviIns()　//半透明ソフビ生成関数
    {
        setpositionsofviDeta();
        //３Ðモデルを空箱に生成
        GameObject ins = Instantiate(SetSofviBoxScript.SetSofviModelPrefabs[(int)SetSofviManeger.selectSofviDeta.SofviData.sofvimodel], this.transform.position, Quaternion.identity);


        ins.transform.parent = this.transform;
        ins.transform.rotation = this.transform.rotation;
         ins.transform.localPosition = new Vector3(0.0f, -0.5f, 0.0f);
        //ins.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
        Debug.Log(ins.transform.rotation);
        ins.GetComponent<MeshRenderer>().material = translucent;//マテリアルを半透明に
        ins.GetComponent<BoxCollider>().enabled = false;//例が当たらないようにコライダーオフ
        translucentflg = true;//半透明表示判定をオンに
    }
    //半透明ソフビの削除
    public void DestryTranslucentSofvi()
    {
        //マウスが離れたら、消す
        if (!rathit && translucentflg)
        {
           // this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(this.gameObject.transform.GetChild(1).gameObject);
            translucentflg = false;
            softVinylData.SofviData.checksetpotion = false;//セットされたかの判定をオフ

        }
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    void ColloderOff() //クリック判定を取っているボックスコライダーをオフ
    {
        boxCollider.enabled = false;
    }
    //セレクト中のソフビデータを設置ソフビデータにセットする関数
    public void setpositionsofviDeta()
    {
        if (SetSofviManeger.selectSoftVinylData.SofviData.selectCheck)
        {
            softVinylData.SofviData = SetSofviManeger.selectSoftVinylData.SofviData.copy();
            softVinylData.SofviData.checksetpotion = false;

           // Debug.Log(softVinylData.SofviData.buffMainstatus);
        }
    }
}
