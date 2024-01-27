using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public event Action OnPunchRDamage;
    public event Action OnPunchLDamage;
    public event Action OnKickRDamage;
    public event Action OnKickLDamage;
    public event Action OnTakeDamage;
    public event Action OnDie;
    private int health;



    private void Start()
    {
        health = maxHealth;
    }


    public void DealDamage(int damage, String tag)
    {
        if (health == 0) { return; }
        health = Mathf.Max(health - damage, 0);

        if (tag == "RightPunch")
        {
            OnPunchRDamage?.Invoke();
        }

        else if (tag == "LeftPunch")
        {
            OnPunchLDamage?.Invoke();
        }

        else if (tag == "RightKick")
        {
            OnKickLDamage?.Invoke();
        }

        else if (tag == "LeftKick")
        {
            OnKickRDamage?.Invoke();
        }

        else
        {
            OnTakeDamage?.Invoke();
        }


        if (health <= 0)
        {
            OnDie?.Invoke();
        }

    }

 



}
