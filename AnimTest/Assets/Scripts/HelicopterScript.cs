using UnityEngine;
using System.Collections;

public class HelicopterScript : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

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
