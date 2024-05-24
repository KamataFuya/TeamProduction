using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public Vector3 offset = new Vector3(0, 5, -10); // プレイヤーからのオフセット
    public float rotationSpeed = 5f; // カメラの回転速度

    private Vector3 initialOffset; // 初期オフセット

    void Start()
    {
        // 初期オフセットを設定
        initialOffset = offset;
        Cursor.lockState = CursorLockMode.None; // ゲーム開始時はマウスカーソルをロックしない
        Cursor.visible = true; // カーソルを表示
    }

    void Update()
    {
        // 左クリックを押している間にカメラを回転
        if (Input.GetMouseButton(0))
        {
            float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
            float vertical = -Input.GetAxis("Mouse Y") * rotationSpeed;

            // カメラをプレイヤーの周りで回転させる
            Quaternion camTurnAngle = Quaternion.AngleAxis(horizontal, Vector3.up);
            offset = camTurnAngle * offset;

            // 垂直方向の回転を制限する（例えば、上を向きすぎないようにする）
            offset = Quaternion.AngleAxis(vertical, transform.right) * offset;
        }

        // カメラの位置を更新
        Vector3 desiredPosition = player.position + offset;
        transform.position = Vector3.Slerp(transform.position, desiredPosition, 0.1f);
        transform.LookAt(player.position);

        // カメラ位置をリセット
        if (Input.GetKeyDown(KeyCode.K))
        {
            ResetCameraPosition();
        }
    }

    void ResetCameraPosition()
    {
        // オフセットを初期値にリセット
        offset = initialOffset;
    }
}
