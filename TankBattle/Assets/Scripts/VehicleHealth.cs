using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealthPoint;
    [SerializeField] private GameObject _explosion;
    
    private GameObject _explosionToDelete;
    private float _delayToDestroy = 2f;

    public void TakeDamage(int damage)
    {
        _maxHealthPoint -= damage;
        if (_maxHealthPoint <= 0)
        {
            _explosionToDelete = Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(_explosionToDelete, _delayToDestroy);
        }
    }
}
