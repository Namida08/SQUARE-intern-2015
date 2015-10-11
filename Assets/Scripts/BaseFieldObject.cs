using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class BaseFieldObject : MonoBehaviour {
	private Vector3 baseVelocity = new Vector3(.0f,.0f,.0f);
		
	// Update is called once per frame
	public virtual void Update () {
	
	}

	public void setBaseVelocity(Vector3 velocity) {
		baseVelocity = velocity;
	}

	public virtual void MoveDelta(Vector3 delta) {
		transform.position =
			new Vector3 (transform.position.x + delta.x * baseVelocity.x,
			             transform.position.y + delta.y * baseVelocity.y,
			             transform.position.z + delta.z * baseVelocity.z);
	}


	public virtual void Move(Vector3 velocity) {
		gameObject.GetComponent<Rigidbody> ().velocity = velocity;
	}

	public virtual void DestroyByField() {
		if (transform.position.x < FieldManager.Instance.left ||
		    transform.position.x > FieldManager.Instance.right ||
		    transform.position.z < FieldManager.Instance.bottom ||
		    transform.position.z > FieldManager.Instance.top)
			Destroy (gameObject);
	}
}
