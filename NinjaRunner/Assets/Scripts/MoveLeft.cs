using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float velocity = 30;
    
    private GameOverManager _gameOverManager;
    
    private void Start()
    {
        _gameOverManager = FindObjectOfType<GameOverManager>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!_gameOverManager.IsGameOver)
        {
            transform.Translate(Vector2.left.normalized * Time.deltaTime * velocity);
        }
    }
    
}
