using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetNextLevel : MonoBehaviour
{
    // Get Current Scene Name
    string currentSceneName = SceneManager.GetActiveScene().name;
    string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNext()
    {
        if (currentSceneName.Equals("Game_Level1"))
        {
            nextSceneName = "Game_Level2";
        }else if (currentSceneName.Equals("Game_Level2"))
        {
            nextSceneName = "Game_Level3";
        }else if (currentSceneName.Equals("Game_Level3"))
        {
            nextSceneName = "End_Game";
        }
    }
}
