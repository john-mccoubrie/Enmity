using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneToLoad : MonoBehaviour
{
    public int activeScene;
    

    // Update is called once per frame
    void Update()
    {
        activeScene = SceneManager.GetActiveScene().buildIndex;
    }
}
