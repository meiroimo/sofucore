using UnityEngine;

public class LineBox : MonoBehaviour
{
    void Start()
    {
        //var line = gameObject.AddComponent<LineRenderer>();

        //// 線の幅
        //line.startWidth = 0.05f;
        //line.endWidth = 0.05f;

        //// 線の頂点数（四角形＋始点に戻る用で5点）
        //line.positionCount = 5;

        //// 線をループさせる（始点に戻る）
        //line.loop = true;

        //// 線の色（マテリアルがなければこれも有効）
        //line.startColor = new Color(0, 1, 0, 0.5f); // 半透明緑
        //line.endColor = new Color(0, 1, 0, 0.5f);

        //// マテリアル（透明な線用）

        //// 座標を設定（XZ平面に正方形）
        //line.SetPositions(new Vector3[] {
        //    new Vector3(-0.5f, 0, -0.5f),
        //    new Vector3(0.5f, 0, -0.5f),
        //    new Vector3(0.5f, 0, 0.5f),
        //    new Vector3(-0.5f, 0, 0.5f),
        //    new Vector3(-0.5f, 0, -0.5f), // 始点に戻る
        //});
    }
}
