using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour, IDestroyable
{
    private Animator _animator;

    private readonly int _death = Animator.StringToHash("death");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroy()
    {
        _animator.SetTrigger(_death);
        int delay = 0;
        Destroy (gameObject, _animator.GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
