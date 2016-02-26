using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Data {

    #region Setup

    private static Data instance = null;

    public static Data Instance()
    {
        if (instance == null)
        {
            instance = new Data();
        }

        return instance;
    }

    private Data()
    {

    }

    #endregion Setup

    #region HighScore

    private List<int> Highscores = new List<int>();

    public void SetHighscore()
    {

    }

    public void GetHighscore()
    {
        
    }

    #endregion HighScore

    #region Current Score

    private int currentScore = 0;

    public void SetScore(int newScore)
    {
        currentScore = newScore;
    }

    public int GetScore()
    {
        return currentScore;
    }

    #endregion Current Score
}
