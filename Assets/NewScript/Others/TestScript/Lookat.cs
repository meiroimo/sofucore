using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//テラシュール：https://tsubakit1.hateblo.jp/entry/2017/07/02/232453
public class Lookat : MonoBehaviour
{
    Plane plane = new Plane();
    float distance = 0;
    Vector3 lookPoint;

    public float Distance { get => distance; set => distance = value; }
    public Vector3 LookPoint { get => lookPoint; set => lookPoint = value; }

    void Update()
    {
        // カメラとマウスの位置を元にRayを準備
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // プレイヤーの高さにPlaneを更新して、カメラの情報を元に地面判定して距離を取得
        plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
        if (plane.Raycast(ray, out distance))
        {
            //if (Input.GetKeyDown(KeyCode.I))
            {
                // 距離を元に交点を算出して、交点の方を向く
                //var lookPoint = ray.GetPoint(distance);
                lookPoint = ray.GetPoint(distance);
                transform.LookAt(lookPoint);

            }
        }
    }
}
