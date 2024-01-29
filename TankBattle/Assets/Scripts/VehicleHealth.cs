using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealthPoint;
    [SerializeField] private GameObject _explosion;
    
    //private Animation _animation;
    
    private GameObject _explosionToDelete;
    private float _delayToDestroy = 2f;
   
    private const string TankAnim = "2" ; 


    private void Start()
    {
       // _animation = GetComponentInChildren<Animation>();
    }

    public void TakeDamage(int damage)
    {
        
        _maxHealthPoint -= damage;
        if (_maxHealthPoint <= 0)
        {
            //_animation.Play(TankAnim);
          
            
            StartCoroutine(DelayedExplosion());
        }
    }
    
    private IEnumerator DelayedExplosion()
    {
        yield return new WaitForSeconds(1f); 

        _explosionToDelete = Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(_explosionToDelete, _delayToDestroy);
    }
}
