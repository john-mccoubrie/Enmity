using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAmmo : MonoBehaviour
{

    public GameObject[] consumables;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Respawn()
    {
        if(consumables.Length < 4)
        {
            Debug.Log("add");
        }
    }
}
