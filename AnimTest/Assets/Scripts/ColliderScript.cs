using UnityEngine;
using System.Collections;

public class ColliderScript : MonoBehaviour {
	Animator anim;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	public bool playerInCollider;
	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
		playerInCollider = false;
	}

	void Update(){
		if (playerInCollider && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			playerInCollider = true;
			anim.SetTrigger ("isPlayer");
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			playerInCollider = false;
			anim.SetTrigger ("isPlayer");
		}
	}
}
