using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移動速度")] public float speed;          // 移動速度
    [Header("低速率（％）")] public float slowRate;    // Shiftキー入力時の速度変化

    private Vector3 moveDirection = Vector3.zero;
    private bool isShiftPressed = false;

    private void Update()
    {
        // 移動方向のセット
        SetMoveDirection();

        // プレイヤーを移動させる
        MovePlayer();
    }

    private void SetMoveDirection()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;
        }
        else
        {
            moveDirection = Vector3.zero;
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

    private void MovePlayer()
    {
        // 現在の移動速度を設定
        float currentSpeed = isShiftPressed ? speed * slowRate / 100 : speed;

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
