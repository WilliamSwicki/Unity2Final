using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zEnemyHealth : MonoBehaviour
{

    public Image healthBar;
    public GameObject healthBarObj;
    public float enemyHealth = 100;
    public float currentHealth;

    void Start()
    {
        currentHealth = enemyHealth;
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth >= 0)
        {
            currentHealth -= damage;
            healthBar.fillAmount = currentHealth / enemyHealth;
        }
        if (currentHealth <= 0)
        {
            //Enemy Dead
            Dead();
        }
    }

    void Dead()
    {
        Destroy(healthBarObj);
        Destroy(gameObject);
    }


    void Update()
    {

    }
}
