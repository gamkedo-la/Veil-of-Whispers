using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonerBlocker : MonoBehaviour
{
    float timer;
    public GameObject warningText;
    void Start()
    {
        warningText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            warningText.SetActive(true);
            timer = 0;

            if(timer >= 0.5)
            {
                warningText.SetActive(false);
            }
        }
    }
}
