using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Asteroid obj
    public GameObject asteroid;
    // Rotation values
    private float maxRotation;
    private float rotationX;
    private float rotationY;
    private float rotationZ;
    private Rigidbody2D rb;
    private Camera mainCam;
    private float maxSpeed;
    // Generation to track asteroid age
    private int _generation;

    void Start()
    {

        mainCam = Camera.main;

        maxRotation = 25f;
        // rotationX = Random.Range(-maxRotation, maxRotation);
        // rotationY = Random.Range(-maxRotation, maxRotation);
        rotationZ = Random.Range(-maxRotation, maxRotation);

        rb = asteroid.GetComponent<Rigidbody2D>();

        float speedX = Random.Range(200f, 800f);
        int selectorX = Random.Range(0, 2);
        float dirX = 0;
        if (selectorX == 1) { dirX = -1; }
        else { dirX = 1; }
        float finalSpeedX = speedX * dirX;
        rb.AddForce(transform.right * finalSpeedX);

        float speedY = Random.Range(200f, 800f);
        int selectorY = Random.Range(0, 2);
        float dirY = 0;
        if (selectorY == 1) { dirY = -1; }
        else { dirY = 1; }
        float finalSpeedY = speedY * dirY;
        rb.AddForce(transform.up * finalSpeedY);

    }

    public void SetGeneration(int generation)
    {
        _generation = generation;
    }

    void Update()
    {
        
        CheckPosition();
        float dynamicMaxSpeed = 3f;
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -dynamicMaxSpeed, dynamicMaxSpeed), Mathf.Clamp(rb.velocity.y, -dynamicMaxSpeed, dynamicMaxSpeed));
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name == "Projectile(Clone)")
        {
            // if (_generation < 3)
            // {
            //     CreateSmallAsteriods(2);
            // }
            Destroy();
        }

        // if (collisionInfo.collider.name == "asteroidet")
        // {
        //     gameplay.asteroidetFail();
        // }
    }

    // void CreateSmallAsteriods(int asteroidsNum)
    // {
    //     int newGeneration = _generation + 1;
    //     for (int i = 1; i <= asteroidsNum; i++)
    //     {
    //         float scaleSize = 0.5f;
    //         GameObject AsteroidClone = Instantiate(asteroid, new Vector3(transform.position.x, transform.position.y, 0f), transform.rotation);
    //         AsteroidClone.transform.localScale = new Vector3(AsteroidClone.transform.localScale.x * scaleSize, AsteroidClone.transform.localScale.y * scaleSize, AsteroidClone.transform.localScale.z * scaleSize);
    //         AsteroidClone.GetComponent<>().SetGeneration(newGeneration);
    //         AsteroidClone.SetActive(true);
    //     }
    // }

  private void CheckPosition()
    {
        // Set screen size
        float sceneWidth = mainCam.orthographicSize * 2 * mainCam.aspect;
        float sceneHeight = mainCam.orthographicSize * 2;
        // Set screen edges
        float sceneRightEdge = sceneWidth / 2;
        float sceneLeftEdge = sceneRightEdge * -1;
        float sceneTopEdge = sceneHeight / 2;
        float sceneBottomEdge = sceneTopEdge * -1;

        // Check if ship is in boundary, flip to opposite edge 
        if (transform.position.x > sceneRightEdge)
        {
            transform.position = new Vector2(sceneLeftEdge, transform.position.y);
        }

        if (transform.position.x < sceneLeftEdge)        
        { 
            transform.position = new Vector2(sceneRightEdge, transform.position.y); 
        } 
        
        if (transform.position.y > sceneTopEdge)
        {
            transform.position = new Vector2(transform.position.x, sceneBottomEdge);
        }

        if (transform.position.y < sceneBottomEdge)
        {
            transform.position = new Vector2(transform.position.x, sceneTopEdge);
        }
    }

    public void Destroy()
    {
        // gameplay.asterodDestroyed();
        Destroy(gameObject, 0.01f);
    }

    // public void DestroySilent()
    // {
    //     Destroy(gameObject, 0.00f);
    // }

}
