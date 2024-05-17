using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_SetAnime : MonoBehaviour
{
    private Animator attack01;

    // Start is called before the first frame update
    void Start()
    {
        attack01 = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            attack01.SetTrigger("Trigger_attack01");
        }

    }
}
