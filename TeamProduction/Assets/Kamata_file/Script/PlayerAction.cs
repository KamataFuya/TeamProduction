using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    // 変数宣言
    private float speed = 25.0f; // プレイヤーの移動速度
    private float dashSpeed = 8.0f; // プレイヤーのダッシュスピード

    private float hp = 100;
    private float stamina = 100;

    private float dodgeSpeed = 5f; // 回避の速度
    private float dodgeDuration = 0.5f; // 回避の持続時間
    private float invincibilityDuration = 10f / 60f; // 無敵時間（フレームを秒に変換）
    private bool isDodging = false; // 回避中かどうかの判別フラグ
    private bool isInvincible = false; // 無敵中かどうかの判別フラグ
    private float dodgeTime = 0f;
    private float invincibilityTime = 0f; // 無敵時間

    public GameObject ballPrefab; // 投げるボールのプレハブ
    public Transform throwPoint; // ボールを投げる位置
    public float throwForce = 150f; // 投げる力
    public float throwAngle = 80f; // 投げる角度（度）

    private Rigidbody rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 回避処理
        if (Input.GetKeyDown(KeyCode.Space) && !isDodging)
        {
            StartCoroutine(DodgeAction());
        }
        if (isInvincible)
        {
            invincibilityTime -= Time.deltaTime;
            if (invincibilityTime <= 0f)
            {
                isInvincible = false;
            }
        }
        else
        {
            // 移動処理
            Move();
        }

        // 磁力ボール投げる
        if (Input.GetKeyDown(KeyCode.F))
        {
            ThrowMagneBall();
        }
    }

    //移動関数
    private void Move()
    {
        if (Input.GetKey(KeyCode.B))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 0, dashSpeed) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, 0, -dashSpeed) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftArrow))// 左
            {
                transform.position += new Vector3(-dashSpeed, 0, 0) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))// 右
            {
                transform.position += new Vector3(dashSpeed, 0, 0) * Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftArrow))// 左
            {
                transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))// 右
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
        }
        
    }

    // 回避
    private IEnumerator DodgeAction()
    {
        isDodging = true;
        isInvincible = true;
        invincibilityTime = invincibilityDuration;

        // 回避中の動作
        float startTime = Time.time;
        while (Time.time < startTime + dodgeDuration)
        {
            transform.position += transform.forward * dodgeSpeed * 0.01f;
            yield return null;
        }

        // 回避終了
        isDodging = false;
    }

    // 磁力ボールぶん投げる
    private void ThrowMagneBall()
    {
        // ボールの生成
        throwPoint.position = transform.position;
        throwPoint.rotation = transform.rotation;
        GameObject ball = Instantiate(ballPrefab, throwPoint.position, throwPoint.rotation);

        // ボールに力を加える
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        Vector3 throwDirection = CalculateThrowDirection(throwPoint.forward, throwAngle);
        rb.AddForce(throwDirection * throwForce, ForceMode.VelocityChange);
    }

    // 磁力ボールの軌道計算
    private Vector3 CalculateThrowDirection(Vector3 forward, float angle)
    {
        // 角度をラジアンに変換
        float radians = angle * Mathf.Deg2Rad;

        // 水平方向と垂直方向の成分を計算
        Vector3 horizontal = forward * Mathf.Cos(radians);
        Vector3 vertical = Vector3.up * Mathf.Sin(radians);

        // 方向ベクトルを正規化して合成
        return (horizontal + vertical).normalized;
    }
}
