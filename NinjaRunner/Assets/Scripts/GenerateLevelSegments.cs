using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class GenerateLevelSegments : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform[] _segments;
    [SerializeField] private Transform _currentSegment;

    private const float SpawnPosX = 22.68f;
    private const float SpawnNextPosX = -4.93f;
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
        if (_currentSegment.transform.position.x <= SpawnNextPosX && !_gameOverManager.IsGameOver)
        {
            var spawnPos = new Vector3(SpawnPosX, _currentSegment.transform.position.y, 1);
            _currentSegment = Instantiate(_segments[Random.Range(0, _segments.Length)], spawnPos, Quaternion.identity);
        }
    }
}
