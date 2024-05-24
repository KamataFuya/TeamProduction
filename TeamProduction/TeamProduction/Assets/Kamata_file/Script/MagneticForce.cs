using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MagneticForce : MonoBehaviour
{
    public GameObject target;
    private float gravity;

    void Start()
    {
        gravity = 0.05f;
    }

    void Update()
    {
        Vector3 cube = this.gameObject.transform.position;
        Vector3 sphere = target.transform.position;
        float distance = Vector3.Distance(cube, sphere);

        if (distance >= 5.0f) //‹——£‚ÌğŒ•t‚¯‚Å¥—Í‚ğ•\Œ»
        {
            //transform.LookAt(target.transform);
            transform.position += transform.forward * gravity / 2;
        }

    }
}
