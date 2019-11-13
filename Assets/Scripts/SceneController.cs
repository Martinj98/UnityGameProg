using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public void loadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

    }

    public void loadSceneWithSetDifficulty(int difficulty)//2,3,4,5 easy medium hard extreme
    {
        int sceneIndex = 3;
        SceneManager.LoadScene(sceneIndex);
        StaticClass.CrossSceneInformation = difficulty;
    }
    public void quitApplication()
    {
        Application.Quit();
    }

    public static class StaticClass
    {
        public static int CrossSceneInformation { get; set; }
    }
}
