using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;
    public GameObject cameraObject;
    CameraScript cameraScript;

    public CharacterController cc;

    float forwardSpeed;
    float sideSpeed;
    float verticalVelocity;
    float jumpSpeed = 7.9f;

    void Start()
    {
        //Cursor.visible = false;
        cc = GetComponent<CharacterController>();
        cameraScript = cameraObject.GetComponent<CameraScript>();
        verticalVelocity = 0f;
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0, cameraObject.GetComponent<CameraScript>().curYRot, 0);
        bool in2DMode = cameraScript.in2DMode;
        // movement
        sideSpeed = Input.GetAxis("Horizontal") * moveSpeed;

        if (in2DMode) {
            forwardSpeed = 0;
            Vector3 curPos = transform.position;
            Vector3 newPos = curPos - new Vector3(0, 0, 7 + curPos.z);
            transform.position = newPos;
        }
        else
            forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;

        verticalVelocity += Physics.gravity.y * 1.5f * Time.deltaTime;
        if (cc.isGrounded)
            verticalVelocity = -0.1f;

        if (cc.isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = jumpSpeed;
        }

        Vector3 velocity = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
        velocity = transform.rotation * velocity;

        cc.Move(velocity * Time.deltaTime);
    }
}
