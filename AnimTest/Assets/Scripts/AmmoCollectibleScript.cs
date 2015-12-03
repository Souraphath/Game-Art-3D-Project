using UnityEngine;
using System.Collections;

public class AmmoCollectibleScript : MonoBehaviour {

	public float rotationRate = 0.5f;
	public GameObject soundEffect;

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0, 0, rotationRate));
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			ZerosShoot.ammo = 10;
			Instantiate(soundEffect);
			Destroy (gameObject);
		}
	}
}
