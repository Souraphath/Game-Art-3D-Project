using UnityEngine;
using System.Collections;

public class AfterImage : MonoBehaviour {
	public SpriteRenderer sprite;
	SpriteRenderer ownsprite;
	public Animator anim;
	Vector3 tran;
	// Use this for initialization
	void Start () {
		ownsprite = GetComponent<SpriteRenderer> ();
	}
	void Update(){
		if (transform.localPosition.x >= 0f)
			ownsprite.enabled = false;
		if (transform.localPosition.x <= 0f) {
			ownsprite.sprite = sprite.sprite;
			Vector3 temp = new Vector3 (transform.localPosition.x + 0.001f, transform.localPosition.y, 0);
			transform.localPosition = temp;
		}
		if (anim.GetBool ("Jump") == true && anim.GetBool ("Falling") == false) {
			Vector3 temp = new Vector3 (transform.localPosition.x, transform.localPosition.y - 0.0009f, 0);
			transform.localPosition = temp;
		} else if (anim.GetBool ("secondJump") == true) {
			Vector3 temp = new Vector3 (transform.localPosition.x, transform.localPosition.y - 0.0009f, 0);
			transform.localPosition = temp;
		} else if (anim.GetBool ("Falling") == true && transform.localPosition.y < 0f) {
			Vector3 temp = new Vector3 (transform.localPosition.x, transform.localPosition.y + 0.01f, 0);
			transform.localPosition = temp;
		} else {
			Vector3 temp = new Vector3 (transform.localPosition.x, 0, 0);
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

}
