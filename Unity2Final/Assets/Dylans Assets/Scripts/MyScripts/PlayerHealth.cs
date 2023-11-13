using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public Image healthBar;
    public float playerHealth = 100;
    public float currentHealth;
    public GameObject spawnPoint;

    public GameObject player;

    void Start()
    {

        currentHealth = playerHealth;
        //GOTO SPAWN STARTING 
        player.transform.position = spawnPoint.transform.position;
        
    }
    private void Update()
    {
        

    }
    public void TakeDamage(float damage)
    {
        if(currentHealth >= 0)
        {
            currentHealth -= damage;
            healthBar.fillAmount = currentHealth / playerHealth;
        }
        if(currentHealth < 1)
        {
            //Player Dead Load new scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
            StartCoroutine(ResetHealth());
        }
    }

    IEnumerator ResetHealth()
    {
        yield return new WaitForSeconds(2f);
        currentHealth = playerHealth;
        healthBar.fillAmount = currentHealth;
    }
  
}
