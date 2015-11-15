using UnityEngine;
using System.Collections;

public class AfterImage : MonoBehaviour {
	public SpriteRenderer sprite;
	SpriteRenderer ownsprite;
	Vector3 tran;
	// Use this for initialization
	void Start () {
		ownsprite = GetComponent<SpriteRenderer> ();
	}
	void Update(){
		if (transform.localPosition.x >= 0f)
			ownsprite.enabled = false;
		if (transform.localPosition.x < 0f) {
			ownsprite.sprite = sprite.sprite;
			Vector3 temp = new Vector3(transform.localPosition.x + 0.0005f,0,0);
			transform.localPosition = temp;
		}
	}
	// Update is called once per frame
	public void Image() {
		ownsprite.enabled=true;
		tran = new Vector3 (-0.1f, 0, 0);
		transform.localPosition = tran;
		//StartCoroutine (Delay());
	}
//	IEnumerator Delay(){
//		gameObject.transform.localPosition = new Vector3 (-0.1f,0,0);
//		yield return new WaitForSeconds (1f);
//		gameObject.transform.localPosition= new Vector3 (-0.07f,0,0);
//		yield return new WaitForSeconds (1f);
//		gameObject.transform.localPosition= new Vector3 (-0.05f,0,0);
//		yield return new WaitForSeconds (1f);
//		gameObject.transform.localPosition= new Vector3 (-0.03f,0,0);
//		yield return new WaitForSeconds (1f);
//		gameObject.transform.localPosition= new Vector3 (-0.01f,0,0);
//		yield return new WaitForSeconds (1f);
//		ownsprite.enabled = false;
//		gameObject.transform.localPosition= new Vector3 (0,0,0);
//	}
}
