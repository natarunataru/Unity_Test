using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移動速度")]
    public float speed;          // 移動速度
    [Header("低速率（％）")]
    public float slowRate;    // Shiftキー入力時の速度変化

    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.zero; //移動方向
    private bool isShiftPressed = false; //Shiftキー入力判定

    private PlayerShootingController shootCtrl; // PlayerShootingControllerスクリプトへの参照

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        shootCtrl = GetComponent<PlayerShootingController>(); // PlayerShootingControllerスクリプトの参照を取得
    }

    private void Update()
    {
        // Zキーが押されたら弾を発射
        if (Input.GetKeyDown(KeyCode.Z))
        {
            shootCtrl.StartShooting(); // PlayerShootingControllerの発射開始メソッドを呼び出す
        }
        // Zキーが離されたら弾の発射を停止
        if (Input.GetKeyUp(KeyCode.Z))
        {
            shootCtrl.StopShooting(); // PlayerShootingControllerの発射停止メソッドを呼び出す
        }
    }

    private void FixedUpdate()
    {
        // 移動方向のセット
        SetMoveDirection();

        // プレイヤーを移動させる
        MovePlayer();
    }

    //移動方向のセット
    private void SetMoveDirection()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
        }
        else
        {
            moveDirection = Vector2.zero;
        }

        // Shiftキーの状態を更新する
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isShiftPressed = true;
        }
        else
        {
            isShiftPressed = false;
        }
    }

    //移動する処理-移動速度、移動範囲の計算
    private void MovePlayer()
    {
        // 現在の移動速度を設定
        float currentSpeed = isShiftPressed ? speed * slowRate / 100 : speed;

        // プレイヤーを移動させる
        Vector2 velocity = moveDirection * currentSpeed;
        rb.velocity = velocity;

        // 移動制限：画面外に出ないようにする
        float screenLimitX = Camera.main.orthographicSize * Camera.main.aspect;
        float screenLimitY = Camera.main.orthographicSize;

        float clampedX = Mathf.Clamp(transform.position.x, -screenLimitX, screenLimitX);
        float clampedY = Mathf.Clamp(transform.position.y, -screenLimitY, screenLimitY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
