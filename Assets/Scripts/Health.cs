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
    public EnemyCounter enemyCounter;
    public GameObject gameOverMenu;
    public GameObject looseMenu;

    private int health;

    float timer;
    bool gameFinished;




    private void Start()
    {
        gameFinished = false;   
        enemyDeathEffect = GetComponent<EnemyDeathEffect>();
        gameOverMenu.SetActive(false);
        looseMenu.SetActive(false);

        health = maxHealth;
        if (healthDisplay)
        {
            UpdateHealthDisplay();
        }

        if (countEnemy)
        {
            enemyCounter.CountNewEnemy();
        }
    }

    private void Update()
    {
        if(gameFinished == true)
        {
            timer += Time.deltaTime;
            
            if(timer >= 2f)
            {
                AppearGameOver();
            }
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

            if (countEnemy)
            {
                enemyCounter.RecordDeath();
            }

            OnDie?.Invoke();

            if (gameObject.CompareTag("Player"))
            {
                gameFinished = true;
                ChangeTint();
            }
        }

    }

    private void UpdateHealthDisplay()
    {
        healthDisplay.text ="Health: " + health + "/" + maxHealth;
    }



    private void ChangeTint()
    {
        RenderSettings.ambientLight = Color.red;

    }

    private void AppearGameOver()
    {

        if (timer >= 1.5f)
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0;
        }
    
    }

}
 

