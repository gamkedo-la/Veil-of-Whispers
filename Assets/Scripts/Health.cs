using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public event Action OnPunchRDamage;
    public event Action OnPunchLDamage;
    public event Action OnKickRDamage;
    public event Action OnKickLDamage;
    public event Action OnTakeDamage;
    public event Action OnDie;
    private EnemyDeathEffect enemyDeathEffect;
    public TMP_Text healthDisplay;
    public bool countEnemy = true;
    private int health;




    private void Start()
    {
        enemyDeathEffect = GetComponent<EnemyDeathEffect>();
        health = maxHealth;
        if (healthDisplay)
        {
            UpdateHealthDisplay();
        }

        if(countEnemy)
        {
            EnemyCounter.Instance.CountNewEnemy();
        }
    }


    public void DealDamage(int damage, String tag)
    {
        if (health == 0) { return; }
        health = Mathf.Max(health - damage, 0);

        if (healthDisplay)
        {
            UpdateHealthDisplay();
        }

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
            if (gameObject.CompareTag("Enemy"))
            {
                enemyDeathEffect.InstantiateObject();
            }

            OnDie?.Invoke();

            if (countEnemy)
            {
                EnemyCounter.Instance.RecordDeath();
            }
        }

    }

    private void UpdateHealthDisplay()
    {
        healthDisplay.text ="Health: " + health + "/" + maxHealth;
    }

 
}
