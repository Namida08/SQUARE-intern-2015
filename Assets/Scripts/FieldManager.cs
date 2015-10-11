using UnityEngine;
using System.Collections;

public class FieldManager : SingletonMonoBehaviour<FieldManager> {
	public float left;
	public float right;
	public float top;
	public float bottom;
	public float width { get { return right - left; } }
	public float height {get {return top - bottom;}}
	public float getXposPercent(float percent)
	{
		return this.left + this.width * percent;
	}
	public float getZposPercent(float percent)
	{
		return this.bottom + this.height * percent;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
