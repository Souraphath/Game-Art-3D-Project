using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {
	public ParticleSystem par;
	public int currentHealth = 100;
	public Slider healthSlider;
	bool isDead=false;
	public Animator anim;
	public AudioClip Hurt;
	public AudioClip Die;
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
		if (currentHealth > 0) {
			gameObject.GetComponent<Animation> ().Play ("Flash_Red");
			if(amount>0){
				anim.SetTrigger ("Damaged");
				gameObject.GetComponent<Animation>().Play();
				SoundManager.instance.PlaySingle (Hurt);
			}
			currentHealth -= amount;
			healthSlider.value = currentHealth;
		}
		if(currentHealth <= 0 && !isDead)
		{
			anim.SetBool ("IsDead",true);
			Death ();
			gameObject.GetComponent<Player>().canMove=false;
			gameObject.GetComponent<ZerosShoot>().canMove=false;
			gameObject.GetComponent<ZerosSlash>().canMove=false;
			StartCoroutine (RestartLevel());
		}
	}
	void Death ()
	{
		isDead = true;
		SoundManager.instance.PlaySingle (Die);
		par.enableEmission = true;
	}
	IEnumerator RestartLevel(){
		yield return new WaitForSeconds (3f);
		Application.LoadLevel (Application.loadedLevel);
	}
}
