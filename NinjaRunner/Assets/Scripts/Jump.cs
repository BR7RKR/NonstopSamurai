using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ForceMode;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private bool _isPlayerControlled = false;
    
    [Header("Jump Settings")]
    [SerializeField] private float _jumpForce = 6000;
    [SerializeField] private float _gravityMultiplier = 1;
    
    private Rigidbody2D _playerRB;
    private int _jumpsCounter;
    
    private const int _MAXJUMPS = 2;

    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _playerRB.gravityScale *= _gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        MakeAJump();
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            ResetJumpsCounter();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void MakeAJump()
    {
        if (_isPlayerControlled)
        {
            if (Input.GetKeyDown(KeyCode.Space) && _jumpsCounter < _MAXJUMPS)
            {
                _playerRB.AddForce(Vector2.up.normalized * _jumpForce);
                _jumpsCounter++;
                Debug.Log(_jumpsCounter);
            }
        }
        else Debug.LogError("No behaviour created!");
    }

    private void ResetJumpsCounter()
    {
        _jumpsCounter = 0;
    }
}
