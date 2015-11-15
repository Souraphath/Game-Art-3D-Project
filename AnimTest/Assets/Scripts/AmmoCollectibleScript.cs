using UnityEngine;
using System.Collections;

public class AmmoCollectibleScript : MonoBehaviour {

	float spinRate = 0.5f;

	// Use this for initialization
	void Start () {
		transform.Rotate(new Vector3(0, spinRate, 0));
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			ZerosShoot.ammo = 10;
			Destroy (gameObject);
		}
	}
}
