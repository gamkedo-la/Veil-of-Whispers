using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreePrisoner : MonoBehaviour
{
    public  Transform player;
    public Animator animator;
    public GameObject winPanel;
    public GameObject gameOver;


    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        if(dist < 5f)
        {
            winPanel.SetActive(true);
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
