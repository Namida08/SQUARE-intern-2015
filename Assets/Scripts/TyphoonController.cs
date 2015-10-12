using UnityEngine;
using System.Collections;
using System;

public class TyphoonController : SingletonMonoBehaviour<TyphoonController> {

	[SerializeField]
	private Camera camera;

	[SerializeField]
	private ParticleSystem tornadeParticle;

	[SerializeField]
	private ParticleSystem shockParticle;

	[SerializeField]
	private ParticleSystem ringParticle;

	[SerializeField]
	private GameObject tornadeCollider;

	public enum Status{
		small, changeBig, changeSmall, big
	};

	public static Status status;

	private float density;	//密度倍率
	private float hp;		//勢力
	private Vector2 point;	//座標
	private float size;		//サイズ

	private float speed;
	private int speedCount;

	private Vector3 velocity{
		get{
			return GetComponent<Rigidbody>().velocity;
		}
		set{
			GetComponent<Rigidbody>().velocity = value;
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//CalcStatus ();
		CalcSpeed ();
		SubDensity ();
		ObjectManager.Instance.baseSpeedOfZ = -20.0f * (1.0f - density);
	}
	
	public void Init(){
		status = Status.small;
		CalcDensity(1.0f);
		point = new Vector2 (0 / 2, 0);	//画面サイズ半分初期値
		Move (0.0f);
		density = 0.0f;
		CalcDensity(0.0f);
		SetRingActive (true);
		hp = 100.0f;
		speed = 0.0f;
		speedCount = 0;
		AudioManager.Instance.PlaySE("wind1");
	}

	public void SetSpeed(float value){
		speed = value;
		speedCount = 1;
	}

	private void CalcSpeed(){
		if (speedCount > 0) {
			float s = speed * (float)(1.0 / Math.Pow ((double)speedCount, 2.0));
			if (speed < 1) {
				speed = 0.0f;
				speedCount = 0;
			}
			Move (s);
			speed++;
		}
	}

	public void SetMove(float value){
		point.x = value;
		if (point.x > 10) {
			point.x = 10;
		} else if (point.x < -10) {
			point.x = -10;
		}
		gameObject.transform.position = point;
	}

	public void Move(float value){
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

	public void ChangeStatus(){
		if (status == Status.small || status == Status.changeSmall) {
			status = Status.changeBig;
		} else if (status == Status.big || status == Status.changeBig) {
			status = Status.changeSmall;
		}
	}

	private void CalcStatus(){
		if (status == Status.changeSmall) {
			CalcDensity(-1.0f);
		} else if (status == Status.changeBig) {
			CalcDensity(1.0f);
		} else if (status == Status.small) {
			ObjectManager.Instance.baseSpeedOfZ = -20.0f;
		} else if (status == Status.big) {
			ObjectManager.Instance.baseSpeedOfZ = -10.0f;
		}
	}

	public float GetDensity(){
		return density;
	}

	public void CalcDensity(float value){
		density += value;
		if (density > 0.5) {
			density = 0.5f;
		} else if (density < -0.5) {
			density = -0.5f;
			status = Status.small;
		}
		SetDensity (density);
	}

	public void SetDensity(float density){
		gameObject.transform.localScale = new Vector3(1.0f + density, 1.0f - density, 1.0f);
		//
		tornadeParticle.startSpeed = 3.0f - density * 5.0f;
		tornadeParticle.startSize = 6.0f + density * 10.0f;
		tornadeParticle.emissionRate = 300.0f - density * 400.0f;
		GetComponent<SphereCollider> ().radius = 4.0f * (1.0f + density);
		tornadeCollider.transform.localScale = new Vector3(8.0f,8.0f,8.0f) * (1.0f + density);
	}

	public void SetRingActive(bool flag){
		shockParticle.gameObject.SetActive(flag);
		ringParticle.gameObject.SetActive(flag);
	}
	
	public void AddDensity(){
		CalcDensity(0.5f);
		status = Status.big;
	}

	public void SubDensity(){
		CalcDensity(-0.04f);
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
			if(status == Status.big){
			}
		}
	}

	void OnTriggerStay(Collider col){
		if(col.gameObject.tag.Equals("Island")){
			AddHP(-0.1f);
		}
		if(density > 0.05f){
			GameManager.Instance.AddScore(1.0f);
			Debug.Log("AddScore");

			var obj = ObjectPool.Instance.GetGameObject((GameObject)Resources.Load ("Particles/AddScore"), col.gameObject.transform.position,Quaternion.identity);

			obj.GetComponent<ParticleSystem>().Simulate(0.0005f);
			obj.GetComponent<ParticleSystem>().Emit(0);
			obj.GetComponent<ParticleSystem>().Play ();

		}
	}

	public void GameOver(){
		SetDensity (-1.0f);
		SetRingActive (false);
	}

}
