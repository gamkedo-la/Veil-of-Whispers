using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioState : MonoBehaviour
{

    [SerializeField] AudioClip playerPunchSound;

    [SerializeField] AudioClip playerKickSound;

    [SerializeField] AudioClip enemyAttackSound;

    [SerializeField] AudioSource src;


   public void PlayerPunchSound()
   {
        AudioSource.PlayClipAtPoint(playerPunchSound,Camera.main.transform.position);
   }

    public void PlayerKickSound()
    {
        AudioSource.PlayClipAtPoint(playerKickSound, Camera.main.transform.position);
    }

    public void EnemyAttackSound()
    {
        AudioSource.PlayClipAtPoint(enemyAttackSound, Camera.main.transform.position);
    }

    //public void PlayFootStepSound()
    //{
    //    src.Play();
    //}

    //public void StopFootStepSound()
    //{
    //    src.Stop();
    //}
}
