using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p : MonoBehaviour
{
    float moveSpeed = 80.0f;   // 移動速度
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) )
        {
            transform.position += new Vector3(0, 0, moveSpeed) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow) )
        {
            transform.position += new Vector3(0, 0, -moveSpeed) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))// 左
        {
            transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))// 右
        {
            transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        }
    }
}
