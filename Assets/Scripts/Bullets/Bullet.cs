using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; // 弾の速度
    public int damage; // 弾のダメージ量

    private void Update()
    {
        // 弾の移動
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // 弾の消滅条件
        if (!IsOnScreen())
        {
            Destroy(gameObject);
        }
    }

    private bool IsOnScreen()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
    }

    //弾の衝突処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //衝突対象のタグ名を取得
        string collisionTag = collision.gameObject.tag;
        Debug.Log(collisionTag);
        
        //衝突対象ごとの処理を記述
        switch (collisionTag)
        {
            case "Enemy":
                Destroy(gameObject);
                break;
        }

    }
}
