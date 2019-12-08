using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{

    private Camera mainCam;
    public Rigidbody2D rb;

    // Keep track of Score
    public int gameScore = 0;
    public Text scoreText;

    // Keep track of Health
    public int rocketHealth;
    public int healthStars;

    // Health UI
    public Image[] stars;
    public Sprite fullStar;
    public Sprite emptyStar;

    // Audio Clips for shooting and death
    public AudioClip fireWeapon;
    public AudioClip death;

    
    private void Start()
    {
        mainCam = Camera.main;
        rocketHealth = 3;
    }

    private void FixedUpdate()
    {
        // Update Score on screen - Move out of rocket script
        scoreText.text = GetLocalScore().ToString();
        // Update UI for Health Display - Move out of rocket script
        DisplayHealth();
    }

    // Keep a tally of the score
    void Score(int asteroidPoints)
    {
        gameScore += asteroidPoints;
        Debug.Log("Asteroid Points Message Recieved: " + asteroidPoints);
        Debug.Log("Current GameScore Value: " + gameScore);
        Debug.Log("Current GetLocalScore Value: " + GetLocalScore());
    }

    // Get the local gamescore variable for display in UI
    public int GetLocalScore()
    {
        return gameScore;
    }

    // Display health stars full/empty in UI
    public void DisplayHealth()
    {

        for (int i = 0; i < stars.Length; i++)
        {
            // If player health is higher than the current star - display full star/empty star
            if (i < rocketHealth)
            {
                stars[i].sprite = fullStar;
            }
            else
            {
                stars[i].sprite = emptyStar;
            }
            // Swap our full for empty stars
            if (i < healthStars)
            {
                stars[i].enabled = true;
            }
            else
            {
                stars[i].enabled = false;
            }
        }
    }

    void Health (int updateHealth)
    {
        rocketHealth -= updateHealth;
        //Debug.Log("Asteroid Health Message Recieved: " + updateHealth);
    }
}
