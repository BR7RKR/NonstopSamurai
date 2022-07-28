using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float velocity = 30;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.left.normalized * Time.deltaTime * velocity);
    }
    
}
