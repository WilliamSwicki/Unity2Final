using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class zFallingZone : MonoBehaviour
{
    public GameObject player;
    public Transform fallingSpawnPoint;
    CharacterController controller;

    void Start()
    {
        controller = player.GetComponent<CharacterController>();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controller.enabled = false;
            other.transform.position = fallingSpawnPoint.position;
            Debug.Log("Hit trigger in falling zone: ");
            controller.enabled = true;  
        }


    }
    
    void Update()
    {
        
    }

}
