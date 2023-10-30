using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovingBehaviour : BasicAbstractUnit
{
    [SerializeField] private  float _rotationDuration = 5.0f;
    
    private float _newRotation;
    private bool _isMove = true;

    private void Start()
    {
        _objectRb = GetComponent<Rigidbody>();
        StartCoroutine(RotatePeriodically());
    }

    private void Update()
    {
        if (_isMove)
        {
            Move();
        }

        if (!_isMove)
        {
            MoveBack();
            _newRotation = 0f;
        }

        if (_objectRb.transform.position.y <= -10f)
        {
            Destroy(gameObject);
        }
    }
    
    private  IEnumerator RotatePeriodically()
    {
        while (true)
        {
            float startRotation = _objectRb.rotation.eulerAngles.y;
            float targetRotation = Random.Range(-90, 90);

            float elapsedTime = 0;
           

            while (elapsedTime < _rotationDuration)
            {
                float t = elapsedTime / _rotationDuration;
                _newRotation = Mathf.Lerp(startRotation, targetRotation, t);

                Quaternion rotation = Quaternion.Euler(0, _newRotation, 0);
                _objectRb.MoveRotation(rotation);

                elapsedTime += Time.deltaTime;
                yield return null;
            }
            
            yield return new WaitForSeconds(5.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            _isMove = false;
            
            float startTime = 0;
            const float endTime = 3f;
            
            startTime += Time.deltaTime;
            if (startTime >= endTime)
            {
                _isMove = true;
            }
            
        }
        
    }
}
