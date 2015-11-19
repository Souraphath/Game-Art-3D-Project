using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

    float spinRate = 0.5f;

	void Update () {
        transform.Rotate(new Vector3(0, spinRate, 0));
	}

    void OnTriggerEnter(Collider other) {
		if(gameObject.tag=="Heart"&&other.tag=="Player")
			other.GetComponent<Health>().TakeDamage(-10);
        if (other.tag == "Player") Destroy(gameObject);
    }
}
