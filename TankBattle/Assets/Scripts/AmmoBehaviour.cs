using UnityEngine;

public class AmmoBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _ammo;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _cooldownDuration;

    private float _cooldownTimer;
    private void Update()
    {
        _cooldownTimer += Time.deltaTime;

        if (_cooldownTimer >= _cooldownDuration)
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
}
