using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public float secondsUntilRemoved = 2.0f;
    void Start()
    {
        Destroy(gameObject, secondsUntilRemoved);
    }

 
}
