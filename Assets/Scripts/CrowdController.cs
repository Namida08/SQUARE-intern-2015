using UnityEngine;
using System.Collections;

public class CrowdController : BaseFieldObject {
	public float canGetMaxSeed;
	public float canGetMinSeed;
	private bool goLeft = false;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	public override void Update () {
		//Move (new Vector3 ((goLeft ? -1.0f : 1.0f) * Random.Range (0.0f, 1.0f),0.0f, -1.0f));
		DestroyByField ();
	}
	
	public void setDirection(bool isLeft) {
		goLeft = isLeft;
	}
	
	public override void DestroyByField() {
		if ((goLeft && transform.position.x < FieldManager.Instance.left) ||
		    (!goLeft && transform.position.x > FieldManager.Instance.right) ||
		    (transform.position.z > FieldManager.Instance.top) ||
		    (transform.position.z < FieldManager.Instance.bottom))
			Destroy (gameObject);
	}


}
