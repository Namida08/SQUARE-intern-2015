using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpriteRenderer))]
public class IslandController : BaseFieldObject {
	private float baseFlowSpeed;
	private SpriteRenderer spriteRenderer;
	
	// Use this for initialization
	void Start () {

		spriteRenderer = GetComponent<SpriteRenderer> ();
		// Alpha 0
		spriteRenderer.color = new Color (1f, 1f, 1f, 0f);
		var pos = transform.position;
		transform.position = new Vector3 (pos.x, -1.0f, pos.z);
	}
	
	// Update is called once per frame
	void Update () {
		baseFlowSpeed = ObjectManager.Instance.baseSpeedOfZ;
		Move (new Vector3 (.0f, .0f, baseFlowSpeed));
		DestroyByField ();
		raiseRendererAlpha (baseFlowSpeed);
		raiseIsland (baseFlowSpeed);
	}

	public void GetWater(){
		GetComponent<Animator>().SetTrigger("water");
	}

	private void raiseRendererAlpha(float value)
	{
		float current = spriteRenderer.color.a;
		if (current < 1f) {
			spriteRenderer.color = new Color(1f,1f,1f,current + 0.01f * (baseFlowSpeed == -10.0f ? 1.0f : 2.0f));
		}
	}

	private void raiseIsland(float value)
	{
		var current = transform.position;
		if (current.y < 0.0f) {
			float next = current.y + 0.05f * (baseFlowSpeed == -10.0f ? 1.0f : 2.0f);
			transform.position = new Vector3 (current.x, ((next >= 1.0f) ? (1.0f) : next), current.z);
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.tag.Equals("Player")){
			if(TyphoonController.status == TyphoonController.Status.big){
				//GetWater();
				fireParticle(gameObject.name);
			}
		}
	}
	
	void OnTriggerExit(Collider col){
		if(col.tag.Equals("Player")){
			
		}
	}

	public void setVerocityByPercent(float value) {
		Move (new Vector3 (.0f, .0f, this.baseFlowSpeed * value));
	}

	private void fireParticle(string name) {
//		Do switch Particles
		name = name.Replace ("(Clone)", "");
		//int nameHash = name.GetHashCode;

		GameObject particle;
		Vector3 position;
		GameObject obj;
		switch(name) {
		case "Island_roujinA_1":
			Debug.Log("ROUJIN_A");
			particle = (GameObject)Resources.Load ("Particles/Tornado_roujin_" + Random.Range(1,3).ToString());
			position = gameObject.transform.position;
			obj = (GameObject)Instantiate (particle, position, Quaternion.identity);
			//obj.GetComponent<ParticleSystem>().Play();
			break;
		case "Island_roujinB_1":
			Debug.Log("ROUJIN_B");

			particle = (GameObject)Resources.Load ("Particles/Tornado_roujin_" + Random.Range(4,6).ToString());
			position = gameObject.transform.position;
			obj = (GameObject)Instantiate (particle, position, Quaternion.identity);
			//obj.GetComponent<ParticleSystem>().Play();
			break;
		default:
			break;
		}
	}

}
