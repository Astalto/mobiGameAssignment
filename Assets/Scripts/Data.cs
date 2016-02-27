using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Data : Singleton<Data>{

    #region Setup

    private Data()
    {
        
    }

    #endregion Setup

    #region HighScore

    private List<int> Highscores = new List<int>();

    public void AddtoHighscore()
    {
        int[] savedHighscores = new int[3];
        Highscores.Add(currentScore);
        Highscores.Sort();
        for (int i = 0; i < savedHighscores.Length; i++)
        {
            savedHighscores[i] = Highscores[i];
        }
        PlayerPrefsX.SetIntArray("Highscores", savedHighscores);
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
