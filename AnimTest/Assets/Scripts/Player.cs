using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
	public float moveSpeed = 5f;
	public GameObject cameraObject;
	CameraScript cameraScript;
	Animator anim;
	public AfterImage after;
	public AfterImage after1;
	public AfterImage after2;
	public AfterImage after3;
	public CharacterController cc;
	float forwardSpeed;
	float sideSpeed=0f;
	float verticalVelocity;
	float jumpSpeed = 7.9f;
	bool secondjump = false;
	bool isground;
	public bool canMove=false;
	void Start()
	{
		//Cursor.visible = false;
		cc = GetComponent<CharacterController>();
		cameraScript = cameraObject.GetComponent<CameraScript>();
		anim = GetComponent<Animator>();
		StartCoroutine (StartDelay());
	}
	void Update(){
		if (cc.isGrounded)
			isground = true;
		else
			isground = false;
	}
	IEnumerator StartDelay(){
		yield return new WaitForSeconds (2f);
		canMove = true;
	}
	void LateUpdate()
	{
		if (canMove == true) {
			transform.rotation = Quaternion.Euler (0, cameraObject.GetComponent<CameraScript> ().curYRot, 0);
			bool in2DMode = cameraScript.in2DMode;
			// movement
			if (in2DMode) {
				forwardSpeed = 0;
				Vector3 curPos = transform.position;
				Vector3 newPos = curPos - new Vector3 (0, 0, 7 + curPos.z);
				transform.position = newPos;
			} else
				forwardSpeed = Input.GetAxis ("Vertical") * moveSpeed;
			if (isground==false)
				verticalVelocity += Physics.gravity.y * 1.5f * Time.deltaTime;
			if (isground==true) {
				secondjump = false;
				anim.SetBool ("Jump", false);
				anim.SetBool ("SecondJump", false);
				anim.SetBool ("Falling", false);
				verticalVelocity = 0;
			}
			if (isground==true && Input.GetButtonDown ("Jump")) {
				anim.SetBool ("Jump", true);
				verticalVelocity = jumpSpeed;
				secondjump = true;
			} else if (secondjump == true && Input.GetButtonDown ("Jump")) {
				verticalVelocity = 0;
				anim.SetBool ("SecondJump", true);
				verticalVelocity = jumpSpeed;
				secondjump = false;
			} if (isground==false && verticalVelocity < -2) {
				anim.SetBool ("Falling", true);
				//secondjump=true;
			}
		
			Vector3 velocity = new Vector3 (sideSpeed, verticalVelocity, forwardSpeed);
			velocity = transform.rotation * velocity;
			if (Input.GetAxis ("Horizontal") < -0.1f) {
				sideSpeed = -1f * moveSpeed;
				transform.localScale = new Vector3 (-3, 3, 3);
			}
			if (Input.GetAxis ("Horizontal") > 0.1f) {
				sideSpeed = moveSpeed;
				transform.localScale = new Vector3 (3, 3, 3);
			}
			if (Input.GetAxis ("Horizontal") == 0f)
				sideSpeed = 0.01f;
			if (sideSpeed != 0)
				anim.SetFloat ("Walk", Mathf.Abs (sideSpeed));
			if (forwardSpeed != 0)
				anim.SetFloat ("Walk", Mathf.Abs (forwardSpeed));
		
			cc.Move (velocity * Time.deltaTime);
			if (Input.GetKeyDown (KeyCode.LeftShift) && isground&&anim.GetBool("Dash")==false) {
				anim.SetTrigger ("Dash");
				after.Image();
				after1.Image();
				after2.Image();
				after3.Image();
				Vector3 temp= new Vector3(velocity.x * 5f,velocity.y,velocity.z);
				cc.Move (temp*Time.deltaTime );
			}
		}
		if(transform.position.y <= -20) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

}
