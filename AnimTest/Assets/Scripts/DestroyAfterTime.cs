using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

	public float timeToDestroy = 5f;
	AudioSource soundSource;

	void Start () {
		Destroy (gameObject, timeToDestroy);
	}
}
