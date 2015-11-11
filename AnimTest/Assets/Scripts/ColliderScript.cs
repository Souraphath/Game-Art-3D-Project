using UnityEngine;
using System.Collections;

public class ColliderScript : MonoBehaviour {
	Animator anim;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	public GameObject cameraObject;
	CameraScript cameraScript;

	public bool playerInCollider;
	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
		playerInCollider = false;
		cameraScript = cameraObject.GetComponent<CameraScript>();
	}

	void Update(){
		bool in2DMode = cameraScript.in2DMode;
		if (playerInCollider && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if(in2DMode){
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			}
			else{
				Quaternion tempQuat = Quaternion.Euler (shotSpawn.rotation.x, 90, shotSpawn.rotation.z);
				Instantiate (shot, shotSpawn.position, tempQuat);
			}
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
