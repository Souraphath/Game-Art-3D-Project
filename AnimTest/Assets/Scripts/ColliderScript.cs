using UnityEngine;
using System.Collections;

public class ColliderScript : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			anim.SetTrigger ("isPlayer");
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			anim.SetTrigger ("isPlayer");
		}
	}
}
