using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreePrisoner : MonoBehaviour
{
    public  Transform player;
    public Animator animator;
    public GameObject winPanel;

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        if(dist < 5f)
        {
            winPanel.SetActive(true);
        }
    }
}
