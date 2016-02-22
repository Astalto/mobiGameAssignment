using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Data {

	public class Highscore
	{
		public string Name;
		public int Score;
	}

	public List<Highscore> Records = new List<Highscore>();

	public void AddRecord(string name, int score)
	{
		Records.Add(new Highscore()
		{
			Name = name,
			Score = score
		});

		Records = Records.OrderByDescending(p => p.Score).Take(3).ToList();

		string recordAsString = string.Join(";", Records.Select<Highscore, string>(RecordToString).ToArray());

		PlayerPrefs.SetString("Highscores", recordAsString);
	}

	private string RecordToString(Highscore record)
	{
		return record.Name + ':' + record.Score;
	}

	private Highscore RecordFromString(string str)
	{
		string[] parts = str.Split(':');
		return new Highscore()
		{
			Name = parts[0],
			Score = int.Parse(parts[1])
		};
	}

	public void ReadHighscores()
	{
		if (!PlayerPrefs.HasKey("Highscores")) return;

		Records = PlayerPrefs.GetString("Highscores").Split(';').Select<string, Highscore>(RecordFromString).ToList();

	}

}
