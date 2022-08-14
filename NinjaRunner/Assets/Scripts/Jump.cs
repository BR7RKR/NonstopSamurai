using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using static UnityEngine.ForceMode;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [Header("Main Settings")] 
    [SerializeField] private bool _isPlayerControlled = false;
    
    [Header("Jump Settings")]
    [SerializeField] private float _jumpForce = 6000;
    [SerializeField] private float _gravityMultiplier = 1;
    
    private Rigidbody2D _rb;
    private Animator _animator;
    private int _jumpsCounter;
    
    private readonly int _isJumping = Animator.StringToHash("isJumping");
    private readonly int _isLanding = Animator.StringToHash("isForceLanding");
    private const int _MAXJUMPS = 1;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale *= _gravityMultiplier;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        MakeAJump();
        Land();
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            _animator.SetBool(_isLanding, false);
            _animator.SetBool(_isJumping, false);
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
                _rb.AddForce(Vector2.up.normalized * _jumpForce);
                _animator.SetBool(_isJumping, true);
                _jumpsCounter++;
            }
        }
        else Debug.LogError("No behaviour created!");
    }

    private void ResetJumpsCounter()
    {
        _jumpsCounter = 0;
    }

    private void Land()
    {
        if (_isPlayerControlled)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (_jumpsCounter != 0)
                {
                    _rb.AddForce(Vector2.down.normalized * _jumpForce);
                    _animator.SetBool(_isLanding, true);
                    _animator.SetBool(_isJumping, false);
                }
            }
        }
        else Debug.LogError("No behaviour created!");
    }
}
