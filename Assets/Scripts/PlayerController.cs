using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float SPEED = 5f;        // 移動速度
    public float SPEED_LOW = 2.5f;  // Shiftキー入力時の移動速度

    private Vector3 moveDirection = Vector3.zero;
    private bool isShiftPressed = false;

    void Update()
    {
        // キー入力を検出して移動方向を設定する
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput < 0)
        {
            moveDirection = Vector3.left;
        }
        else if (horizontalInput > 0)
        {
            moveDirection = Vector3.right;
        }
        else if (verticalInput < 0)
        {
            moveDirection = Vector3.down;
        }
        else if (verticalInput > 0)
        {
            moveDirection = Vector3.up;
        }
        else
        {
            moveDirection = Vector3.zero;
        }

        // Shiftキーの状態を更新する
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isShiftPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            isShiftPressed = false;
        }

        // プレイヤーを移動させる
        MovePlayer();
    }

    void MovePlayer()
    {
        // 現在の移動速度を設定
        float currentSpeed = isShiftPressed ? SPEED_LOW : SPEED;

        // プレイヤーの位置を更新する
        Vector3 newPosition = transform.position + (moveDirection * currentSpeed * Time.deltaTime);

        // 移動制限：画面外に出ないようにする
        float screenLimitX = Camera.main.orthographicSize * Camera.main.aspect;
        float screenLimitY = Camera.main.orthographicSize;

        newPosition.x = Mathf.Clamp(newPosition.x, -screenLimitX, screenLimitX);
        newPosition.y = Mathf.Clamp(newPosition.y, -screenLimitY, screenLimitY);

        transform.position = newPosition;
    }
}

