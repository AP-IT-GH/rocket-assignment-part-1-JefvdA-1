using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] float thrusterForce = 1000f;
    [SerializeField] float tiltAngle = 100f;

    private bool _power = false;
    private Rigidbody _rigidbody;
    private TrailRenderer _trailRenderer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        var tiltAroundZ = Input.GetAxisRaw("Horizontal") * tiltAngle;
        _power = Input.GetKey(KeyCode.Space);
        
        if (_power && !_trailRenderer.emitting)
            _trailRenderer.emitting = true;
        else if (!_power && _trailRenderer.emitting)
            _trailRenderer.emitting = false;

        if (tiltAroundZ != 0)
            transform.Rotate(new Vector3(0, 0, tiltAngle * tiltAroundZ * Time.deltaTime));
    }

    private void FixedUpdate()
    {
        if (_power)
        {
            _rigidbody.AddRelativeForce(Vector3.up * (thrusterForce * Time.deltaTime));
        }
    }

    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
    }
}
