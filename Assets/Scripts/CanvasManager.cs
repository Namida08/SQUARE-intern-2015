using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CanvasManager : SingletonMonoBehaviour<CanvasManager> {
	
	public enum Status{
		Init, Start, Restart, GameInit, Game, ResultInit, Result
	};
	
	public static Status currentStatus;

	[SerializeField] private GameObject titleCanvas;
	[SerializeField] private GameObject gameCanvas;
	[SerializeField] private GameObject resultCanvas;

	[SerializeField] public Text gameScore;
	//[SerializeField] public Text highScoreAlert;
	[SerializeField] public Text resultScore;
	[SerializeField] public Text resultHighScore;

	[SerializeField] private BackgroundController background;

	public Camera mainCamera;
	
	//[SerializeField] private ParticleSystem cracker;
	//[SerializeField] private GameObject planeDust;
	
	private List<Object> particles = new List<Object>();

	// Use this for initialization
	void Start () {
		currentStatus = Status.Init;
	}
	
	// Update is called once per frame
	void Update () {
		switch(currentStatus){
		case Status.Init:
			Init ();
			AudioManager.Instance.PlayBGM("op");
			titleCanvas.SetActive (true);
			gameCanvas.SetActive (false);
			resultCanvas.SetActive (false);
			currentStatus = Status.Start;
			break;
		case Status.Start:
			break;
		case Status.Restart:
			Init ();
			currentStatus = Status.GameInit;
			break;
		case Status.GameInit:
			GameManager.Instance.GameInit ();
			AudioManager.Instance.PlayBGM("game");
			titleCanvas.SetActive(false);
			gameCanvas.SetActive(true);
			resultCanvas.SetActive (false);
			GameManager.Instance.GameStart();
			currentStatus = Status.Game;
			//highScoreAlert.gameObject.SetActive(false);
			break;
		case Status.Game:
			background.Move(-0.1f);//あとでステージに移植
			GameManager.Instance.GameUpdate();
			gameScore.text = ((int)GameManager.score).ToString();
			if(GameManager.score > GameManager.highScore){
				//highScoreAlert.gameObject.SetActive(true);
			}
			break;
		case Status.ResultInit:
			//highScoreAlert.gameObject.SetActive(false);
			ResultInit();
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
	
	private void ResultInit(){
		//particles.Add (Instantiate (planeDust, PlayerController.Instance.transform.position, Quaternion.Euler (-90, 0, 0)));
		gameCanvas.SetActive(false);
		resultCanvas.SetActive(true);
		resultScore.text = ((int)GameManager.score).ToString();
		resultHighScore.text = ((int)GameManager.highScore).ToString();
		if (GameManager.score > GameManager.highScore) {
			//particles.Add (Instantiate(cracker, new Vector3(mainCamera.orthographicSize * -1.5f, mainCamera.orthographicSize * -1.0f, 0.0f), Quaternion.Euler(-75, 90, 0)));
			//particles.Add (Instantiate(cracker, new Vector3(mainCamera.orthographicSize * 1.5f, mainCamera.orthographicSize * -1, 0), Quaternion.Euler(-75, -90, 0)));
		}
	}
	
	public void ClickStartButton(int level) {
		//GameManager.Instance.level = level;
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

	public void Awake()	{
		base.Awake ();
		DontDestroyOnLoad(this.gameObject);
	}    
	
}

