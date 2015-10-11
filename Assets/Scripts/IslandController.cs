using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(Rigidbody))]
public class IslandController : BaseFieldObject {
	
	// Use this for initialization
	void Start () {
		Move (new Vector3 (.0f,
		                   .0f,
		                   ((ObjectManager)GameObject.Find ("ObjectManager").GetComponent<ObjectManager>()).baseSpeedOfZ));
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

		}
	}
	
	void OnTriggerExit(Collider col){
		if(col.tag.Equals("Player")){
			
		}
	}

}
