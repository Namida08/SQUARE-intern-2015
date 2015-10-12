using UnityEngine;
using System.Collections;

public class AutoParticle : MonoBehaviour
{
	ParticleSystem myParticleSystem;
	
	void Awake (){
		myParticleSystem = this.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update (){
		if (myParticleSystem != null && myParticleSystem.particleCount == 0){
			Debug.Log ("Zero");
		}
	}
}