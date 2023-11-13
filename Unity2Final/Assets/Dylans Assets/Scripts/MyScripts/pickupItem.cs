using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupItem : MonoBehaviour
{
    //itemCollectorTracker collector;

    void Start()
    {
        //collector = GameObject.Find("coinHUD").GetComponent<itemCollectorTracker>();
    }

    void Update()
    {
        transform.Rotate(0, 0, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //collector.ItemCollect();
            Destroy(gameObject);
        }
    }
}
