using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform tele;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
            player.transform.position = tele.transform.position;
Debug.Log("Teleporting");
        }
        
    }
}
