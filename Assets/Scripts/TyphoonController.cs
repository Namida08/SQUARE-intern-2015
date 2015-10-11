using UnityEngine;
using System.Collections;

public class TyphoonController : SingletonMonoBehaviour<TyphoonController> {

	[SerializeField]
	private Camera camera;

	[SerializeField]
	private ParticleSystem tornadeParticle;

	[SerializeField]
	private GameObject tornadeCollider;

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
		Move (0.0f);
		density = 0.0f;
		CalcDensity(0.0f);
		hp = 100.0f;
	}

	private void Move(float value){
		point.x += value;
		if (point.x > 10) {
			point.x = 10;
		} else if (point.x < -10) {
			point.x = -10;		
		}
		gameObject.transform.position = point;
	}

	public void MoveRight(){
		Move (0.2f);
	}

	public void MoveLeft(){
		Move (-0.2f);
	}

	private void CalcDensity(float value){
		density += value;
		if (density > 0.5) {
			density = 0.5f;
		}else if(density < -0.5){
			density = -0.5f;
		}
		gameObject.transform.localScale = new Vector3(1.0f + density, 1.0f - density, 1.0f);
		//
		tornadeParticle.startSpeed = 6.0f - density * 10.0f;
		tornadeParticle.startSize = 6.0f + density * 10.0f;
		tornadeParticle.emissionRate = 300.0f - density * 400.0f;
		GetComponent<SphereCollider> ().radius = 4.0f * (1.0f + density);
		tornadeCollider.transform.localScale = new Vector3(8.0f,8.0f,8.0f) * (1.0f + density);
	}

	public void AddDensity(){
		CalcDensity(0.02f);
	}

	public void SubDensity(){
		CalcDensity(-0.02f);
	}


	public void AddHP(float value){
		hp += value;
		if (hp < 0) {
			hp = 0;
		}
	}

	private void CalcHP(float value){
		
	}

	void Awake () {
		base.Awake ();
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag.Equals("Island")){
			
		}
	}
	
	void OnTriggerExit(Collider col){
		if(col.gameObject.tag.Equals("Island")){
			GameManager.Instance.AddScore(100.0f);
		}
	}

	void OnTriggerStay(Collider col){
		if(col.gameObject.tag.Equals("Island")){
			AddHP(-0.1f);
		}
	}

}
