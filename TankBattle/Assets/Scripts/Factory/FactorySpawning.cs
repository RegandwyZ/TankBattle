using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorySpawning : MonoBehaviour
{
    [SerializeField] private GameObject _tankPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnTime;
    
    private float _timer;

    private void Start()
    {
        Instantiate(_tankPrefab, _spawnPoint.position, Quaternion.identity);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_spawnTime <= _timer)
        {
            SpawnTank();
            _timer = 0f;
        }

    }

    private void SpawnTank()
    {
        Instantiate(_tankPrefab, _spawnPoint.position, Quaternion.identity);
        
    }
}
