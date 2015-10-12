using UnityEngine;
using System.Collections;

public class ParticleDestroyer : MonoBehaviour {
	ParticleSystem particleSystem;
	private float destroyTime = 1.0f;

	// Use this for initialization
	void Start () {
		//Invoke ("OnDestroyByTime", destroyTime);
		particleSystem = GetComponent <ParticleSystem>();
		Destroy (this.gameObject, this.particleSystem.duration);
	}

//	void OnDestroyByTime() {
//		Destroy (this.gameObject);
//	}

//
//	void Update() {
//		if (!this.particleSystem.IsAlive ())
//			Destroy (this.gameObject);
//	}
}
