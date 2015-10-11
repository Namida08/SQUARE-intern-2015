using UnityEngine;
using System.Collections;

public class BaseFieldObject : MonoBehaviour {
	private Vector3 baseVerocity = new Vector3(.0f,.0f,.0f);
		
	// Update is called once per frame
	public virtual void Update () {
	
	}

	public void setBaseVerocity(Vector3 verocity) {
		baseVerocity = verocity;
	}

	public virtual void MoveDelta(Vector3 delta) {
		transform.position =
			new Vector3 (transform.position.x + delta.x * baseVerocity.x,
			             transform.position.y + delta.y * baseVerocity.y,
			             transform.position.z + delta.z * baseVerocity.z);
	}

	public virtual void DestroyByField() {
		if (transform.position.x < FieldManager.Instance.left ||
		    transform.position.x > FieldManager.Instance.right ||
		    transform.position.z < FieldManager.Instance.bottom ||
		    transform.position.z > FieldManager.Instance.top)
			Destroy (gameObject);
	}
}
