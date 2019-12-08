using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int healthStars;

    // Health UI
    public Image[] stars;
    public Sprite fullStar;
    public Sprite emptyStar;

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

}
