using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _AudioSource;
    [Header("Audio Clips")]
    public List<GameAudioClip> audioClips;

    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Play(string trackName)
    {
        GameAudioClip clipToPlay = audioClips.Find(clip => clip.GetName() == trackName);
        if (clipToPlay != null)
        {
            _AudioSource.clip = clipToPlay.audioClip;
            _AudioSource.Play();
        }
        else
        {
            Debug.Log("Track not found: " + trackName);
        }


    }
}

[System.Serializable]
public class GameAudioClip
{
    public string TrackName;
    public AudioClip audioClip;

    public string GetName() => TrackName;
}
