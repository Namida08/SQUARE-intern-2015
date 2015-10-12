using UnityEngine;
using System.Collections;

public class ParticleDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ParticleSystem particleSystem = GetComponent <ParticleSystem>();
		Destroy(this.gameObject, particleSystem.duration);
	}
}
