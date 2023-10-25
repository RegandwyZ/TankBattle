using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotate : MonoBehaviour, ITowerRotate
{
    [SerializeField] private float _radius = 45f;
    [SerializeField] private float _rotateTowerSpeed = 1.5f;
    [SerializeField] private GameObject _tower;

    private Collider[] _result;
    [SerializeField] private LayerMask _layerMask;
    
    private void Start()
    {
        _result = new Collider[10];
    }

    private void FixedUpdate()
    {
        Physics.OverlapSphereNonAlloc(transform.position, _radius, _result, _layerMask);
        RotateToEnemy();
    }

    private void RotateTowerToEnemy(Collider[] enemies, float rotateSpeed)
    {
        if (enemies[0] != null)
        {
            Transform target = enemies[0].transform;
            Vector3 targetDirection = target.position - _tower.transform.position;
            targetDirection.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            _tower.transform.rotation = Quaternion.Slerp(_tower.transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }

    private void RotateToEnemy()
    {
        RotateTowerToEnemy(_result, _rotateTowerSpeed);
    }
}
