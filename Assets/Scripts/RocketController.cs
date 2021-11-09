using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] float thrusterForce = 1000f;
    [SerializeField] float tiltAngle = 100f;

    private bool power = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float tiltAroundZ = Input.GetAxisRaw("Horizontal") * tiltAngle;
        power = Input.GetKey(KeyCode.Space);

        if (tiltAroundZ != 0)
        {
            transform.Rotate(new Vector3(0, 0, tiltAngle * tiltAroundZ * Time.deltaTime));
        }
    }

    private void FixedUpdate()
    {
        if (power)
        {
            rb.AddRelativeForce(Vector3.up * (thrusterForce * Time.deltaTime));
        }
    }

    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
    }
}
