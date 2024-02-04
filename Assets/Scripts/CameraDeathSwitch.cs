using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDeathSwitch : MonoBehaviour
{
    public Transform pos;
    CameraLooseFollow1 follow;

    private void Start()
    {
        follow.enabled = false;
    }

    private void Update()
    {
        Vector3.Lerp(gameObject.transform.position, pos.position, 0.5f);
    }
}
