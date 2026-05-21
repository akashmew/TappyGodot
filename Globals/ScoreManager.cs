using Godot;
using System;

public partial class ScoreManager : Node
{
	private const string SCORE_FILE_PATH = "user://tappy.tres";
	public static ScoreManager Instance { get; private set; }


	private int _highScore = 0;

	public int HighScore
	{
		get
		{
			return _highScore;
		}
		set
		{
			if (value > _highScore)
			{
				_highScore = value;
				SaveScoreToFile();
			}
		}
	}
	public override void _Ready()
	{
		Instance = this;
		LoadScoreFromFile();
	}

	private void SaveScoreToFile()
	{
		var hsr = new HighScoreResource();
		hsr.HighScore = _highScore;
		ResourceSaver.Save(hsr, SCORE_FILE_PATH);
	}

	private void LoadScoreFromFile()
	{
		if (!ResourceLoader.Exists(SCORE_FILE_PATH)) return;
		var hsr = ResourceLoader.Load<HighScoreResource>(SCORE_FILE_PATH);
		if (hsr != null)
		{
			_highScore = hsr.HighScore;
		}
	}
}
