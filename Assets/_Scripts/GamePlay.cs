using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    // Get reference to asteroid/Enemy to spawn in game
    public GameObject asteroid;
    public GameObject enemyShip;
    // Hold asteroids/enemies in scene to check for level complete
    GameObject[] asteroids;
    GameObject[] enemyShips;
    // Get reference to current scene
    string currentSceneName;
    // Enable Progress menu when level complete
    public GameObject progressMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        CreateAsteroids(3);
        // Get reference to current scene
        currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName.Equals("Game_Level2"))
        {
            CreateEnemyShips(1);
        }else if (currentSceneName.Equals("Game_Level3"))
        {
            CreateEnemyShips(3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CompleteLevel();
    }

    private void CreateAsteroids(float asteroidsNum)
    {
        for (int i = 1; i <= asteroidsNum; i++)
        {
            GameObject Asteroid = Instantiate(asteroid, new Vector2(Random.Range(-10, 10), 6f), transform.rotation);
        }
    }

    private void CreateEnemyShips(float enemyNum)
    {
        for (int i = 1; i <= enemyNum; i++)
        {
            GameObject Enemy = Instantiate(enemyShip, new Vector2(Random.Range(-10, 10), 6f), transform.rotation);
        }
    }

    private void CompleteLevel()
    {
        asteroids = GameObject.FindGameObjectsWithTag("asteroid");
        enemyShips = GameObject.FindGameObjectsWithTag("enemy");
        if (asteroids.Length == 0 && currentSceneName.Equals("Game_Level1"))
        {
            //Level Complete
            // Stop time in game scene
            Time.timeScale = 0f;
            // Set the progress menu to active
            progressMenuUI.SetActive(true);
        }
        else if (asteroids.Length == 0 && enemyShips.Length == 0)
        {
            //Level Complete
            // Stop time in game scene
            Time.timeScale = 0f;
            // Set the progress menu to active
            progressMenuUI.SetActive(true);
        }
        //Debug.Log("Asteroids In Scene: "+asteroids.Length); 
    }
}
