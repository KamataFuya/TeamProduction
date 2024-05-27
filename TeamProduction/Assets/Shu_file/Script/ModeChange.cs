using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChange : MonoBehaviour
{
    public bool weaponMode = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (weaponMode)
        {
            Debug.Log("î≤ìÅ");
        }
        else
        {
            Debug.Log("î[ìÅ");
        }
    }
}
