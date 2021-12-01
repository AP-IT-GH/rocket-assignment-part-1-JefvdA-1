using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f;
    void Update()
    {
        transform.Rotate(Vector3.left * (rotationSpeed * Time.deltaTime));
    }
}
