﻿using UnityEngine;
using System.Collections;

public class GameManager : SingletonMonoBehaviour<GameManager> {
	
	private const string NORMAL_HIGH_SCORE_KEY = "normalHighScore";
	private const string NORMAL_LAST_SCORE_KEY = "normalLastScore";
	public static int highScore;
	public static int lastScore;
	public static float score;

	[SerializeField] private float scoreMagnification = 1.0f;

	void Start () {
	}

	void Update () {
	}
	
	public void GameInit(){
		score = 0;
		highScore = PlayerPrefs.GetInt (NORMAL_HIGH_SCORE_KEY, 0);
		lastScore = PlayerPrefs.GetInt (NORMAL_LAST_SCORE_KEY, 0);
		
		//init
		TyphoonController.Instance.Init ();
		ObjectManager.Instance.Initialize ();
	}

	public void GameUpdate(){
		AddScore (-ObjectManager.Instance.baseSpeedOfZ);
	}

	public void GameStart(){
		ObjectManager.Instance.GameStart();
	}
	
	public void GameFinish(){
		if (CanvasManager.currentStatus == CanvasManager.Status.Game) {
			AudioManager.Instance.PlaySE("gameover");
			if (score > highScore) {
				PlayerPrefs.SetInt (NORMAL_HIGH_SCORE_KEY, (int)score);
				PlayerPrefs.Save ();
			}
			PlayerPrefs.SetInt (NORMAL_LAST_SCORE_KEY, (int)score);
			PlayerPrefs.Save ();
			CanvasManager.currentStatus = CanvasManager.Status.ResultInit;
		}
	}
	
	public void AddScore(float value){
		score += value * scoreMagnification;
		if (score < 0) {
			score = 0;
		}
	}
	
	public void Awake()	{
		base.Awake ();

		DontDestroyOnLoad(this.gameObject);

		Application.targetFrameRate = 60;
	}
	
}
