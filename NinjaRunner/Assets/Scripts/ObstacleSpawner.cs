using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    //TODO: Change Algorithm 
    [Header("Settings")] [SerializeField] private GameObject[] _obstacles;
    [SerializeField] private GameObject[] _safeObstacles;
    [SerializeField] private List<Transform> _points;

    private void Awake()
    {
        if (_points.Count == 0) throw new Exception("No spawn points!");

        if (_safeObstacles.Length == 0 && _obstacles.Length == 0)
            throw new Exception("No obstacles or safe obstacles!");

        SpawnObstacle();
    }


    private void SpawnObstacle()
    {
        for (var i = 0; i < _points.Count; i++)
        {
            var spawnPoint = _points[i];
            if (_safeObstacles.Length == 0 || i % 2 != 0)
            {
                var obstacle = _obstacles[Random.Range(0, _obstacles.Length)];
                Instantiate(obstacle, spawnPoint.position, spawnPoint.rotation);
            }
            else if (_obstacles.Length == 0 || i % 2 == 0)
            {
                var safeObstacle = _safeObstacles[Random.Range(0, _safeObstacles.Length)];
                Instantiate(safeObstacle, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}