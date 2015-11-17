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
	ZerosSlash swordScript;
	public static int ammo;

	public AudioClip Shoot;
	AudioSource soundSource;
	
	void Start () {
		ammo = 10;
		anim = GetComponent<Animator> ();
		StartCoroutine (StartDelay());
		swordScript = GetComponent<ZerosSlash> ();
		soundSource = GetComponent<AudioSource>();
	}
	IEnumerator StartDelay(){
		yield return new WaitForSeconds (2f);
		canMove = true;
		StartCoroutine (StartDelay());
		soundSource.clip = Shoot;
	}
	// Update is called once per frame
	void Update () {
		if (canMove && anim.GetBool("IsDead")==false) {
			if (Input.GetButtonDown ("Fire2") && Time.time > nextFire && swordScript.sword==false) {
				if(ammo > 0){
					gun=true;
					nextFire = Time.time + fireRate;
					soundSource.Play();
					Rigidbody clone;
					clone = Instantiate (shot, shotspawn.position, shotspawn.rotation) as Rigidbody;
					if (play.transform.localScale.x > 0f)
						clone.velocity = shotspawn.right * 10f;
					if (play.transform.localScale.x < 0f)
						clone.velocity = shotspawn.right * -10f;
					anim.SetBool ("Shoot", true);
					ammo--;
				}
				else{
					gun=false;
					anim.SetBool ("Shoot", false);
				}
			}
			if (Input.GetButtonUp ("Fire2")){
				gun=false;
				anim.SetBool ("Shoot", false);
			}
		}
	}
}
