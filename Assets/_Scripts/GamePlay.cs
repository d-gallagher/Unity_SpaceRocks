using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public GameObject asteroid;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        CreateAsteroids(3);
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

}
