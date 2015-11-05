using UnityEngine;
using System.Collections;

public class EffectStart : MonoBehaviour {
	public ParticleSystem par;
	// Use this for initialization
	void Start () {
		par.enableEmission = false;
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") 
			par.enableEmission = true;
	}
}
