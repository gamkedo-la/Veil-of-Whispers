using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public event Action OnTakeDamage;
    public event Action OnDie;


    private int health;

    Rigidbody rb;


    private void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody>();
    }





    public void DealDamage(int damage)
    {
        if (health == 0) { return; }


        health = Mathf.Max(health - damage, 0);

        OnTakeDamage?.Invoke();

        if(health <= 0)
        {
            OnDie?.Invoke();
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (this.gameObject.CompareTag("Player") && other.gameObject.CompareTag("Floor"))
        {
            OnDie?.Invoke();
            Debug.Log("Works");
        }
    }




}
