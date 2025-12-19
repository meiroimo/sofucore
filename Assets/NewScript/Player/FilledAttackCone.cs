using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 攻撃範囲の表示（入力方向に扇を向ける）
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class FilledAttackCone : MonoBehaviour
{
    [Header("距離")]
    public float radius = 5f;
    [Header("範囲")]
    public float angle = 60f;

    private float innerRadius = 1.0f;
    private float outerRadius = 5.0f;
    private int segments = 30;

    [Header("表示位置(Y軸)")]
    public float yOffset = 0.05f;
    public Transform player; // プレイヤー位置（扇の起点）

    private MeshFilter meshFilter;
    private Vector2 inputDirection; // 攻撃方向（右スティック）



    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = GenerateConeMesh();
    }


    private void Update()
    {
        // 攻撃方向があるときだけ表示・向き更新
        if (inputDirection.sqrMagnitude > 0.01f)
        {
            Vector3 flatDirection = new Vector3(inputDirection.x, 0f, inputDirection.y).normalized;

            // 回転させて方向を向かせる
            transform.rotation = Quaternion.LookRotation(flatDirection);

            // プレイヤーの少し上に位置をセット
            transform.position = player.position + Vector3.up * yOffset;

            //gameObject.SetActive(true);
        }
        else
        {
            //gameObject.SetActive(false); // 入力が無いとき非表示
        }
    }

    // 外部から方向をセットする用（InputSystemなどから呼ぶ）
    public void SetDirection(Vector2 dir)
    {
        inputDirection = dir;
    }

    private Mesh GenerateConeMesh()
    {
        Mesh mesh = new Mesh();

        //頂点数を決める（内側、外側）
        int vertCount = (segments + 1) * 2;
        Vector3[] vertices = new Vector3[vertCount];
        
        //三角形の数を決める(四角形を三角形２枚で作成)
        int[] triangles = new int[segments * 6];

        //扇形の角度計算
        float halfAngle = angle / 2f;
        float step = angle / segments;

        //頂点を並べる
        for(int i = 0;i <= segments;i++)
        {
            float currentAngle = -halfAngle + step * i;

            //回転を作る
            Quaternion rot = Quaternion.Euler(0, currentAngle, 0);

            //内側・外側の点を作る
            Vector3 inner = rot * Vector3.forward * innerRadius;
            Vector3 outer = rot * Vector3.forward * outerRadius;

            inner.y = yOffset;
            outer.y = yOffset;

            //配列に入れる
            vertices[i * 2] = inner;
            vertices[i * 2 + 1] = outer;
        }

        //三角形を作る(面を張る)
        int t = 0;
        for(int i = 0;i < segments;i++)
        {
            int i0 = i * 2;
            int i1 = i * 2 + 1;
            int i2 = i * 2 + 2;
            int i3 = i * 2 + 3;

            triangles[t++] = i0;
            triangles[t++] = i1;
            triangles[t++] = i3;

            triangles[t++] = i0;
            triangles[t++] = i3;
            triangles[t++] = i2;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        return mesh;

        //扇形
        #region 
        //Mesh mesh = new Mesh();

        //Vector3[] vertices = new Vector3[segments + 2];
        //vertices[0] = new Vector3(0, yOffset, 0); // 中心

        //float halfAngle = angle / 2f;
        //float step = angle / segments;

        //for (int i = 0; i <= segments; i++)
        //{
        //    float currentAngle = -halfAngle + step * i;
        //    Quaternion rot = Quaternion.Euler(0, currentAngle, 0);
        //    Vector3 dir = rot * Vector3.forward * radius;
        //    dir.y = yOffset;
        //    vertices[i + 1] = dir;
        //}

        //int[] triangles = new int[segments * 3];
        //for (int i = 0; i < segments; i++)
        //{
        //    triangles[i * 3 + 0] = 0;
        //    triangles[i * 3 + 1] = i + 1;
        //    triangles[i * 3 + 2] = i + 2;
        //}

        //mesh.vertices = vertices;
        //mesh.triangles = triangles;
        //mesh.RecalculateNormals();

        //return mesh;
        #endregion
    }
}
