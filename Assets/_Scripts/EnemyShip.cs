using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    // Enemy move speed
    private float speed;

    // Enemy health
    public int health;
    // Enemy Range from player
    public float stoppingDistance;
    public float retreatDistance;
    public Rigidbody2D rb;

    // Reference to playerShip
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to player ship
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Awake()
    {
        speed = Random.Range(3f, 10f);
    }

    void FixedUpdate()
    {
        // Keep range from Player
        RangeFromPlayer();
        // Random move in space
        MoveShip();
    }

    public void RangeFromPlayer()
    {
        // Close the distance on the player
        if (Vector2.Distance(rb.position, player.position) > stoppingDistance)
        {
            rb.position = Vector2.MoveTowards(rb.position, player.transform.position, speed * Time.fixedDeltaTime);
        }
        // Keep PLayer at range
        else if (Vector2.Distance(rb.position, player.transform.position) < stoppingDistance &&
            Vector2.Distance(rb.position, player.transform.position) > retreatDistance)
        {
            rb.position = this.rb.position;
        }
        // Retreat away from player
        else if (Vector2.Distance(rb.position, player.transform.position) > retreatDistance)
        {
            rb.position = Vector2.MoveTowards(rb.position, player.transform.position, -speed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Check for collision with projectile
        if (hitInfo.CompareTag("projectile"))
        {
            health--;
            // Destroy the projectile
            Destroy(hitInfo.gameObject);
            // If Ship health is Zero, destroy the ship
            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void MoveShip()
    {
        // asteroid velocity in x axis - select pos/neg direction - add force
        float speedX = Random.Range(3f, 10f);
        int selectorX = Random.Range(0, 2);
        float dirX = 0;
        if (selectorX == 1) { dirX = -1; }
        else { dirX = 1; }
        float finalSpeedX = speedX * dirX;
        rb.AddForce(transform.right * finalSpeedX);

        // asteroid velocity in y axis - select pos/neg direction - add force
        float speedY = Random.Range(3f, 10f);
        int selectorY = Random.Range(0, 2);
        float dirY = 0;
        if (selectorY == 1) { dirY = -1; }
        else { dirY = 1; }
        float finalSpeedY = speedY * dirY;
        rb.AddForce(transform.up * finalSpeedY);
    }
}
