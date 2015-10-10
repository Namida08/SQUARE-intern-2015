using UnityEngine;
using System.Collections;

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

	void Start (){
		if (minSwipeDistX == 0) {
			minSwipeDistX = 30;
		}
		if (minSwipeDistY == 0) {
			minSwipeDistY = 30;
		}
	}

	void Update(){
		//Swipe ();
	}


	void FixedUpdate () {
		// ゲームが始まっているか判断
		//if (CanvasManager.currentStatus == CanvasManager.Status.Game) {
		//	if (!PlayerController.Instance.IsGameOver ()) {
		inputTouchChecker ();
		//Swipe ();
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

		if (Input.GetMouseButtonDown (0)) {
			startPos = Input.mousePosition;
		}
		if (Input.GetMouseButton (0)) {
			endPos = Input.mousePosition;

			//X方向にスワイプした距離を算出
			swipeDistX = (new Vector3 (endPos.x, 0, 0) - new Vector3 (startPos.x, 0, 0)).magnitude;
			if (swipeDistX > minSwipeDistX) {
				//x座標の差分のサインを計算, xの差分をとっているので絶対にサインの値は1(90度)か-1(270度)
				SignValueX = Mathf.Sign (endPos.x - startPos.x);
				if (SignValueX > 0) {
					//右方向にスワイプしたとき
					TyphoonController.Instance.MoveRight ();
				} else if (SignValueX < 0) {
					//左方向にスワイプしたとき
					TyphoonController.Instance.MoveLeft ();
				}
			}

			//Y方向にスワイプした距離を算出
			swipeDistY = (new Vector3 (0, endPos.y, 0) - new Vector3 (0, startPos.y, 0)).magnitude;
			if (swipeDistY > minSwipeDistY) {
				//y座標の差分のサインを計算, yの差分をとっているので絶対にサインの値は1(90度)か-1(270度)
				SignValueY = Mathf.Sign (endPos.y - startPos.y);
				if (SignValueY > 0) {
					//上方向にスワイプしたとき
					TyphoonController.Instance.AddDensity ();
				} else if (SignValueY < 0) {
					//下方向にスワイプしたとき
					TyphoonController.Instance.SubDensity ();
				}
			}
		}
	}

	private void Swipe (){
		if (Input.touchCount > 0) {
			print ("a");
			Touch touch = Input.touches [0];
			switch (touch.phase) {
			
			//タッチ開始時
			case TouchPhase.Began:
				startPos = touch.position;
				break;
			
			case TouchPhase.Moved:
				endPos = new Vector2 (touch.position.x, touch.position.y);
			
				//X方向にスワイプした距離を算出
				swipeDistX = (new Vector3 (endPos.x, 0, 0) - new Vector3 (startPos.x, 0, 0)).magnitude;
				if (swipeDistX > minSwipeDistX) {
					//x座標の差分のサインを計算, xの差分をとっているので絶対にサインの値は1(90度)か-1(270度)
					SignValueX = Mathf.Sign (endPos.x - startPos.x);
					if (SignValueX > 0) {
						//右方向にスワイプしたとき

					} else if (SignValueX < 0) {
						//左方向にスワイプしたとき

					}
				}
			
				//Y方向にスワイプした距離を算出
				swipeDistY = (new Vector3 (0, endPos.y, 0) - new Vector3 (0, startPos.y, 0)).magnitude;
				if (swipeDistY > minSwipeDistY) {
					//y座標の差分のサインを計算, yの差分をとっているので絶対にサインの値は1(90度)か-1(270度)
					SignValueY = Mathf.Sign (endPos.y - startPos.y);
					if (SignValueY > 0) {
						//上方向にスワイプしたとき
						TyphoonController.Instance.AddDensity ();
					} else if (SignValueY < 0) {
						//下方向にスワイプしたとき
						TyphoonController.Instance.SubDensity ();
					}
				}
				break;
			}
		}
	}


	void Awake () {
	}
}
