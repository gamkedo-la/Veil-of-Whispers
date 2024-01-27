using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioState : MonoBehaviour
{

    [SerializeField] AudioClip playerPunchSound;

    [SerializeField] AudioClip playerKickSound;

    [SerializeField] AudioClip enemyAttackSound;

    [SerializeField] AudioClip manFearFallingSound;

    [SerializeField] AudioClip enemyGrowlingSound;

    [SerializeField] AudioClip jumpSound;

    [SerializeField] AudioClip bodyHitGround;



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

    public void EnemyGrowlSound()
    {
        AudioSource.PlayClipAtPoint(enemyGrowlingSound, Camera.main.transform.position);
    }
    public void BodyHitGround()
    {
        AudioSource.PlayClipAtPoint(bodyHitGround, Camera.main.transform.position);
    }


    public void JumpSound()
    {
        AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position);
    }

    public void ManFearFallingSound()
    {
        AudioSource.PlayClipAtPoint(manFearFallingSound, Camera.main.transform.position);
    }
}
