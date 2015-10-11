using UnityEngine;
using System.Collections;

public class IslandController : MonoBehaviour {

	[SerializeField]
	private 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
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
