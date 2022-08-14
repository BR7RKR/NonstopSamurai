using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Civilian : MonoBehaviour
{
    private Animator _animator;

    private readonly int _death = Animator.StringToHash("death");

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
