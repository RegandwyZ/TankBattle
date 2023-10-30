using System;
using UnityEngine;

public class AmmoBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _ammo;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _cooldownDuration;

    [SerializeField] private TowerRotate _towerRotate;
    
    private float _cooldownTimer;
    

    private void Update()
    {
        _cooldownTimer += Time.deltaTime;

        if (_cooldownTimer >= _cooldownDuration && _towerRotate.Result[0] != null && IsTowerFacingEnemy(_towerRotate.Result[0].transform))
        {
            CreateAmmo();
            _cooldownTimer = 0;
        }
    }
    
    private void CreateAmmo()
    {
        var firePointTransform = _firePoint.transform;
        _ammo.transform.position = firePointTransform.position;
        _ammo.transform.rotation = firePointTransform.rotation;
        _ammo.transform.Translate(0,0,2);
        Instantiate(_ammo);
    }
    
    private bool IsTowerFacingEnemy(Transform enemyTransform)
    {
        if (enemyTransform == null)
            return false;

        Vector3 toEnemy = enemyTransform.position - _firePoint.position;
        Vector3 towerForward = _firePoint.forward;
        
        float dotProduct = Vector3.Dot(toEnemy.normalized, towerForward);
        
        return dotProduct > 0;
    }
}
