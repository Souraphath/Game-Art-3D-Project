using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public int dmgpershot;
	Rigidbody rig;
	Animator anim;
	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyHealth>().TakeDamage(dmgpershot);
			anim.SetTrigger("IsDestroyed");
			rig.velocity= Vector3.zero;
			Destroy (gameObject,0.2f);
		}
		if (other.tag == "Untagged") {
			rig.velocity= Vector3.zero;
			Destroy (gameObject,0.2f);
		}
	}
}
