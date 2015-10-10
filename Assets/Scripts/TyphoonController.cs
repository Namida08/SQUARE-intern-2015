using UnityEngine;
using System.Collections;

public class TyphoonController : SingletonMonoBehaviour<TyphoonController> {

	[SerializeField]
	private Camera camera;

	public enum Status{
		Neutral
	};

	private Status status;

	private float density;	//密度倍率
	private float hp;		//勢力
	private Vector2 point;	//座標
	private float size;		//サイズ


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(){
		point = new Vector2 (0 / 2, 0);	//画面サイズ半分初期値
		Move (0);
		density = 1.0f;
		CalcDensity(0);
	}

	private void Move(float value){
		//if移動量限界
		point.x += value;
		gameObject.transform.position = point;
	}

	public void MoveRight(){
		if(point.x < 10){
			Move (0.2f);
		}
	}

	public void MoveLeft(){
		if (point.x > -10) {
			Move (-0.2f);
		}
	}

	private void CalcDensity(float value){
		density += value;
		gameObject.transform.localScale = new Vector3(1.0f * density, 1.0f * density, 1.0f);
	}

	public void AddDensity(){
		if (density <= 1.5) {
			CalcDensity(0.03f);
		}
	}

	public void SubDensity(){
		if (density >= 0.5) {
			CalcDensity(-0.03f);
		}
	}

	public void AddHP(float value){
		//if-限界
		hp += value;
	}

	void Awake () {
		base.Awake ();
	}

}
