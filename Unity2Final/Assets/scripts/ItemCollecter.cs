using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ItemCollecter : MonoBehaviour
{
    public int itemsCollected, itemsInLevel;
    public TMP_Text itemHUD;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Instrustions());
    }

    public void CollectedItem()
    {
        itemsCollected++;
        itemHUD.text = $"Items {itemsCollected}/{itemsInLevel}";

        if(itemsCollected >= itemsInLevel)
        {
            //change scene
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        itemHUD.text = $"You found all the items!";
        yield return new WaitForSeconds(2);
           Scene currentScene = SceneManager.GetActiveScene();
        int buildIndex = currentScene.buildIndex;
        switch(buildIndex)
        {
            case 0:
                SceneManager.LoadScene(1);
                break;
                case 1:
                SceneManager.LoadScene(2);
                break;
            case 2:
                SceneManager.LoadScene(3);
                break;
            case 3:
                SceneManager.LoadScene(4);
                break;
        }
        
    }
    IEnumerator Instrustions()
    {
        itemHUD.text = $"Use wasd and space to move and jump \nFind and collect all coins";
        yield return new WaitForSeconds(3);
        itemHUD.text = $"Items {itemsCollected}/{itemsInLevel}";
    }
}
