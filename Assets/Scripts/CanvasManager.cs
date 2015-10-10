using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CanvasManager : SingletonMonoBehaviour<CanvasManager> {
	
	public enum Status{
		Init, Start, Restart, GameInit, Game, ResultInit, Result
	};
	
	public static Status currentStatus;
	
	//public GameObject startCanvas;
	public GameObject gameCanvas;
	//public GameObject resultCanvas;
	
	public Text gameScore;
	//public Text highScoreAlert;
	//public Text resultScore;
	//public Text resultHighScore;
	
	public Camera mainCamera;
	
	//[SerializeField] private ParticleSystem cracker;
	//[SerializeField] private GameObject planeDust;
	
	private List<Object> particles = new List<Object>();

	[SerializeField] 
	private BackgroundController background;


	// Use this for initialization
	void Start () {
		currentStatus = Status.GameInit;


	}
	
	// Update is called once per frame
	void Update () {
		switch(currentStatus){
		case Status.Init:
			Init ();
			AudioManager.Instance.PlayBGM("op");
			//startCanvas.SetActive (true);
			gameCanvas.SetActive (false);
			//resultCanvas.SetActive (false);
			currentStatus = Status.Start;
			//StageController.Instance.StageInit ();
			break;
		case Status.Start:
			break;
		case Status.Restart:
			Init ();
			currentStatus = Status.GameInit;
			break;
		case Status.GameInit:
			GameManager.Instance.GameInit ();
			//AudioManager.Instance.PlayBGM("game");
			//startCanvas.SetActive(false);
			gameCanvas.SetActive(true);
			//resultCanvas.SetActive (false);
			GameManager.Instance.GameStart();
			currentStatus = Status.Game;
			//highScoreAlert.gameObject.SetActive(false);
			break;
		case Status.Game:
			background.Move(-0.1f);
			gameScore.text = ((int)GameManager.score).ToString();
			if(GameManager.score > GameManager.highScore){
				//highScoreAlert.gameObject.SetActive(true);
			}
			break;
		case Status.ResultInit:
			//highScoreAlert.gameObject.SetActive(false);
			//ResultInit();
			currentStatus = Status.Result;
			break;
		case Status.Result:
			break;
		}
	}
	
	public void Init(){
		ResetParticles ();
		TyphoonController.Instance.gameObject.SetActive (true);
		TyphoonController.Instance.Init ();
		//角度もreset
	}
	
	private void ResetParticles(){
		foreach (Object gaemObject in particles) {
			Destroy (gaemObject);
		}
	}

	/*
	private void ResultInit(){
		particles.Add (Instantiate (planeDust, PlayerController.Instance.transform.position, Quaternion.Euler (-90, 0, 0)));
		gameCanvas.SetActive(false);
		resultCanvas.SetActive(true);
		resultScore.text = ((int)GameManager.score).ToString();
		resultHighScore.text = ((int)GameManager.highScore).ToString();
		if (GameManager.score > GameManager.highScore) {
			particles.Add (Instantiate(cracker, new Vector3(mainCamera.orthographicSize * -1.5f, mainCamera.orthographicSize * -1.0f, 0.0f), Quaternion.Euler(-75, 90, 0)));
			particles.Add (Instantiate(cracker, new Vector3(mainCamera.orthographicSize * 1.5f, mainCamera.orthographicSize * -1, 0), Quaternion.Euler(-75, -90, 0)));
		}
	}*/

	/*
	public void ClickStartButton(int level) {
		GameManager.Instance.level = level;
		FadeManager.Instance.FadeOutAndIn (Status.GameInit);
		AudioManager.Instance.PlaySE("start");
	}
	
	public void ClickRestartButton() {
		FadeManager.Instance.FadeOutAndIn (Status.Restart);
		AudioManager.Instance.PlaySE("restart");
	}
	
	public void ClickTitleButton() {
		FadeManager.Instance.FadeOutAndIn (Status.Init);
		AudioManager.Instance.PlaySE("restart");
	}
	*/

	public void Awake()	{
		base.Awake ();
		DontDestroyOnLoad(this.gameObject);
	}    
	
}

