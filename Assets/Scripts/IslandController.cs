using UnityEngine;
using System.Collections;
using System.Linq;

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
			spriteRenderer.color = new Color(1f,1f,1f,current + 0.02f * baseFlowSpeed / -10.0f);
		}
	}

	private void raiseIsland(float value)
	{
		var current = transform.position;
		if (current.y < 0.0f) {
			float next = current.y + 0.08f * (baseFlowSpeed / -10.0f);
			transform.position = new Vector3 (current.x, ((next >= 1.0f) ? (1.0f) : next), current.z);
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.tag.Equals("Player")){
			if(TyphoonController.status == TyphoonController.Status.big){
				GetWater();
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
		int type;
		switch(name) {
		case "Island_roujin_A":
			Debug.Log("ROUJIN_A");
			position = gameObject.transform.position;
			obj = ObjectPool.Instance.GetGameObject((GameObject)Resources.Load("Particles/Tornado_roujin_" + Random.Range(1,3).ToString()), position, Quaternion.identity);
			//particle = (GameObject)Resources.Load ("Particles/Tornado_roujin_" + Random.Range(1,3).ToString());
			//particle = (GameObject)Resources.Load ("Particles/Tornado_roujin_1");
//			position = gameObject.transform.position;
			obj.GetComponent<ParticleSystem>().Simulate(0.0005f);
			obj.GetComponent<ParticleSystem>().Emit(0);
			obj.GetComponent<ParticleSystem>().Play ();
			break;
		case "Island_toshi_1":
			Debug.Log("ROUJIN_B");
			type = Enumerable.Range(1,3).Concat(Enumerable.Range(10,3)).ElementAt(Random.Range(0,5));
			//particle = (GameObject)Resources.Load ("Particles/Tornado_toshi_" + type.ToString());
			position = gameObject.transform.position;
			obj = ObjectPool.Instance.GetGameObject((GameObject)Resources.Load ("Particles/Tornado_toshi_" + type.ToString()), position, Quaternion.identity);
			obj.GetComponent<ParticleSystem>().Simulate(0.0005f);
			obj.GetComponent<ParticleSystem>().Emit(0);
			obj.GetComponent<ParticleSystem>().Play ();
			break;
		case "Island_toshi_3":
			type = Enumerable.Range(1,3).Concat(Enumerable.Range(5,5)).ElementAt(Random.Range(0,7));
			position = gameObject.transform.position;
			obj = ObjectPool.Instance.GetGameObject((GameObject)Resources.Load ("Particles/Tornado_toshi_" + type.ToString()), position, Quaternion.identity);
			obj.GetComponent<ParticleSystem>().Simulate(0.0005f);
			obj.GetComponent<ParticleSystem>().Emit(0);
			obj.GetComponent<ParticleSystem>().Play ();
			break;

		default:
			break;
		}
	}

}
