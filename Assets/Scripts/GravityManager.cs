using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    [SerializeField] private float gravity = 9.81f;

    private void Awake()
    {
        Physics.gravity = new Vector3(0f, -gravity, 0f);
    }
}
