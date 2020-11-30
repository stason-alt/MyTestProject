using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotA : MonoBehaviour
{
    private float offset;
    public TouchController touch;

    private Vector3 tempos;

    public float sensativity = 0.5f;
    
    void Update()
    {
        if (touch.downHandler)
        {
            Vector3 direction = touch.GetDirection();
            direction = direction * sensativity;
            transform.position = new Vector3(direction.x, 0, direction.y);
        }
    }
}
