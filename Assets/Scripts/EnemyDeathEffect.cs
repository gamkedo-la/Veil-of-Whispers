using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyDeathEffect : MonoBehaviour
{
    public GameObject deathEffect;
    public Transform insPos;
    float timer;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer = Time.time;
    }
    public void InstantiateObject()
    {
        Instantiate(deathEffect, insPos.position, transform.rotation);
        if(timer > 2)
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        gameObject.SetActive(false);
    }
}
