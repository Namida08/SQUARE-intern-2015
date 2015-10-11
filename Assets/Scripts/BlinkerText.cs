using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkerText : MonoBehaviour {
	private float nextTime;
	public float interval = 1.0f;	// 点滅周期
	
	// Use this for initialization
	void Start() {
		nextTime = Time.time;
	}
	
	// Update is called once per frame
	void Update() {
		nextTime -= Time.deltaTime;
		if (nextTime <= 0.0) {
			GetComponent<Text>().enabled = !GetComponent<Text>().enabled;
			if(GetComponent<Text>().enabled){
				nextTime += interval;
			}else{
				nextTime += interval / 2;
			}
		}
		
	}
}