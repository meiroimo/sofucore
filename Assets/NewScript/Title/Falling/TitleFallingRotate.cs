using UnityEngine;

public class TitleFallingRotate : MonoBehaviour
{
    public float fallSpeed = 2.5f;
    public Vector3 rotateSpeed;

    [Header("消滅するY座標")]
    public float destroyY = -6f;

    void Start()
    {
        // 回転速度をランダム化
        rotateSpeed = new Vector3(
            Random.Range(-120f, 120f),
            Random.Range(-120f, 120f),
            Random.Range(-120f, 120f)
        );
    }

    void Update()
    {
        // 落下
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // 回転
        transform.Rotate(rotateSpeed * Time.deltaTime);

        // 画面外に出たら削除
        if (transform.position.y <= destroyY)
        {
            Destroy(gameObject);
        }
    }
}
