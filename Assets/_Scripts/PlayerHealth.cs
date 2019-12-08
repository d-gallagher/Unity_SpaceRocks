using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject Player;
    private Collider2D PlayerCollider;
    public int health;
    public int healthStars;

    // Health UI
    public Image[] stars;
    public Sprite fullStar;
    public Sprite emptyStar;

    void Start()
    {
        // Get a reference to the Player & Collider
        GameObject player = Player.GetComponent<GameObject>();
        Collider2D playerCollider = player.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayHealth();
    }

    // Display health stars full/empty in UI
    public void DisplayHealth()
    {

        for (int i = 0; i < stars.Length; i++)
        {
            // If player health is higher than the current star - display full star/empty star
            if (i < health)
            {
                stars[i].sprite = fullStar;
            }else{
                stars[i].sprite = emptyStar;
            }
            // Swap our full for empty stars
            if (i < healthStars)
            {
                stars[i].enabled = true;
            }else{
                stars[i].enabled = false;
            }
        }
    }

    public void CalculateHealth()
    {
        if (healthStars == 0)
        {
            // Game Over Menu            
                        
        }
    }

    // Detect if player has collided with an asteroid and reduce health (not working)
    public bool OnTriggerEnter(Collider2D hitInfo)
    {
        hitInfo = PlayerCollider;
        Debug.Log("HealthLossDetected: " + hitInfo.name);
        bool collision = false;

        // Check for collision with Asteroid
        if (hitInfo.CompareTag("asteroid"))
        {
            collision = true;
            health -= 1;
        }

        return collision;

    }
}
