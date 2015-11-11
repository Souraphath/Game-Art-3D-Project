using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	Rigidbody rigidBody;
	public GameObject cameraObject;
	CameraScript cameraScript;
	public Transform target;
	private Transform myTransform;
	GameObject player;
	public int attackDamage = 10;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		target = go.transform;
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.velocity = Vector3.left * speed;

	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			player.SendMessageUpwards("TakeDamage",attackDamage);
			Destroy (gameObject);
		}
		if (other.tag == "Untagged") {
			Destroy (gameObject);
		}
	}

	void Update () {

	}
}
