using UnityEngine;
using System.Collections;

public class ParticleDestroyer : MonoBehaviour {
	ParticleSystem particleSystem;
	private float destroyTime = 1.0f;

	// Use this for initialization
	void Start () {
		//Invoke ("OnDestroyByTime", destroyTime);
		particleSystem = GetComponent <ParticleSystem>();
		if (this.gameObject.name.Contains ("AddScore"))
			Destroy (this.gameObject, this.particleSystem.duration);
		else
			Invoke ("OnDestroyByTime", this.particleSystem.duration);

	}

	void OnDestroyByTime() {
		ObjectPool.Instance.ReleaseGameObject (this.gameObject);
	}

//
//	void Update() {
//		if (!this.particleSystem.IsAlive ())
//			Destroy (this.gameObject);
//	}
}
