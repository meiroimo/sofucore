using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CameraCoverTransparentScript : MonoBehaviour
{
    [SerializeField, Header("被写体")] Transform playerTransform;
    [SerializeField, Header("障害物オブジェクト")] List<GameObject> coverOBJ;
    [SerializeField, Header("遮蔽物のメッシュ")] List<MeshRenderer> coverMesh;

    int mapLayerMask;
    RaycastHit[] hits;
    List<GameObject> tmpHitOBJ;

    void Start()
    {
        InitCoverOBJ();
        mapLayerMask = 1 << LayerMask.NameToLayer("Map");
    }
    void Update()
    {
        // rayを使用し障害物を取得
        RayCastCover();

        //前フレームと障害物が一緒ならreturn
       // if (Enumerable.SequenceEqual(tmpHitOBJ.OrderBy(e => e.name), coverOBJ.OrderBy(e => e.name))) return;

        //メッシュ初期化(一旦全部表示)
        InitCoverMesh();

        //実際にメッシュの表示を消す
        NotDisplayed();

    }

    //rayを使用し障害物を取得
    void RayCastCover()
    {
        // カメラと被写体を結ぶ ray を作成
        Vector3 difference = (playerTransform.transform.position - this.transform.position);
        Vector3 direction = difference.normalized;
        Ray ray = new Ray(this.transform.position, direction);

        hits = Physics.RaycastAll(ray, difference.magnitude, mapLayerMask);     //障害物を全部取得
        tmpHitOBJ = new List<GameObject>();
        for (int i = 0; i < hits.Length; i++)
        {
            tmpHitOBJ.Add(hits[i].transform.gameObject);        //後で比較するためにListに入れる
        }

    }

    //障害物関係のリストの初期化
    void InitCoverOBJ()
    {
        coverOBJ = new List<GameObject>();
        coverMesh = new List<MeshRenderer>();

    }

    //障害物のメッシュ初期化(一旦全部表示)
    void InitCoverMesh()
    {
        for (int i = 0; i < coverMesh.Count; i++)
        {
            coverMesh[i].enabled = true;
        }

        InitCoverOBJ();
    }

    //実際にメッシュの表示を消す
    void NotDisplayed()
    {

        for (int i = 0; i < hits.Length; i++)
        {
            GameObject tmpOBJ = hits[i].transform.gameObject;
            if (tmpOBJ.tag == "Floor") continue;
            coverOBJ.Add(tmpOBJ);
            MeshRenderer tmpMesh = tmpOBJ.GetComponent<MeshRenderer>();
            tmpMesh.enabled = false;
            coverMesh.Add(tmpMesh);
        }

    }
}
