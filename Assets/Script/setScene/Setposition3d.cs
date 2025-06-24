using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Setposition3d : MonoBehaviour
{
    // Start is called before the first frame update
    public bool checkmodelset = false;//クリックされてセットされるルカ判定
    public softVinyl softVinylData;
    public BoxCollider boxCollider;//設置個所のボックスコライダー
    public SetSofviManeger SetSofviManeger;//ステータスアップ反映関数を使用するため、掴む
    [Header("半透明マテリアル")] public Material translucent;
    public bool translucentflg=false;//半透明表示判定
    public bool rathit = false;//レイが当たっていたら判定
    public int setpotionNumber=0;
    public GameObject[] model;
    void Start()
    {
        //model = new GameObject[5];
        softVinylData = gameObject.GetComponent<softVinyl>();//自分のソフビクラスコンポーネントを掴む
        boxCollider = gameObject.GetComponent<BoxCollider>();//自分のボックスコライダ―を掴む
        GameObject setsofvimanegarobj = GameObject.Find("SetsofviManeger");//ソフビマネージャーのオブジェクトの掴む
        SetSofviManeger = setsofvimanegarobj.GetComponent<SetSofviManeger>();

    }

    // Update is called once per frame
    void Update()
    {
        DestryTranslucentSofvi();
        if (checkmodelset) //クリックされてcheckmodelsetがtrueにされたら、ソフビを生成
        {
            SofviIns();
        }
      
        
    }

    void SofviIns()　//ソフビ生成関数
    {
        SetSofviManeger.setpositionsofviDeta(softVinylData);
        //３Ðモデルを空箱に生成
        GameObject ins = Instantiate(model[(int)softVinylData.sofvimodel], this.transform.position, Quaternion.identity);
        ins.transform.parent = this.transform;
        ins.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        //Vector3 pos = ins.transform.position;
        //pos.y -= 0.45f;
        //ins.transform.position = pos;

        checkmodelset = false;//生成するクリック判定をfalse
        ColloderOff();//設置場所のコライダーオフ再度クリックされないように
        softVinylData.checksetpotion = true;//セットされたかの判定をオンに
        SetSofviManeger.statusup();

      //  if (!Physics.Raycast(ray, out hit)||)//レイに当たっている時

    }

    public   void TranslucentSofviIns()　//半透明ソフビ生成関数
    {
        SetSofviManeger.setpositionsofviDeta(softVinylData);
        //３Ðモデルを空箱に生成
        GameObject ins = Instantiate(model[(int)softVinylData.sofvimodel], this.transform.position, Quaternion.identity);
       // Debug.Log(softVinylData.Buffparameter);

        ins.transform.parent = this.transform;
        ins.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        //Vector3 pos = ins.transform.position;
        //pos.y -= 0.45f;
        //ins.transform.position = pos;
        ins.GetComponent<MeshRenderer>().material = translucent;//マテリアルを半透明に
        ins.GetComponent<BoxCollider>().enabled = false;//例が当たらないようにコライダーオフ
        translucentflg = true;//半透明表示判定をオンに

    }
    public void DestryTranslucentSofvi()
    {
        if(!rathit&& translucentflg)
        {
            Destroy(this.gameObject.transform.GetChild(0).gameObject);
            translucentflg = false;
        }

    }


    void ColloderOff() //クリック判定を取っているボックスコライダーをオフ
    {

        boxCollider.enabled = false;
    }
}
