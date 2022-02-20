using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementThreshold = 8f;
    private bool _moveRight;
    
    void Start()
    {
        _moveRight = true;
    }
    
    void Update()
    {
        if (transform.position.x > movementThreshold)
        {
            _moveRight = false;
        }
        else if (transform.position.x < -movementThreshold)
        {
            _moveRight = true;
        }

        if (_moveRight)
        {
            transform.position = 
                new Vector2(transform.position.x + movementSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position =
                new Vector2(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y);
        }
    }
}
