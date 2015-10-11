using UnityEngine;
using System.Collections;

public class IslandController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GetWater(){
		GetComponent<Animator>().SetTrigger("water");
	}
}
