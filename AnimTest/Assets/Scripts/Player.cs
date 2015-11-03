using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public float moveSpeed = 5f;
	public GameObject cameraObject;
	CameraScript cameraScript;
	Collision col;
	Animator anim;
	
	public CharacterController cc;
	
	bool damaged;
	float forwardSpeed;
	float sideSpeed=0f;
	float verticalVelocity;
	float jumpSpeed = 7.9f;
	bool secondjump = false;
	
	void Start()
	{
		//Cursor.visible = false;
		cc = GetComponent<CharacterController>();
		cameraScript = cameraObject.GetComponent<CameraScript>();
		anim = GetComponent<Animator>();
		currentHealth = startingHealth;
		healthSlider.value = startingHealth;
	}
	void Update()
	{
		
		transform.rotation = Quaternion.Euler(0, cameraObject.GetComponent<CameraScript>().curYRot, 0);
		bool in2DMode = cameraScript.in2DMode;
		// movement
		
		
		if (in2DMode) {
			forwardSpeed = 0;
			Vector3 curPos = transform.position;
			Vector3 newPos = curPos - new Vector3(0, 0, 7 + curPos.z);
			transform.position = newPos;
		}
		else
			forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;
		
		if(!cc.isGrounded)
			verticalVelocity += Physics.gravity.y *1.5f* Time.deltaTime;
		
		if (cc.isGrounded) {
			anim.SetBool("Jump",false);
			anim.SetBool("SecondJump",false);
			verticalVelocity=0;
			anim.SetBool ("Falling",false);
		}
		
		if (cc.isGrounded && Input.GetButtonDown("Jump")){
			verticalVelocity = jumpSpeed;
			anim.SetBool("Jump",true);
			secondjump=true;
		}
		else if(secondjump==true&&Input.GetButtonDown("Jump")){
			verticalVelocity = 0;
			verticalVelocity = jumpSpeed;
			anim.SetBool("SecondJump",true);
			secondjump=false;
		}else if(!cc.isGrounded&&verticalVelocity<-2)
			anim.SetBool ("Falling",true);
		
		Vector3 velocity = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
		velocity = transform.rotation * velocity;
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			sideSpeed = -1f * moveSpeed;
			transform.localScale = new Vector3 (-3, 3, 3);
		} if (Input.GetAxis ("Horizontal") > 0.1f) {
			sideSpeed = moveSpeed;
			transform.localScale = new Vector3 (3, 3, 3);
		} if(Input.GetAxis ("Horizontal") ==0f)
			sideSpeed = 0.01f;
		if(sideSpeed != 0)
			anim.SetFloat("Walk", Mathf.Abs(sideSpeed));
		if(forwardSpeed != 0)
			anim.SetFloat("Walk", Mathf.Abs(forwardSpeed));
		
		cc.Move(velocity * Time.deltaTime);
		if(Input.GetButtonDown("Fire1"))
			anim.SetBool("Slash",true);
		if(Input.GetButtonDown("Fire2"))
			anim.SetBool("Shoot",true);
		if (Input.GetButtonUp ("Fire1"))
			anim.SetBool ("Slash", false);
		if (Input.GetButtonUp ("Fire2"))
			anim.SetBool ("Shoot", false);
		if ( Input.GetKeyDown (KeyCode.LeftShift)&&cc.isGrounded) {
			cc.Move(velocity * Time.deltaTime*5);
			anim.SetTrigger("Dash");
		}
		if (damaged) {
			anim.SetTrigger("Damaged");
		}
		damaged = false;
		if(transform.position.y <= -20) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	public void TakeDamage (int amount)
	{
		damaged = true;
		
		currentHealth -= amount;
		
		healthSlider.value = currentHealth;
		
		
		//		if(currentHealth <= 0 && !isDead)
		//		{
		//			Death ();
		//		}
	}
	//	void Death ()
	//	{
	//		isDead = true;
	//		
	//		//       playerShooting.DisableEffects ();
	//		
	//		anim.SetTrigger ("IsDead");
	//		
	//		playerAudio.clip = deathClip;
	//		playerAudio.Play ();
	//		
	//		playerMovement.enabled = false;
	//		//      playerShooting.enabled = false;
	//	}
}
