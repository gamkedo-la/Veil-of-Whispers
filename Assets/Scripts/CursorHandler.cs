using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class CursorHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        else if(Time.timeScale >= 1) 
        { 
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
