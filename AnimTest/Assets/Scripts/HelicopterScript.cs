using UnityEngine;
using System.Collections;

public class HelicopterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			GameObject gun = transform.Find ("Gun").gameObject;
			gun.SetActive (true);
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			GameObject gun = transform.Find ("Gun").gameObject;
			gun.SetActive (false);
		}
	}
}
