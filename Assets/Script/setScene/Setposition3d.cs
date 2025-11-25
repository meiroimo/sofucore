using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEngine;
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
    public GameObject[] model;
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

    void SofviIns()　//ソフビ生成
    {
        setpositionsofviDeta();//selectしたソフビデータを設置場所に反映
                               //３Ðモデルを空箱に生成
       // GameObject ins = Instantiate(model[(int)SetSofviManeger.selectSofviDeta.SofviData.sofvimodel], this.transform.position, Quaternion.identity);
        GameObject ins = Instantiate(SetSofviBoxScript.SetSofviModelPrefabs[(int)SetSofviManeger.selectSofviDeta.SofviData.sofvimodel], this.transform.position, Quaternion.identity);
        ins.transform.parent = this.transform;
        ins.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
        //ストレージからデータの削除
        sofviSotrage.sofviStrageList[softVinylData.SofviData.ListNumber] = null;
        //sofviSotrage.ListUpdate = true;//リストの更新判定をオン
        //セレクトデータのリセット
        SetSofviManeger.selectSofviDeta.SofviData.ResetParameter();
        //ボタンのソフビデータもreset
        sofviVinylListSc.childrensoftVinyl[softVinylData.SofviData.ListNumber].SofviData.ResetParameter();
        checkmodelset = false;//生成するクリック判定をfalse
        ColloderOff();//設置場所のコライダーオフ再度クリックされないように
        softVinylData.SofviData.checksetpotion = true;//セットされたかの判定をオンに
        SetSofviManeger.statusup();

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
       // GameObject ins = Instantiate(model[(int)softVinylData.SofviData.sofvimodel], this.transform.position, Quaternion.identity);
        GameObject ins = Instantiate(SetSofviBoxScript.SetSofviModelPrefabs[(int)SetSofviManeger.selectSofviDeta.SofviData.sofvimodel], this.transform.position, Quaternion.identity);


        ins.transform.parent = this.transform;
        ins.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
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
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(this.gameObject.transform.GetChild(1).gameObject);
            translucentflg = false;
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
    //この関数はセットポジションでよくね？
    //セレクト中のソフビデータを設置ソフビデータにセットする関数
    public void setpositionsofviDeta()
    {
        if (SetSofviManeger.selectSoftVinylData.SofviData.selectCheck)
        {
            Debug.Log("セレクトの"+SetSofviManeger.selectSoftVinylData.SofviData.sofvimodel);
            Debug.Log("設置場所の" + softVinylData.SofviData.sofvimodel);

            softVinylData.SofviData = SetSofviManeger.selectSoftVinylData.SofviData;
            Debug.Log("代入後の設置場所の" + softVinylData.SofviData.sofvimodel);

        }
    }
}
