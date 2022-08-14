using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class GenerateLevelSegments : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private List<Transform> _segments;
    [SerializeField] private Transform _currentSegment;

    private float _spawnPosX = 22.74f;
    private float _spawnNextPosX = -4.93f;
    private float _deletePosX;
    private GameOverManager _gameOverManager;
    private void Start()
    {
        _gameOverManager = FindObjectOfType<GameOverManager>();
    }
    
    private void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (_currentSegment.transform.position.x <= _spawnNextPosX && !_gameOverManager.IsGameOver)
        {
            var spawnPos = new Vector3(_spawnPosX, _currentSegment.transform.position.y, 1);
            _currentSegment = Instantiate(_segments[Random.Range(0, _segments.Count)], spawnPos, Quaternion.identity);
        }
    }
}
