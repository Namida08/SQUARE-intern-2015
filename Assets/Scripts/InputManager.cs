using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	[SerializeField]
	private Camera camera;

	//void Update () {
	void FixedUpdate () {
		// ゲームが始まっているか判断
		//if (CanvasManager.currentStatus == CanvasManager.Status.Game) {
		//	if (!PlayerController.Instance.IsGameOver ()) {
		inputTouchChecker ();
		//	}
		//} else if (CanvasManager.currentStatus == CanvasManager.Status.Start) {
		//	startTouch();
		//}
	}
	
	private void startTouch (){
		/*
		if (Input.GetMouseButton (0)) {
			// 右側をタッチした瞬間の挙動
			if (Input.mousePosition.x > (camera.pixelWidth / 2)) {
				CanvasManager.Instance.ClickStartButton(2);
				// 左側をタッチした瞬間の挙動
			} else if (Input.mousePosition.x <= (camera.pixelWidth / 2)) {
				CanvasManager.Instance.ClickStartButton(1);
			}
		}
		*/
	}
	
	private void inputTouchChecker(){
		if (Input.GetMouseButton (0)) {
			// 右側をタッチした瞬間の挙動
			if (Input.mousePosition.x > (camera.pixelWidth / 2)) {
				TyphoonController.Instance.MoveRight ();
				//Debug.Log ("Right was pushed");
				// 左側をタッチした瞬間の挙動
			} else if (Input.mousePosition.x <= (camera.pixelWidth / 2)) {
				TyphoonController.Instance.MoveLeft ();
				//Debug.Log ("Left was pushed");
			}
		}
	}
	
	void Awake () {
	}
}
