using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public int index;
    public string levelName;
    public Camera camera;
    public PlayerController playerCntl;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //SceneManager.LoadScene(index);
            SceneManager.LoadScene(levelName);
            //camera.GetComponent<Camera>().orthographicSize = 80;
            //camera.GetComponent<Camera>().transform.position = new Vector3(50, -15, 0);
            //playerCntl.speed = 30;
        }
    }
}
