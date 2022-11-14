using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController control;
    public GameObject player;
    public GameObject grid;
    public GameObject camera;
    public GameObject HUD;
    public GameObject playerHealth;
    // Start is called before the first frame update
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            //DontDestroyOnLoad(player);
            //DontDestroyOnLoad(grid);
            //DontDestroyOnLoad(camera);
            //DontDestroyOnLoad(HUD);
            //DontDestroyOnLoad(playerHealth);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
        
    }
    private void Update()
    {
  
    }


}
