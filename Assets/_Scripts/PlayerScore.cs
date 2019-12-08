﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public Text scoreText;
    int score;

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = GetLocalScore().ToString();
        
    }

    public void GetPlayerScore(int updateScore)
    {
        score += updateScore;
    }

    public int GetLocalScore()
    {
        return score;
    }

}