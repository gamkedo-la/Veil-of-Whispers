using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonerBlocker : MonoBehaviour
{
    public GameObject warningText;
    void Start()
    {
        warningText.SetActive(false);
    }

    // Update is called once per frame



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            warningText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            warningText.SetActive(false);
        }
    }
   
}
