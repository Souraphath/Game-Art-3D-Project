using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int currentHealth = 100;
	bool isDead=false;
	public Animator anim;
	public GameObject heart;
	// Use this for initialization
	void Start () {
		anim.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
	}
	public void TakeDamage (int amount)
	{
		gameObject.GetComponent<Animation>().Play("Flash_Red");
		currentHealth -= amount;
		
		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}
	void Death ()
	{
		isDead = true;
		int x = Random.Range (0, 4);
		Vector3 temp = gameObject.transform.position;
		temp.y -= .5f;
		temp.z -= .5f;
		if (x <=4)
			Instantiate (heart, temp, gameObject.transform.rotation);
		//anim.SetBool ("IsDead",true);
		Destroy (gameObject.transform.root.gameObject);
	}
}
