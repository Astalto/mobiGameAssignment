using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LeaderboardUI : MonoBehaviour {

    public Text[] ScoresText;
    public Text CurrentScore;

    private Data data;
    private List<int> Highscore = new List<int>();

    private void Start()
    {
        data = FindObjectOfType<Data>();
        Highscore = data.GetHighscore();
        Highscore.Add(data.GetScore());
        Highscore.Sort();
        for (int i = 0; i < ScoresText.Length; i++)
        {
            ScoresText[i].text = Highscore.IndexOf(i).ToString();
        }
        CurrentScore.text = data.GetScore().ToString();
        data.AddtoHighscore();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
