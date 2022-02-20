using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementThreshold = 8f;
    private bool _moveDown;
    
    void Start()
    {
        _moveDown = true;
    }
    
    void Update()
    {
        if (transform.position.y > movementThreshold)
        {
            _moveDown = false;
        }
        else if (transform.position.y < -movementThreshold)
        {
            _moveDown = true;
        }

        if (_moveDown)
        {
            transform.position = 
                new Vector2(transform.position.x,  transform.position.y + movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.position =
                new Vector2(transform.position.x, transform.position.y - movementSpeed * Time.deltaTime);
        }
    }
}
