using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ObjectManager : SingletonMonoBehaviour<ObjectManager> {
	public int maxObjectConunt;
	public float appearanceSpan;
	public float appearanceRate;
	public float baseSpeedOfZ;
	public GameObject crowd;
	private SampleStage stage;
	
	// Use this for initialization
	void Start () {
		stage = new SampleStage ();
		StartCoroutine ("GenerateObjects");
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Awake()	{
		base.Awake ();
		
		DontDestroyOnLoad(this.gameObject);
	}

	IEnumerator GenerateObjects()
	{
		while (true)
		{
			var id = Random.Range(1,3);
			Debug.Log(id);
			foreach (SpawnObject objParam in stage.getList().Where(x => x.groupID == id ))
			//foreach (SpawnObject objParam in stage.GetEnumerator())
			{
				Vector3 spawnPosition = new Vector3 (
					objParam.x,
					0, 
					objParam.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(crowd, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(objParam.nextSpawnSpan);
			}
		}
	}

	public void DestroyAllObjects()
	{
		foreach (var obj in GameObject.FindGameObjectsWithTag("Island")) {
			Destroy(obj);
		}
	}

	public void Initialize() {
		StopCoroutine ("GenerateObjects");
		DestroyAllObjects ();
	}

	public void GameStart() {
		StartCoroutine ("GenerateObjects");
	}
}
