using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    SceneToLoad sceneToLoad;
    public void PlayGame()
    {
        Application.LoadLevel("Level1");

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BossFight1()
    {
        Application.LoadLevel("Boss1");
    }
    public void Level2()
    {
        Application.LoadLevel("Level2");
    }
    public void BossFight2()
    {
        Application.LoadLevel("Boss2");
    }
}
