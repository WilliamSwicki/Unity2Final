using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Image healthBar;
    public GameObject healthBarObj;
    public float enemyHealth = 100;
    public float currentHealth;
    public GameObject counter;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyHealth;
    }

    public void TakeDamgae(float damage)
    {
        if (currentHealth >= 0)
        {
            currentHealth -= damage;
            healthBar.fillAmount = currentHealth / enemyHealth;
        }
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        counter.GetComponent<EnemyCounter>().aliveEnemy--;
        Destroy(healthBarObj);
        Destroy(gameObject);
    }
}
