using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Button btnPause;

    void Start()
    {
        btnPause.onClick.AddListener(() => { Pause(); });
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume(){
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        // Restart Current Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    void Pause(){
        // Set the pause menu to active
        pauseMenuUI.SetActive(true);
        // Stop time in game scene
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    
}
