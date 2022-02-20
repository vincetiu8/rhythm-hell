using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float secondsLasted;
    public static Counter CounterInstance;    
    
    private void Awake()
    {
        CounterInstance = this;
        secondsLasted = 0;
    }

    private void Increment()
    {
        secondsLasted++;
    }

    private void Start()
    {
        InvokeRepeating("Increment", 0, 1);
    }

    public void StopIncrement()
    {
        CancelInvoke();
    }

    public float GetTime()
    {
        return secondsLasted / 60f;
    }
}
