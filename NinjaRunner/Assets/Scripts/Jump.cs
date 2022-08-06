using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using static UnityEngine.ForceMode;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private bool _isPlayerControlled = false;
    
    [Header("Jump Settings")]
    [SerializeField] private float _jumpForce = 6000;
    [SerializeField] private float _gravityMultiplier = 1;
    
    private Rigidbody2D _rb;
    private Animator _animator;
    private int _jumpsCounter;
    
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int IsLanding = Animator.StringToHash("isForceLanding");
    private const int _MAXJUMPS = 1;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale *= _gravityMultiplier;
        _animator = _isPlayerControlled ? GetComponent<Animator>() : null;
    }

    // Update is called once per frame
    void Update()
    {
        MakeAJump();
        Land();
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            _animator.SetBool(IsLanding, false);
            _animator.SetBool(IsJumping, false);
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
                _animator.SetBool(IsJumping, true);
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
                    _animator.SetBool(IsLanding, true);
                    _animator.SetBool(IsJumping, false);
                }
            }
        }
        else Debug.LogError("No behaviour created!");
    }
}
