using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float speed;
    public int attackDamage = 10;

    Rigidbody rigidBody;
	Vector3 target;
	Health playerHealth;

	void Awake () {
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health> ();
		target = GameObject.FindGameObjectWithTag ("Player").transform.position;
		rigidBody = GetComponent<Rigidbody> ();

        Vector3 shootVector = new Vector3(target.x - transform.position.x, target.y - transform.position.y, target.z - transform.position.z);
		rigidBody.velocity = shootVector / Vector3.Magnitude(shootVector) * speed;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			playerHealth.TakeDamage(attackDamage);
			Destroy (gameObject);
		}
		if (other.tag == "Untagged" || other.tag =="PlayersBullet" || other.tag == "PlayersSword") {
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {

		//float amtToMove = 20 * Time.deltaTime;
		//myTransform.Translate (Vector3.forward * amtToMove);
		/*bool in2DMode = cameraScript.in2DMode;

		if (in2DMode) {
			//rigidbody.velocity = transform.forward * speed;
		} else {
			//rigidbody.velocity = transform.forward * speed;
		}*/
	}
}
