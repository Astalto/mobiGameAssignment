using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LeaderboardUI : MonoBehaviour {

    public Text[] ScoresText;
    public Text CurrentScore;

    private Data data;
    private int[] Highscore = new int[3];

    private void Start()
    {
        data = FindObjectOfType<Data>();
        Highscore = data.GetHighscore().ToArray();

        for (int i = 0; i < ScoresText.Length; i++)
        {
            ScoresText[i].text = Highscore[i].ToString();
        }
        CurrentScore.text = data.GetScore().ToString();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
