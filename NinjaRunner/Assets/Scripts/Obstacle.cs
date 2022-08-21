using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Obstacle : MonoBehaviour, IDamagable
{
    [Header("Settings")]
    [SerializeField] private float _damage = 1;

    private Health _player;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _player = col.gameObject.GetComponent<Health>();
            DealDamage();
        }
    }

    public void DealDamage()
    {
        _player.TakeDamage(_damage);
    }
}
