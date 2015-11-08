using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	Rigidbody rigidbody;
	public GameObject cameraObject;
	CameraScript cameraScript;
	public Transform target;
	private Transform myTransform;

	// Use this for initialization
	void Start () {
		//GameObject go = GameObject.FindGameObjectWithTag ("Player");
		//target = go.transform;
		//myTransform.LookAt (target);
		rigidbody = GetComponent<Rigidbody> ();
		//cameraScript = cameraObject.GetComponent<CameraScript>();
		//rigidbody.velocity = transform.forward * speed;
		//float amtToMove = 20f * Time.deltaTime;
		//myTransform.Translate (Vector3.left * amtToMove);
		rigidbody.velocity = Vector3.left * speed;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" || other.tag == "Untagged") {
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
