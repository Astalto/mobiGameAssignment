using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Data : Singleton<Data>{

    #region Setup

    // Constructor
    private Data()
    {
        
    }

    #endregion Setup

    #region HighScore

    private List<int> Highscores = new List<int>();

    public void AddtoHighscore(float score)
    {
        List<int> savedHighscores = new List<int>();
        Highscores.Add((int)score);
        Highscores.Sort();
        for (int i = 0; i < savedHighscores.Count; i++)
        {
            savedHighscores[i] = Highscores[i];
        }
        if (savedHighscores.Count == 0)
        {
            savedHighscores.Add(0);
            savedHighscores.Add(0);
            savedHighscores.Add(0);
        }
        else if (savedHighscores.Count == 1)
        {
            savedHighscores.Add(0);
            savedHighscores.Add(0);
        }
        else if (savedHighscores.Count == 2)
        {
            savedHighscores.Add(0);
        }
        PlayerPrefsX.SetIntArray("Highscores", savedHighscores.ToArray());
    }

    public List<int> GetHighscore()
    {
        int[] savedHighscores = new int[3];
        savedHighscores = PlayerPrefsX.GetIntArray("Highscores", 0, 3);
        for (int i = 0; i < savedHighscores.Length; i++)
        {
            Highscores.Add(savedHighscores[i]);
        }
        Highscores.Sort();
        return Highscores;
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
