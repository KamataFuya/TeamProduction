using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject weapon;
    private ModeChange modeChange;
    // Start is called before the first frame update
    void Start()
    {
        modeChange = weapon.GetComponent<ModeChange>();
    }

    // Update is called once per frame
    void Update()
    {
        // 左に移動
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-0.1f, 0.0f, 0.0f);
        }
        // 右に移動
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(0.1f, 0.0f, 0.0f);
        }
        // 前に移動
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0.0f, 0.0f, 0.1f);
        }
        // 後ろに移動
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0.0f, 0.0f, -0.1f);
        }

        //抜刀　納刀チェンジ
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (modeChange.weaponMode )
            {
                modeChange.weaponMode = false; //納刀
            }
            else
            {
                modeChange.weaponMode = true; //抜刀
            }
        }
    }
}
