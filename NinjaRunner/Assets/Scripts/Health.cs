using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour, IDestroyable
{
    [Header("Main Settings")]
    [SerializeField] private bool _isPlayerControlled;

    [Header("Settings")] 
    [SerializeField] private float _hp = 1;
    [SerializeField] private bool _isInvincible = false;
    
    [Header("Fall Damage")]
    [Tooltip("Y position where object must be deleted")]
    [SerializeField]private float _lowBorder;

    private Animator _animator;
    private readonly int _death = Animator.StringToHash("death");
    
    private GameOverManager _gameOverManager;
    private void Start()
    {
        _gameOverManager = FindObjectOfType<GameOverManager>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Die();
        DieFromFalling();
    }

    private void DieFromFalling()
    {
        if (gameObject.transform.position.y < _lowBorder)
        {
            _hp = 0;
        }
    }

    private void Die()
    {
        if (_hp <= 0 && !_isInvincible)
        {
            if (_isPlayerControlled) _gameOverManager.IsGameOver = true;
            int delay = 0;
            _animator.SetTrigger(_death);
            Destroy (gameObject, _animator.GetCurrentAnimatorStateInfo(0).length + delay);
        }
    }

    public void TakeDamage(float damage)
    {
        _hp -= damage;
    }
}
