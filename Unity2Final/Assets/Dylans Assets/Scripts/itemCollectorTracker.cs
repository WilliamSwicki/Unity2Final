using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class itemCollectorTracker : MonoBehaviour
{
    //USED ONLY CURRENTLY IN GAME SCENE

    public int itemsCollected = 0, itemsInLevel = 6;

    public TMP_Text itemHUD;

    [SerializeField] AudioClip[] coinSounds;
    [SerializeField] AudioClip gameOverSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ItemCollect()
    {   
        //plays various coin sounds 
        int random = Random.Range(0, coinSounds.Length);
        GetComponent<AudioSource>().PlayOneShot(coinSounds[random]);

        //score increment
        itemsCollected++;
        itemHUD.text = $"Coins {itemsCollected}/{itemsInLevel}";

        //game over check
        if(itemsCollected >= itemsInLevel)
        {
            //change scenes
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        itemHUD.text = $"You collected all the Coins";
        GetComponent<AudioSource>().PlayOneShot(gameOverSound);

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
