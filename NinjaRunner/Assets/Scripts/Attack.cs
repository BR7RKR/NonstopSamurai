using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using Utils;
using Timer = Utils.Timer;

[RequireComponent(typeof(Animator))]
public class Attack : MonoBehaviour, IDamagable
{
    [Header("Main Settings")] 
    [SerializeField] private bool _isPlayerControlled;

    [Header("Attack Settings")] 
    private float _damage = 1;
    public float Damage
    {
        get => _damage;
        set => _damage = value < 0 ? _damage : value;
    }
    [Tooltip("Delay only for enemy attack")]
    [SerializeField]private float _attackDelay;
    
    [Header("Attack Circle Settings")]
    [SerializeField]
    private float _radius;
    public float Radius
    {
        get => _radius;
        set => _radius = value < 0 ? _radius : value;
    }

    public Collider2D[] KilledList { get; private set; }
    
    private Animator _animator;
    private readonly int _attackTrig = Animator.StringToHash("attack");

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        DealDamage();
    }

    public void DealDamage()
    {
        if (_isPlayerControlled)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                KilledList = Physics2D.OverlapCircleAll(transform.position, _radius);
                KillInZone(KilledList);
                _animator.SetTrigger(_attackTrig);
            }
        }
        else
        {
            KilledList = Physics2D.OverlapCircleAll(transform.position, _radius);
            KillInZone(KilledList);
            //TODO: Add attack animation trigger
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    private void KillInZone(Collider2D[] cols)
    {
        if (_isPlayerControlled)
        {
            foreach (var col in cols)
            {
                if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Civilian"))
                {
                    col.gameObject.GetComponent<Health>().TakeDamage(_damage);
                }
            }
        }
        else
        {
            foreach (var col in cols)
            {
                if (col.gameObject.CompareTag("Player"))
                    if (Timer.IsTimeOver(ref _attackDelay))
                        col.gameObject.GetComponent<Health>().TakeDamage(_damage);
            }
        }
    }
    
}
