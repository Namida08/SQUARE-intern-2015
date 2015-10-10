using UnityEngine;
using System.Collections;

public class TyphoonController : SingletonMonoBehaviour<TyphoonController> {

	[SerializeField]
	private Camera camera;

	public enum Status{
		Neutral
	};
	private float density;	//密度
	private float hp;		//勢力
	private Vector2 point;	//座標
	private float size;		//サイズ

	private Status status;

	// Use this for initialization
	void Start () {
		point = new Vector2 (0 / 2, 0);	//画面サイズ半分初期値
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(){

	}

	public void Move(float value){
		//if移動量限界
		point.x += value;
		gameObject.transform.position = point;
	}

	public void MoveRight(){
		if(point.x < 100){
			Move (1);
		}
	}

	public void MoveLeft(){
		if (point.x > -100) {
			Move (-1);
		}
	}

	public void AddDensity(float value){
		//if-限界
		density += value;
	}

	public void AddHP(float value){
		//if-限界
		hp += value;
	}

	void Awake () {
		base.Awake ();
	}

}
