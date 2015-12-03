using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

    public float spinRate = 0.5f;
	public GameObject soundEffect;

	void Update () {
        transform.Rotate(new Vector3(0, spinRate, 0));
	}

    void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			ScoreScript.PLAYER_SCORE += 15;
			Instantiate(soundEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		} 
    }
}
