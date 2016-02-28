using UnityEngine;
using System.Collections;
using System.Linq;

public class Data : Singleton<Data>{

	#region Variables

	private int currentScore = 0;

	#endregion Variables

    #region Setup

    // Constructor
    private Data()
    {
        
    }

    #endregion Setup

    #region HighScore

    public void SetHighscoreArray (float score)
	{
		int[] savedHighscore = new int[3];
		int tempScore;
		int paramScore = (int)score;
		for (int i = 0; i < savedHighscore.Length; i++) 
		{
			if (savedHighscore [i] < paramScore) 
			{
				tempScore = savedHighscore [i];
				savedHighscore [i] = paramScore;
				paramScore = tempScore;
			}
		}

        PlayerPrefsX.SetIntArray("Highscores", savedHighscore);
    }

    public int[] GetHighscore()
    {
		int[] savedHighscores = PlayerPrefsX.GetIntArray("Highscores", 0, 3);
        return savedHighscores;
    }

    #endregion HighScore

    #region Current Score

    public void SetScore(int newScore)
    {
        currentScore = newScore;
        PlayerPrefs.SetInt("CurrentScore", currentScore);
    }

    public int GetScore()
    {
        return currentScore;
    }

    #endregion Current Score
}
