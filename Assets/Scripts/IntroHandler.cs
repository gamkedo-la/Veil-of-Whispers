using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroHandler : MonoBehaviour
{
    public GameObject handleIntro;
    public AudioClip introClip;
    float timer;
    bool sound;

    private void Start()
    {
        handleIntro.SetActive(false);
        sound = false;
    }

    void Update()
    {
        timer = Time.time;

        if(timer > 0.2)
        {
            handleIntro.SetActive(true);

            if(!sound)
            {
                AudioSource.PlayClipAtPoint(introClip, Camera.main.transform.position,1f);
                sound = true;
            }
        }


        if (timer > 2f)
        {
            handleIntro.SetActive(false);
        }
    }
}
