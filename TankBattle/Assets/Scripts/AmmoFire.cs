using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoFire : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private VehicleHealth _vehicleHealth;
    private Transform _startPosAmmo;
    private Rigidbody _ammoRb;
    
    private float _ammoLife = 2; 
    private float _ammo;

    private void Start()
    {
        _ammoRb = GetComponent<Rigidbody>();
        Fire(); 
    }

    private void Update()
    {
        _ammo += Time.deltaTime;
        if (_ammo >= _ammoLife)
        {
            Destroy(gameObject);
            _ammo = 0f;
        }
    }

    private void Fire()
    {
        _startPosAmmo = transform;
        _ammoRb = GetComponent<Rigidbody>();
        var localForce = transform.InverseTransformDirection(_startPosAmmo.forward);
        _ammoRb.AddRelativeForce(localForce * _speed, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            collision.gameObject.GetComponent<VehicleHealth>().TakeDamage(_damage);
            
            Destroy(gameObject);
            
        }
    }
}
