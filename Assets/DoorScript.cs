using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool testBool;
    void Awake()
    {
        //gameObject.SetActive(false);
        testBool = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            testBool = true;
        }
    }
}
