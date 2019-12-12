using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    string currentScene = SceneManager.GetActiveScene().name;
    //int nextScene;

    //private Dictionary<string, int> sceneOrder = new Dictionary<string, int>();


    public Image progressBar;
    // Start is called before the first frame update
    void Start()
    {
        // Waiting for game level to load in background
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
        // Fill the progress bar while waiting for next scene to load, then load scene
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        // Check progress of load scene operation (1 = complete)
        while (gameLevel.progress < 1)
        {
            progressBar.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }

    }

    //void OrderScenes()
    //{
    //    sceneOrder.Add("Start_Menu"   ,0);
    //    sceneOrder.Add("LoadingScene" ,1);
    //    sceneOrder.Add("Game_Level1"  ,2);
    //    sceneOrder.Add("ProgressLevel",3);
    //    sceneOrder.Add("LoadingScene" ,4);
    //    sceneOrder.Add("Game_Level2"  ,5);
    //    sceneOrder.Add("ProgressLevel",6);
    //    sceneOrder.Add("LoadingScene" ,7);
    //    sceneOrder.Add("Game_Level3"  ,8);
    //    sceneOrder.Add("End_Game"     , 9);
    //}

    public void LoadScene2()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene(4);
    }

    //int GetNextScene()
    //{
    //    if (!sceneOrder.TryGetValue(GetCurrentScene(), out nextScene))
    //    {
    //        return 0;
    //    }
    //    return nextScene;
    //}
}
