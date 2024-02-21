using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int playerScore;

    public static ScoreManager instance;

    // this is flag
    public event EventHandler OnScoreChange;

    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void AddScore()
    {
        playerScore++;

        //wave flag
        OnScoreChange?.Invoke(this, EventArgs.Empty);
    }
    
}
