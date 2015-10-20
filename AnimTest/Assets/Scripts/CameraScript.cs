﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    public float lookSensitivity = 5f;
    [HideInInspector]
    public float currentTargetCameraAngle = 60f;
    float ratioZoomV;

    [HideInInspector]
    public float xRot, yRot;
    [HideInInspector]
    public float curYRot, curXRot;
    [HideInInspector]
    public float yRotV, xRotV;
    [HideInInspector]
    public float lookSmoothDamp = 0.3f; // bigger is smoother
    [HideInInspector]
    public bool in2DMode;

    [HideInInspector]
    public float currentAimRatio = 1.0f;

    float zPos;

    Vector3 parentLastPos;

    void Awake()
    {
        parentLastPos = transform.parent.position;
        in2DMode = true;
        zPos = -15f;
        transform.localPosition = new Vector3(0, 2, zPos);
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Switch")) {
            in2DMode = !in2DMode;
            if (in2DMode) {
                zPos = Mathf.SmoothDamp(-15, -8, ref yRotV, 2);
            } else {
                zPos = Mathf.SmoothDamp(-8, -15, ref yRotV, 2);
            }
        }
        parentLastPos = transform.parent.position;

        // yRot += Input.GetAxis("Mouse X") * lookSensitivity * currentAimRatio;

        curXRot = Mathf.SmoothDamp(curXRot, xRot, ref xRotV, lookSmoothDamp);

        if (in2DMode) {
            curYRot = Mathf.SmoothDamp(curYRot, 0, ref yRotV, lookSmoothDamp);
            xRot = 0;
            transform.localPosition = new Vector3(0, 0, zPos);
        } else {
            transform.localPosition = new Vector3(0, 2, zPos);
            curYRot = Mathf.SmoothDamp(curYRot, 90 + yRot, ref yRotV, lookSmoothDamp);
            // xRot -= Input.GetAxis("Mouse Y") * lookSensitivity * currentAimRatio;
            xRot = Mathf.Clamp(xRot, -80, 60);
        }

        transform.rotation = Quaternion.Euler(curXRot, curYRot, 0);
    }
}
