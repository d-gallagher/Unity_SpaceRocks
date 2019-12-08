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

    // Track if Large(3), Med(2), Small(1) Asteroid
    public int asteroidSize;

    void Start()
    {
        mainCam = Camera.main;
        MoveAsteroid();
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
        float speedX = Random.Range(200f, 800f);
        int selectorX = Random.Range(0, 2);
        float dirX = 0;
        if (selectorX == 1) { dirX = -1; }
        else { dirX = 1; }
        float finalSpeedX = speedX * dirX;
        rb.AddForce(transform.right * finalSpeedX);

        // asteroid velocity in y axis - select pos/neg direction - add force
        float speedY = Random.Range(200f, 800f);
        int selectorY = Random.Range(0, 2);
        float dirY = 0;
        if (selectorY == 1) { dirY = -1; }
        else { dirY = 1; }
        float finalSpeedY = speedY * dirY;
        rb.AddForce(transform.up * finalSpeedY);
    }

    public void SetAsteroidSize(int size)
    {
        size = asteroidSize;
    }

    void Update()
    {
        float dynamicMaxSpeed = 3f;
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -dynamicMaxSpeed, dynamicMaxSpeed), Mathf.Clamp(rb.velocity.y, -dynamicMaxSpeed, dynamicMaxSpeed));
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

            }
            else if (asteroidSize == 2)
            {
                // Spawn two small asteroids
                Instantiate(asteroidSmall, transform.position, transform.rotation);
                Instantiate(asteroidSmall, transform.position, transform.rotation);

            }
            else if (asteroidSize == 1)
            {
                // Score points
            }
            
            // Destroy the asteroid
            Destroy(gameObject);
        }

        if (hitInfo.CompareTag("Player"))
        {
            Debug.Log("AsteroidToPlayerCollision: " + hitInfo.name);
            //Reduce player life or destroy player..
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "Projectile(Clone)" || 
            collisionInfo.collider.name == "PlayerShip")
        {
            // if (_generation < 3)
            // {
            //     CreateSmallAsteriods(2);
            // }
            Destroy();
        }

    }

    public void Destroy()
    {
        Destroy(gameObject, 0.01f);
    }

}
