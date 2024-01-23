using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] footsteps;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Step()
    {
        AudioClip audioClip = GetAudioClip();
        audioSource.PlayOneShot(audioClip,0.25f);
    }

    private AudioClip GetAudioClip()
    {
        return footsteps[Random.Range(0, footsteps.Length)];
    }
}
