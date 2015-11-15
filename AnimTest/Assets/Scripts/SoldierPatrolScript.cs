using UnityEngine;
using System.Collections;

public class SoldierPatrolScript : MonoBehaviour {
	
	public float speed;
	public float distance;
	
	float moveTime;
	float timer;
	bool direction;
	
	Vector3 originalScale, scaleRotX;
	
	void Start () {
		moveTime = distance;
		direction = true;
		timer = 0;
		originalScale = transform.localScale;
		scaleRotX = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
	}
	
	void Update () {
		if (transform.position.x > GameObject.FindGameObjectWithTag("Player").transform.position.x)
			transform.localScale = originalScale;
		else
			transform.localScale = scaleRotX;
		timer += Time.deltaTime;
		if (timer <= moveTime) {
			if (direction) {
				transform.Translate(Vector3.right * speed * Time.deltaTime);
			} else {
				transform.Translate(Vector3.left * speed * Time.deltaTime);
			}
		} else {
			timer = 0;
			direction = !direction;
		}
	}
}
