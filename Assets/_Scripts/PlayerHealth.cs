using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int healthAmount;

    public Image[] stars;
    public Sprite fullStar;
    public Sprite emptyStar;


    // Update is called once per frame
    void Update()
    {
        CalculateHealth();
    }

    public void CalculateHealth()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i < health)
            {
                stars[i].sprite = fullStar;
            }else{
                stars[i].sprite = emptyStar;
            }
            if (i < healthAmount)
            {
                stars[i].enabled = true;
            }else{
                stars[i].enabled = false;
            }
        }
    }
}
