using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeManager : SingletonMonoBehaviour<FadeManager> {
	
	[SerializeField]
	private Image fade;
	
	private const float COUNT_MAX = 0.5f;
	private float count;
	private bool autoFlag;
	private CanvasManager.Status nextStatus;
	
	// Use this for initialization
	void Start () {
		count = 0.0f;
		autoFlag = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (count > 0) {
			fade.color = new Color (0, 0, 0, count / COUNT_MAX);
			count += Time.deltaTime;
		} else if (count < 0) {
			fade.color = new Color (0, 0, 0, (COUNT_MAX + count) / COUNT_MAX);
			count -= Time.deltaTime;
		}
		if(count >= COUNT_MAX || count <= - COUNT_MAX){
			count = 0.0f;
			if(autoFlag){
				FadeIn ();
				autoFlag = false;
				CanvasManager.currentStatus = nextStatus;
			}else {
				fade.gameObject.SetActive (false);
			}
		}
	}
	
	private void FadeOut(){
		if (count == 0.0f) {
			fade.gameObject.SetActive (true);
			count += Time.deltaTime;
		}
	}
	
	private void FadeIn(){
		if (count == 0.0f) {
			fade.gameObject.SetActive (true);
			count -= Time.deltaTime;
		}
	}
	
	public void FadeOutAndIn(CanvasManager.Status status){
		FadeOut ();
		autoFlag = true;
		nextStatus = status;
	}
	
	
	public void Awake()	{
		if(this != Instance){
			Destroy(this);
			return;
		}
		DontDestroyOnLoad(this.gameObject);
	}    
}
