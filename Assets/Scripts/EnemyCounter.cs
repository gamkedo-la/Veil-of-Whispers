using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyCounter : MonoBehaviour
{
    public static EnemyCounter Instance;
    public GameObject prisonerBlocker;
    private TMP_Text enemyDisplay;
    int enemiesTotal = 0;
    int enemiesAlive = 0;
    void Awake()
    {
        Instance = this;   
        enemyDisplay = GetComponent<TMP_Text>();
        UpdateText();
    }

    void UpdateText()
    {
        enemyDisplay.text = "Enemies Left: " + enemiesAlive + "/" + enemiesTotal; 
    }
    public void CountNewEnemy()
    {
        enemiesTotal++;
        enemiesAlive++;
        UpdateText();
    }

    public void RecordDeath()
    {
        enemiesAlive--;
        UpdateText();

        if(enemiesAlive == 0)
        {
            prisonerBlocker.SetActive(false);
        }
    }

}
