using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LeaderboardUI : MonoBehaviour {

    public Text[] ScoresText;
    public Text CurrentScore;

    private Data data;
    private int[] highscoreUI;

    private void Start()
    {
        data = FindObjectOfType<Data>();
        highscoreUI = data.GetHighscore();

        for (int i = 0; i < ScoresText.Length; i++)
        {
            ScoresText[i].text = highscoreUI[i].ToString();
        }
        CurrentScore.text = PlayerPrefs.GetInt("CurrentScore").ToString();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
