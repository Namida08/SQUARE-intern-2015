using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class IslandController : BaseFieldObject {
	private float baseFlowSpeed;
	
	// Use this for initialization
	void Start () {
		baseFlowSpeed = GameObject.Find ("ObjectManager").GetComponent<ObjectManager> ().baseSpeedOfZ;
		Move (new Vector3 (.0f, .0f, baseFlowSpeed));
	}
	
	// Update is called once per frame
	void Update () {
		DestroyByField ();
	}

	public void GetWater(){
		GetComponent<Animator>().SetTrigger("water");
	}

	void OnTriggerEnter(Collider col){
		if(col.tag.Equals("Player")){
			GetWater();
		}
	}
	
	void OnTriggerExit(Collider col){
		if(col.tag.Equals("Player")){
			
		}
	}

	public void setVerocityByPercent(float value) {
		Move (new Vector3 (.0f, .0f, this.baseFlowSpeed * value));
	}

}
