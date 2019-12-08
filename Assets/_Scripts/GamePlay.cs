using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    // Get reference to asteroid/Enemy to spawn in game
    public GameObject asteroid;
    public GameObject enemyShip;

    // Get reference to current scene
    string currentSceneName;

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
}
