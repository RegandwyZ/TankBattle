using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotate : MonoBehaviour, ITowerRotate
{
    [SerializeField] private float _radius = 45f;
    [SerializeField] private float _rotateTowerSpeed = 1.5f;
    [SerializeField] private GameObject _tower;

    private Collider[] _result;
    public Collider[] Result => _result;
    
    [SerializeField] private LayerMask _layerMask;
    
    private void Start()
    {
        _result = new Collider[10];
    }

    private void FixedUpdate()
    {
        Collider[] currentColliders = new Collider[10];
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, _radius, currentColliders, _layerMask);
        
        for (int i = 0; i < _result.Length; i++)
            _result[i] = null;
        
        for (int i = 0; i < numColliders; i++)
            _result[i] = currentColliders[i];
        
        RotateToEnemy();
    }

    private void RotateTowerToEnemy(Collider[] enemies, float rotateSpeed)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                Transform target = enemies[i].transform;
                Vector3 targetDirection = target.position - _tower.transform.position;
                targetDirection.y = 0f;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                _tower.transform.rotation = Quaternion.Slerp(_tower.transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
                return;
            }
        }
       
    }

    private void RotateToEnemy()
    {
        RotateTowerToEnemy(_result, _rotateTowerSpeed);
    }
}
