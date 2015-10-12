using UnityEngine;
using System.Collections;
using System;

public class InputManager : SingletonMonoBehaviour<InputManager>  {
	[SerializeField]
	private Camera camera;

	//スワイプ判定の最低距離
	public float minSwipeDistX;
	public float minSwipeDistY;
	//実際にスワイプした距離
	private float swipeDistX;
	private float swipeDistY;
	//方向判定に使うSign値
	float SignValueX;
	float SignValueY;
	//タッチしたポジション
	private Vector2 startPos;
	//タッチを離したポジション
	private Vector2 endPos;

	private int count;
	private bool moveFlag;
	private int maxCount;

	void Start (){
		if (minSwipeDistX == 0) {
			minSwipeDistX = 20;
		}
		if (minSwipeDistY == 0) {
			minSwipeDistY = 50;
		}
		count = 0;
		moveFlag = true;
		maxCount = 60;
	}

	void Update(){
	}

	void FixedUpdate () {
		// ゲームが始まっているか判断
		if (CanvasManager.currentStatus == CanvasManager.Status.Start) {
			TitleTouchChecker();
		}else if (CanvasManager.currentStatus == CanvasManager.Status.Game) {
			GameTouchChecker ();
		} 
	}
	
	private void TitleTouchChecker(){
		if (Input.GetMouseButton (0)) {
			// 右側をタッチした瞬間の挙動
			if (Input.mousePosition.x > (camera.pixelWidth / 2)) {
				CanvasManager.Instance.ClickStartButton(2);
				// 左側をタッチした瞬間の挙動
			} else if (Input.mousePosition.x <= (camera.pixelWidth / 2)) {
				CanvasManager.Instance.ClickStartButton(1);
			}
		}
	}

	private void GameTouchChecker(){
		if (Input.GetMouseButtonDown (0)) {
			count = 0;
			startPos = Input.mousePosition;
			Vector3 screenSpace = Camera.main.WorldToScreenPoint(TyphoonController.Instance.transform.position);
			if(Math.Abs(TyphoonController.Instance.transform.position.x - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z)).x) < 1.0f){
				moveFlag = true;
			}else{
				moveFlag = false;
			}
		}
		if (Input.GetMouseButton (0)) {
			endPos = Input.mousePosition;
			//print (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z)).x);
			//X方向にスワイプした距離を算出
			swipeDistX = (new Vector3 (endPos.x, 0, 0) - new Vector3 (startPos.x, 0, 0)).magnitude;
			if (swipeDistX > minSwipeDistX) {
				//x座標の差分のサインを計算, xの差分をとっているので絶対にサインの値は1(90度)か-1(270度)
				SignValueX = Mathf.Sign (endPos.x - startPos.x);
				if (SignValueX > 0) {
					//右方向にスワイプしたとき
					//TyphoonController.Instance.Move (swipeDistX / 800.0f);
				} else if (SignValueX < 0) {
					//左方向にスワイプしたとき
					//TyphoonController.Instance.Move (-swipeDistX / 800.0f);
				}
				//count += maxCount;
			}
			if(moveFlag){
				Vector3 screenSpace = Camera.main.WorldToScreenPoint(TyphoonController.Instance.transform.position);
				TyphoonController.Instance.SetMove (Camera.main.ScreenToWorldPoint(new Vector3(endPos.x, endPos.y, screenSpace.z)).x);
			}
			count++;
		}
		if (Input.GetMouseButtonUp (0)) {
			if(count < maxCount){
				TyphoonController.Instance.AddDensity();
			}
		}
	}

	void Awake () {
		base.Awake ();
		DontDestroyOnLoad(this.gameObject);
	}
}
