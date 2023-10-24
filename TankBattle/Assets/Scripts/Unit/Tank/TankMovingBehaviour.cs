using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TankMovingBehaviour : BasicAbstractUnit
{
   

    private void Start()
    {
        _objectRb = GetComponent<Rigidbody>();
        StartCoroutine(RotatePeriodically());
    }

    private void Update()
    {
       Move();
    }
    
    private  IEnumerator RotatePeriodically()
    {
        while (true)
        {
            float startRotation = _objectRb.rotation.eulerAngles.y;
            float targetRotation = Random.Range(-90, 90);

            float elapsedTime = 0;
            float rotationDuration = 5.0f; 

            while (elapsedTime < rotationDuration)
            {
                float t = elapsedTime / rotationDuration;
                float newRotation = Mathf.Lerp(startRotation, targetRotation, t);

                Quaternion rotation = Quaternion.Euler(0, newRotation, 0);
                _objectRb.MoveRotation(rotation);

                elapsedTime += Time.deltaTime;
                yield return null;
            }
            
            yield return new WaitForSeconds(5.0f);
        }
    }
}
