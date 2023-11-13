using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public float playerHealth = 100;
    public float currentHealth;
    public TMP_Text deadText;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerHealth;
        deadText.enabled= false;
    }

    public void TakeDamgae(float damage)
    {
        if(currentHealth >=0)
        {
            currentHealth -= damage;
            healthBar.fillAmount = currentHealth/playerHealth;
        }
        if(currentHealth <= 0)
        {
            StartCoroutine(Respawn());
        }
    }
    IEnumerator Respawn()
    {
        gameObject.GetComponent<CharacterController>().enabled = false;
        gameObject.GetComponent<PlayerInput>().enabled = false;
        deadText.enabled = true;
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(4);
    }
}
