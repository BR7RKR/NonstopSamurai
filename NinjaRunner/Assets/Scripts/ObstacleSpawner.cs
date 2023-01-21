using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Settings")] [SerializeField] private GameObject[] _obstacles;
    [SerializeField] private GameObject[] _safeObstacles;
    private Transform[] _points;

    private void OnEnable()
    {
        if (transform.childCount == 0) throw new Exception("No spawn points!");

        if (_safeObstacles.Length == 0 && _obstacles.Length == 0)
            throw new Exception("No obstacles or safe obstacles!");

        _points = new Transform[transform.childCount];
        for (var i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i);
        }
        SpawnObstacle();
    }


    private void SpawnObstacle()
    {
        for (var i = 0; i < _points.Length; i++)
        {
            var spawnPoint = _points[i].transform;
            if (_safeObstacles.Length == 0 || i % 2 != 0)
            {
                var obstacle = _obstacles[Random.Range(0, _obstacles.Length)];
                Instantiate(obstacle, spawnPoint.position, spawnPoint.rotation).transform.parent = spawnPoint.parent;
            }
            else if (_obstacles.Length == 0 || i % 2 == 0)
            {
                var safeObstacle = _safeObstacles[Random.Range(0, _safeObstacles.Length)];
                Instantiate(safeObstacle, spawnPoint.position, spawnPoint.rotation).transform.parent =
                    spawnPoint.parent;
            }
        }
    }
}