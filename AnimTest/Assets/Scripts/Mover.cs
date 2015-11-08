using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	Rigidbody rigidBody;
	public GameObject cameraObject;
	CameraScript cameraScript;
	public Transform target;
	private Transform myTransform;
	Player playerHealth;
	GameObject player;
	public int attackDamage = 10;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<Player> ();
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		target = go.transform;
		//myTransform.LookAt (target);
		rigidBody = GetComponent<Rigidbody> ();
		//cameraScript = cameraObject.GetComponent<CameraScript>();
		//rigidbody.velocity = transform.forward * speed;
		//float amtToMove = 20f * Time.deltaTime;
		//myTransform.Translate (Vector3.left * amtToMove);
		rigidBody.velocity = Vector3.left * speed;
		//rigidBody.AddForce (transform.forward * 20);
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			if(playerHealth.currentHealth > 0)
			{
				playerHealth.TakeDamage (attackDamage);
			}
			Destroy (gameObject);
		}
		if (other.tag == "Untagged") {
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
