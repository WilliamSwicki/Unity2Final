using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    ItemCollecter collecter;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        collecter = GameObject.Find("Coin hud").GetComponent<ItemCollecter>();
       clip = gameObject.GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            collecter.CollectedItem();
            StartCoroutine(Colleceted());
        }
    }
    IEnumerator Colleceted()
    {
            gameObject.GetComponent<AudioSource>().PlayOneShot(clip,0.25f);
        transform.position = new Vector3(0, -10, 0);
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
    }
}
