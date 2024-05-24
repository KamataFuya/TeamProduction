using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            var testplayer = other.GetComponent<TestUi>();
            testplayer.Damage(10);
        }
    }
}
