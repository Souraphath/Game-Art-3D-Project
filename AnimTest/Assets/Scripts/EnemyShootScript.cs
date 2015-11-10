using UnityEngine;
using System.Collections;

public class EnemyShootScript : MonoBehaviour {
	Animator anim;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

    public int reloadTime;
    float curReloadTime;
    int clipSize;
    public int maxClipSize;

	CameraScript cameraScript;

	public bool playerInCollider;

	void Awake () {
		anim = GetComponentInChildren<Animator> ();
		playerInCollider = false;
		cameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
        clipSize = maxClipSize;
        curReloadTime = 0.0f;
	}

	void Update(){
		bool in2DMode = cameraScript.in2DMode;
		if (playerInCollider && Time.time > nextFire && clipSize > 0) {
			nextFire = Time.time + fireRate;
			if(in2DMode){
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			}
			else{
				Quaternion tempQuat = Quaternion.Euler (shotSpawn.rotation.x, 90, shotSpawn.rotation.z);
				Instantiate (shot, shotSpawn.position, tempQuat);
			}
            clipSize--;
		}
        if(clipSize <= 0) {
            curReloadTime += Time.deltaTime;
            if (curReloadTime >= reloadTime) {
                clipSize = maxClipSize;
                curReloadTime = 0;
            }
        }
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			playerInCollider = true;
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			playerInCollider = false;
		}
	}
}
