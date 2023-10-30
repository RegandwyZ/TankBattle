using System;
using UnityEngine;

public abstract class BasicAbstractUnit : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    public Rigidbody _objectRb;
    
    protected void Move()
    {
        Vector3 moveDirection = transform.forward * (_speed * Time.deltaTime);
        _objectRb.MovePosition(_objectRb.position + moveDirection);
    }

    protected void Stop()
    {
        _objectRb.velocity = Vector3.zero;
    }

    protected void MoveBack()
    {
        Vector3 moveDirection = -transform.forward * (_speed * Time.deltaTime);
        _objectRb.MovePosition(_objectRb.position + moveDirection);
    }
}
