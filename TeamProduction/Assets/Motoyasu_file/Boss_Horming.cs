using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss_horming : MonoBehaviour
{

    // ターゲットオブジェクトの Transformコンポーネントを格納する変数
    public Transform target;
    // オブジェクトの移動速度を格納する変数
    public float moveSpeed;
    // オブジェクトが停止するターゲットオブジェクトとの距離を格納する変数
    public float stopDistance;
    // オブジェクトがターゲットに向かって移動を開始する距離を格納する変数
    public float moveDistance;

    float speed;

    private Animator boss_Animator;

    // Start is called before the first frame update
    void Start()
    {
        boss_Animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {

        // 変数 targetPos を作成してターゲットオブジェクトの座標を格納
        Vector3 targetPos = target.position;
        // 自分自身のY座標を変数 target のY座標に格納
        //（ターゲットオブジェクトのX、Z座標のみ参照）
        targetPos.y = transform.position.y;
        // 変数 distance を作成してオブジェクトの位置とターゲットオブジェクトの距離を格納
        float distance = Vector3.Distance(transform.position, target.position);
        // オブジェクトとターゲットオブジェクトの距離判定
        // 変数 distance（ターゲットオブジェクトとオブジェクトの距離）が変数 moveDistance の値より小さければ
        // さらに変数 distance が変数 stopDistance の値よりも大きい場合、
        if (distance < moveDistance && distance > stopDistance && !boss_Animator.GetBool("attack01"))
        {
            // 変数 moveSpeed を乗算した速度でオブジェクトを前方向に移動する
            transform.position = transform.position + transform.forward * speed * Time.deltaTime;
          
                // オブジェクトを変数 targetPos の座標方向に向かせる
                transform.LookAt(targetPos);
            
            
        }
        else
        {
           　//攻撃した後、再度プレイヤーに角度を合わせる
            if (!boss_Animator.GetBool("attack01"))
            {
                // オブジェクトを変数 targetPos の座標方向に向かせる
                transform.LookAt(targetPos);
            }
            //エリア内に入ったら攻撃開始
            boss_Animator.SetTrigger("attack01");
        }

        //アニメーション中は必ず止まるようにする
        if (boss_Animator.GetBool("attack01"))
        {
            speed = 0;
        }
        else
        {
            speed = moveSpeed;
        }
    }

}
