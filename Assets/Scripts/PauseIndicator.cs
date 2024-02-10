using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseIndicator : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool pauseBool;

    private void Start()
    {
        pauseBool = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && pauseBool == false)
        {
            pauseMenu.SetActive(true);
            pauseBool = true;
            Time.timeScale = 0f;
        }

        else if(Input.GetKeyDown(KeyCode.P) && pauseBool == true)
        {
            pauseMenu.SetActive(false);
            pauseBool = false;
            Time.timeScale = 1f;
        }
    }
}
