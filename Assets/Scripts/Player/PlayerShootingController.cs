using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    [Header("弾の発射間隔")]
    public float shootInterval; // 弾の発射間隔
    [Header("弾のプレファブ")]
    public GameObject bulletPrefab; // 弾のプレファブ

    private bool isShooting = false; // 発射中かどうかのフラグ
    private float shootTimer = 0f; // 発射タイマー



    public void StartShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    private void Update()
    {
        if (isShooting)
        {
            // タイマーの更新
            shootTimer += Time.deltaTime;

            // 弾の発射間隔を超えたら弾を発射
            if (shootTimer >= shootInterval)
            {
                // Shiftキー入力の状態に応じて発射方法を変える
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    // Shiftキー入力ありの場合、プレイヤーの左右から発射
                    ShootOnShift();
                }
                else
                {
                    // Shiftキー入力なしの場合、プレイヤーの正面から発射
                    ShootOffShift();
                }

                shootTimer = 0f; // タイマーをリセット
            }
        }
        else
        {
            shootTimer = 0f; // タイマーをリセット
        }
    }

    private void ShootOffShift()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    //Shiftキー入力時の攻撃
    private void ShootOnShift()
    {
        Quaternion leftRotation = Quaternion.Euler(0f, 0f, -90f);
        Quaternion rightRotation = Quaternion.Euler(0f, 0f, 90f);

        Vector3 leftOffset = transform.TransformDirection(Vector3.left);
        Vector3 rightOffset = transform.TransformDirection(Vector3.right);


        Instantiate(bulletPrefab, transform.position + leftOffset, transform.rotation);
        Instantiate(bulletPrefab, transform.position + rightOffset, transform.rotation);
    }
}
