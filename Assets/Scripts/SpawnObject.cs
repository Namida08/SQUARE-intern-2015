using UnityEngine;
using System.Collections;

public class SpawnObject {
	public int 		groupID;
	public float 	objSpeed;
	public bool 	direction;
	public float 	nextSpawnSpan;
	public string 	objectTag;
	public float 	x;
	public float	z;

	public SpawnObject()
	{
	}
	
	public SpawnObject(int group, string tag, float next, float _x, float _z, float speed = 1.0f, bool isLeft = false){
		groupID = group;
     	objSpeed = speed;
     	direction = isLeft;
		nextSpawnSpan = next;
		objectTag = tag;
		x = _x;
		z = _z;
	}
}
