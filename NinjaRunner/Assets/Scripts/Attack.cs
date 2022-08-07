using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Attack : MonoBehaviour, IDamagable
{
    [Header("Main Settings")] 
    [SerializeField] private bool _isPlayerControlled;

    [Header("Attack Settings")] 
    private float _damage;
    public float Damage
    {
        get => _damage;
        set => _damage = value < 0 ? _damage : value;
    }
    
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
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
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
        else Debug.LogError("No behaviour created!");
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
                if (col.gameObject.CompareTag("Enemy"))
                {
                    col.gameObject.GetComponent<Enemy>().Destroy();
                }
                else if(col.gameObject.CompareTag("Civilian"))
                {
                    col.gameObject.GetComponent<Civilian>().Destroy();
                }
            }
        }
        else Debug.LogError("No behaviour created!");
    }
}