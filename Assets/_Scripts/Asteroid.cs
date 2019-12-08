using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Asteroid obj
    public GameObject asteroidMedium;
    public GameObject asteroidSmall;
    public Rigidbody2D rb;
    // Rotation values
    private float maxRotation;
    private float rotationZ;
    private Camera mainCam;
    // Points for killing asteroid
    private int asteroidPoints;
    // Reference to Player to send message with accrued score
    private GameObject Player;

    // Track if Large(3), Med(2), Small(1) Asteroid
    public int asteroidSize;

    void Start()
    {
        mainCam = Camera.main;
        MoveAsteroid();
        // Get reference to the Player
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Give the asteroid a velocity
        float dynamicMaxSpeed = 3f;
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -dynamicMaxSpeed, dynamicMaxSpeed), Mathf.Clamp(rb.velocity.y, -dynamicMaxSpeed, dynamicMaxSpeed));
        RotateAsteroid();
    }

    public void RotateAsteroid()
    {
        // Set rotation z axis for asteroids
        maxRotation = 25f;
        rotationZ = Random.Range(-maxRotation, maxRotation);
    }

    public void MoveAsteroid()
    {
        // asteroid velocity in x axis - select pos/neg direction - add force
        float speedX = Random.Range(200f, 400f);
        int selectorX = Random.Range(0, 2);
        float dirX = 0;
        if (selectorX == 1) { dirX = -1; }
        else { dirX = 1; }
        float finalSpeedX = speedX * dirX;
        rb.AddForce(transform.right * finalSpeedX);

        // asteroid velocity in y axis - select pos/neg direction - add force
        float speedY = Random.Range(200f, 400f);
        int selectorY = Random.Range(0, 2);
        float dirY = 0;
        if (selectorY == 1) { dirY = -1; }
        else { dirY = 1; }
        float finalSpeedY = speedY * dirY;
        rb.AddForce(transform.up * finalSpeedY);
    }



    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Check for collision with projectile
        if (hitInfo.CompareTag("projectile"))
        {
            // Destroy the projectile
            Destroy(hitInfo.gameObject);

            // Check the size of the asteroid and split into smaller chunks
            if (asteroidSize == 3)
            {
                // Spawn two medium asteroids
                Instantiate(asteroidMedium, transform.position, transform.rotation);
                Instantiate(asteroidMedium, transform.position, transform.rotation);
                SetAsteroidPoints(10);

            }
            else if (asteroidSize == 2)
            {
                // Spawn two small asteroids
                Instantiate(asteroidSmall, transform.position, transform.rotation);
                Instantiate(asteroidSmall, transform.position, transform.rotation);
                SetAsteroidPoints(10);
            }
            else if (asteroidSize == 1)
            {
                SetAsteroidPoints(20);
            }

            // Score points - Senc message to player to score points
            Player.SendMessage("Score", GetAsteroidPoints());

            // Destroy the asteroid
            Destroy(gameObject);
        }

        if (hitInfo.CompareTag("Player"))
        {
            //Debug.Log("AsteroidToPlayerCollision: " + hitInfo.name);
            // Reduce player life by 1.. 
            Player.SendMessage("Health", 1);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject, 0.01f);
    }

    public int GetAsteroidPoints()
    {
        return asteroidPoints;
    }

    private void SetAsteroidPoints(int points)
    {
        asteroidPoints = points;
    }

}
