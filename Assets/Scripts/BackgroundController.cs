using UnityEngine;
using System.Collections;

public class BackgroundController: MonoBehaviour {
	
	Renderer bgRenderer;
	public float movedY = 0.0f;
	public Material[] materials;
	public int level;

	// initialize params
	void Start () {
		bgRenderer = GetComponent<Renderer> ();
	}
	
	public void Init(){
		movedY = 0.0f;
		Vector2 offset = new Vector2 (0, 0);
		bgRenderer.material.SetTextureOffset ("_MainTex", offset);
	}
	
	public void Move (float moved) {
		movedY += moved*0.05f;
		
		// 時間によってYの値が0から1に変化していく。1になったら0に戻り、繰り返す。
		float y = Mathf.Repeat (movedY, 1);
		
		// Yの値がずれていくオフセットを作成
		Vector2 offset = new Vector2 (0, y);
		
		// マテリアルにオフセットを設定する
		bgRenderer.material.SetTextureOffset ("_MainTex", offset);
	}

	public void ChangeMaterial () {
		bgRenderer.sharedMaterial = materials [level];
	}
}
