using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITowerRotate 
{
    public interface ITowerRotatable
    {
        void RotateTowerToEnemy(Collider[] enemies, float rotateSpeed);
    }
}
