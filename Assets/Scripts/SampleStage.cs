﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SampleStage : IEnumerable {
	private List<SpawnObject> spawnList;
	private int groupID;

	// Use this for initialization
	public SampleStage(){
		spawnList = new List<SpawnObject> ();
		spawnList.Add (new SpawnObject (1,"Island",72,FieldManager.Instance.getXposPercent(0.3f),FieldManager.Instance.getZposPercent(1.0f),1.0f,false));
		spawnList.Add (new SpawnObject (1,"Island",127,FieldManager.Instance.getXposPercent(0.8f),FieldManager.Instance.getZposPercent(1.0f)));
		spawnList.Add (new SpawnObject (1,"Island",210,FieldManager.Instance.getXposPercent(0.2f),FieldManager.Instance.getZposPercent(1.0f)));
		spawnList.Add (new SpawnObject (1,"Island",245,FieldManager.Instance.getXposPercent(0.15f),FieldManager.Instance.getZposPercent(1.0f)));
		spawnList.Add (new SpawnObject (2,"Island",39,FieldManager.Instance.getXposPercent(0.7f),FieldManager.Instance.getZposPercent(1.0f)));
		spawnList.Add (new SpawnObject (2,"Island",230,FieldManager.Instance.getXposPercent(0.8f),FieldManager.Instance.getZposPercent(1.0f)));
		spawnList.Add (new SpawnObject (2,"Island",120,FieldManager.Instance.getXposPercent(0.1f),FieldManager.Instance.getZposPercent(1.0f)));
		spawnList.Add (new SpawnObject (3,"Island",180,FieldManager.Instance.getXposPercent(0.05f),FieldManager.Instance.getZposPercent(1.0f)));
		spawnList.Add (new SpawnObject (3,"Island",290,FieldManager.Instance.getXposPercent(0.9f),FieldManager.Instance.getZposPercent(1.0f)));
		spawnList.Add (new SpawnObject (3,"Island",40,FieldManager.Instance.getXposPercent(0.2f),FieldManager.Instance.getZposPercent(1.0f)));
		spawnList.Add (new SpawnObject (3,"Island",80,FieldManager.Instance.getXposPercent(0.7f),FieldManager.Instance.getZposPercent(1.0f)));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public List<SpawnObject> getList(){
		return spawnList;
	}

	public IEnumerator GetEnumerator(){
		return spawnList.GetEnumerator ();
	}
}
