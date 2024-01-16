using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioState : MonoBehaviour
{
    [SerializeField] AudioClip footStepSound;

    [SerializeField] AudioClip playerAttackSound;

    [SerializeField] AudioClip enemyAttackSound;

    [SerializeField] AudioSource src;


   public void PlayerAttackSound()
   {
        AudioSource.PlayClipAtPoint(playerAttackSound,Camera.main.transform.position);
   }

    public void EnemyAttackSound()
    {
        AudioSource.PlayClipAtPoint(enemyAttackSound, Camera.main.transform.position);
    }

    public void PlayFootStepSound()
    {
        src.Play();
    }

    public void StopFootStepSound()
    {
        src.Play();
    }
}
