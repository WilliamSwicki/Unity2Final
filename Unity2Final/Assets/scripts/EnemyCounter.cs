using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    public int aliveEnemy;
    public GameObject[] enemy;
    public TMP_Text winText;

    // Start is called before the first frame update
    void Start()
    {
        aliveEnemy = enemy.Length;
        winText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(aliveEnemy <= 0)
        {
            StartCoroutine(AllDead());
        }
    }
    IEnumerator AllDead()
    {
        winText.enabled = true;
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(5);
    }
}
