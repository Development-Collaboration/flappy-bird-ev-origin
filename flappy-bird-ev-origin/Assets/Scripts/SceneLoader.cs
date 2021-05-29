using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public enum SCENE { Starting, Original, Story}

    public void ToOriginalScene()
    {
        SceneManager.LoadScene("OriginalScene");
    }

    public void ToStoryScene()
    {
        SceneManager.LoadScene("StoryScene");

    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //
    }
}
