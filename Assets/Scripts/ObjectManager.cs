using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ObjectManager : SingletonMonoBehaviour<ObjectManager> {
	public float baseSpeedOfZ;
	private bool isTyphoonStateChanged = false;
	// Must Change
	private int currentTyphoonState = 1;
	public GameObject[] objects;
	private SampleStage stage;
	
	// Use this for initialization
	void Start () {
		stage = new SampleStage ();
		GameStart ();
	}
	
	// Update is called once per frame
	void Update () {
		// Do watch typhoon state
		// GetCurrentState ?
		if (isTyphoonStateChanged) {
			SpeedChangeAllObjects();
		}

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
			{
				Vector3 spawnPosition = new Vector3 (
					objParam.x,
					0, 
					objParam.z);
				Quaternion spawnRotation = Quaternion.identity;
				var len = objects.Count(x => x.gameObject.tag == objParam.objectTag);
				var fieldObj = objects.Where(x => x.gameObject.tag == objParam.objectTag).ElementAt(Random.Range(0,len));
				Instantiate(fieldObj, spawnPosition, spawnRotation);
				switch (objParam.objectTag) {
				case "Island":
					//fieldObj.GetComponent<IslandController>();
					break;
				//case "Crowd":
					//fieldObj.GetComponent<CrowdController>().setDirection(objParam.direction);
					//fieldObj.GetComponent<CrowdController>().setBaseVelocity(new Vector3(objParam.objSpeed, 0f, ))
				default:
					break;
				}

				yield return new WaitForSeconds(objParam.nextSpawnSpan);
					//yield return StartCoroutine(WaitForSecondsWithAccel(objParam.nextSpawnSpan));
			}
		}
	}

	public void DestroyAllObjects()
	{
		foreach (var obj in GameObject.FindGameObjectsWithTag("Island")) {
			Destroy(obj);
		}
	}

	private void SpeedChangeAllObjects() {
		// Chanage by per ? or contant????????????????????????????????????
		foreach (var obj in GameObject.FindGameObjectsWithTag("Island")) {
			obj.GetComponent<IslandController>().setVerocityByPercent(0.3f);
		}
	}

	public void Initialize() {
		StopCoroutine ("GenerateObjects");
		DestroyAllObjects ();
	}

	public void GameStart() {
		StartCoroutine ("GenerateObjects");
	}

	private IEnumerator WaitForSecondsWithAccel(float waitTime)
	{
		float beforeCheckedTime = Time.realtimeSinceStartup;
		float coursedTime = 0.0f;
		while(true){
			while (coursedTime < waitTime){
				float delta = (Time.realtimeSinceStartup - beforeCheckedTime) * (ObjectManager.Instance.baseSpeedOfZ == -10.0f ? 1.0f : 2.0f);
				coursedTime += delta;
				yield return new WaitForSeconds(0.05f);
			}
			//Debug.Log("BREAK");
			break;
		}
	}
}
