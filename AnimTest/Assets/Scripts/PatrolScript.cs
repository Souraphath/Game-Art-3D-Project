using UnityEngine;
using System.Collections;

public class PatrolScript : MonoBehaviour {

    public float speed;
    public float distance;
	public Animator anim;
    float moveTime;
    float timer;
    bool direction;

    Vector3 originalScale, scaleRotX;

	void Start () {
        moveTime = distance;
        direction = true;
      //  timer = 0;
        originalScale = transform.localScale;
        scaleRotX = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
	}

	void Update () {
        if (transform.position.x > GameObject.FindGameObjectWithTag("Player").transform.position.x)
            transform.localScale = originalScale;
        else
            transform.localScale = scaleRotX;
       
		Vector3 temp = transform.localScale;
        if (timer <= moveTime) {
            if (direction) {
				anim.SetBool("Walk",true);
				transform.localScale=temp;
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            } else {
				temp.x=-1;
				transform.localScale=temp;
				anim.SetBool("Walk",true);
                transform.Translate(Vector3.left * speed * Time.deltaTime);
			}
			timer += Time.deltaTime;
        } else {
            timer = 0;
            direction = !direction;

        }
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player")
			timer = 0;
		else
			timer = 100;
	}
}
