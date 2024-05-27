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
        // ���Ɉړ�
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-0.1f, 0.0f, 0.0f);
        }
        // �E�Ɉړ�
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(0.1f, 0.0f, 0.0f);
        }
        // �O�Ɉړ�
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0.0f, 0.0f, 0.1f);
        }
        // ���Ɉړ�
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0.0f, 0.0f, -0.1f);
        }

        //�����@�[���`�F���W
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (modeChange.weaponMode )
            {
                modeChange.weaponMode = false; //�[��
            }
            else
            {
                modeChange.weaponMode = true; //����
            }
        }
    }
}
