using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻撃範囲の表示(三角形で扇型の攻撃範囲を作成)
/// </summary>
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class FilledAttackCone : MonoBehaviour
{
    public float radius = 5f;//扇の半径(どれくらい遠くまで届くか)
    public float angle = 60f;//扇の角度
    public int segments = 30;//扇を構成する三角形の数
    public float yOffset = 0.05f;//地面から少し浮かせる高さ

    private void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = GenerateConeMesh();
    }

    private Mesh GenerateConeMesh()
    {
        Mesh mesh = new Mesh();

        // 頂点リスト（中心 + 扇形の端）
        Vector3[] vertices = new Vector3[segments + 2];
        vertices[0] = new Vector3(0, yOffset, 0); // 中心

        float halfAngle = angle / 2f;
        float step = angle / segments;

        for (int i = 0; i <= segments; i++)
        {
            //-halfAngle から +halfAngle まで角度をずらしながら点を配置。
            float currentAngle = -halfAngle + step * i;
            //uaternion.Euler で回転させて、Vector3.forward を回転し、距離をかけて円弧上に点を並べている。
            Quaternion rot = Quaternion.Euler(0, currentAngle, 0);
            Vector3 dir = rot * Vector3.forward * radius;
            dir.y = yOffset;
            vertices[i + 1] = dir;
        }

        // 三角形リスト
        //中心 + 外周2点 で「扇形の三角形」を作って、それを n 回繰り返す。
        int[] triangles = new int[segments * 3];
        for (int i = 0; i < segments; i++)
        {
            triangles[i * 3 + 0] = 0;         // 中心
            triangles[i * 3 + 1] = i + 1;     // 1つ目の点
            triangles[i * 3 + 2] = i + 2;     // 2つ目の点
        }

        //頂点と三角形をメッシュにセット
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
}