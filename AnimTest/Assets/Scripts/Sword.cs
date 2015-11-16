using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {
	public int dmg;
	void Start () {
	}
	void Update () {
	}
	void OnTriggerEnter(Collider other){

		if (other.tag == "Enemy") {
			if(other.GetComponent<EnemyHealth>())
			other.GetComponent<EnemyHealth> ().TakeDamage (dmg);
			Destroy (gameObject, 0.4f);
		} else if (other.tag == "Boundary") {
			Destroy (gameObject,0.4f);
		} else if (other.tag == "Untagged") {
			Destroy (gameObject,0.4f);
		}

//		if (other.tag == "Untagged") {
//			Destroy (gameObject, 0.4f);
//		} 
	}
}
