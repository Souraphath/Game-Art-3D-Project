using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {
	public ParticleSystem par;
	public int currentHealth = 100;
	public Slider healthSlider;
	bool isDead=false;
	public Animator anim;
	// Use this for initialization
	void Start () {
		anim.GetComponent<Animator> ();
		healthSlider.value = currentHealth;
		par.enableEmission = false;
	}
	void Update(){

	}
	// Update is called once per frame
	public void TakeDamage (int amount)
	{
		gameObject.GetComponent<Animation>().Play("Flash_Red");
		currentHealth -= amount;
		
		healthSlider.value = currentHealth;
		
		
		if(currentHealth <= 0 && !isDead)
		{
			Death ();
			StartCoroutine (RestartLevel());
		}
	}
	void Death ()
	{
		isDead = true;
		anim.SetBool ("IsDead",true);
		par.enableEmission = true;
	}
	IEnumerator RestartLevel(){
		yield return new WaitForSeconds (5f);
		Application.LoadLevel (Application.loadedLevel);
	}
}
