using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectManager : MonoBehaviour {
	public int maxObjectConunt;
	public float appearanceSpan;
	public float appearanceRate;
	public GameObject crowd;
	
	// Use this for initialization
	void Start () {
		StartCoroutine (GenerateObjects());
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	IEnumerator GenerateObjects()
	{
		while (true)
		{
			// Change using table
			var obj = GameObject.FindGameObjectsWithTag("FieldObject");
			if (obj.Length < maxObjectConunt) {
				if (Random.Range(0.0f,1.0f) < 0.4f) 
					yield return new WaitForSeconds(appearanceSpan);
				Vector3 spawnPosition = new Vector3 (
					Random.Range (FieldManager.Instance.left ,FieldManager.Instance.right),
					0, 
					Random.Range(FieldManager.Instance.bottom,FieldManager.Instance.top));
				Quaternion spawnRotation = Quaternion.identity;
				var cr = (GameObject)Instantiate(crowd, spawnPosition, spawnRotation);
				cr.GetComponent<CrowdController>().setBaseVerocity(new Vector3(0.4f,0f,0.2f));
				yield return new WaitForSeconds(appearanceSpan);
			}
			yield return new WaitForSeconds(appearanceSpan);
		}
	}
}
