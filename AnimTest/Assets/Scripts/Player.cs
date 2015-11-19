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
	public AudioClip Dash;
	float forwardSpeed;
	float sideSpeed=0f;
	float verticalVelocity;
	float jumpSpeed = 7.9f;
	bool isground;
	bool in2DMode;
	public bool canMove;

	int jump = 2;

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
		if (canMove) {
			if(cameraObject.GetComponent<CameraScript>()){
				transform.rotation = Quaternion.Euler (0, cameraObject.GetComponent<CameraScript> ().curYRot, 0);
				in2DMode = cameraScript.in2DMode;
			}
			// movement
			if (in2DMode) {
				forwardSpeed = 0;
				Vector3 curPos = transform.position;
				Vector3 newPos = curPos - new Vector3 (0, 0, 7 + curPos.z);
				transform.position = newPos;
			} else
				forwardSpeed = Input.GetAxis ("Vertical") * moveSpeed;
			if (!isground)
				verticalVelocity += Physics.gravity.y * 1.5f * Time.deltaTime;
			if (isground) {
				jump = 2;
				anim.SetBool ("Jump", false);
				anim.SetBool ("SecondJump", false);
				anim.SetBool ("Falling", false);
				verticalVelocity = 0;
			}
			if (jump == 2 && Input.GetButtonDown ("Jump")) {
				anim.SetBool ("Jump", true);
				verticalVelocity = jumpSpeed;
				jump-=1;
			} else if (jump == 1 && Input.GetButtonDown ("Jump")) {
				verticalVelocity = 0;
				anim.SetBool ("SecondJump", true);
				verticalVelocity = jumpSpeed;
				jump -= 1;
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
				SoundManager.instance.PlaySingle(Dash);
				Vector3 temp= new Vector3(velocity.x * 5f,velocity.y,velocity.z);
				cc.Move (temp*Time.deltaTime );
			}
		}
		if(transform.position.y <= -20) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Portal") {
			gameObject.GetComponent<Player> ().canMove = false;
			gameObject.GetComponent<ZerosShoot> ().canMove = false;
			gameObject.GetComponent<ZerosSlash> ().canMove = false;
			anim.SetTrigger ("TeleportOut");
		}
	}

}
