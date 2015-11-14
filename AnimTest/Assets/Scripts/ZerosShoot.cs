using UnityEngine;
using System.Collections;

public class ZerosShoot : MonoBehaviour {
	public Player play;
	private Animator anim;
	public Rigidbody shot;
	public Transform shotspawn;
	public float fireRate;
	public float nextFire;
	public bool canMove=false;
	public bool gun=false;
	public ZerosSlash z;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		StartCoroutine (StartDelay());
		z.GetComponent<ZerosSlash> ();
	}
	IEnumerator StartDelay(){
		yield return new WaitForSeconds (2f);
		canMove = true;
		StartCoroutine (StartDelay());
	}
	// Update is called once per frame
	void Update () {
		if (canMove == true) {
			if (Input.GetButton ("Fire2") && Time.time > nextFire && z.sword==false) {
				gun=true;
				nextFire = Time.time + fireRate;
				Rigidbody clone;
				clone = Instantiate (shot, shotspawn.position, shotspawn.rotation) as Rigidbody;
				if (play.transform.localScale.x > 0f)
					clone.velocity = shotspawn.right * 10f;
				if (play.transform.localScale.x < 0f)
					clone.velocity = shotspawn.right * -10f;
				anim.SetBool ("Shoot", true);
			}
			if (Input.GetButtonUp ("Fire2")){
				gun=false;
				anim.SetBool ("Shoot", false);
			}
		}
	}
}
