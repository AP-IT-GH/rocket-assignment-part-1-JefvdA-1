using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPoint : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        if (_gameManager == null)
        {
            _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            _gameManager.AddPoint(1);
    }
}
