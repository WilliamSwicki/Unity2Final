using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public GameObject player;
    public GameObject checkpoint;
    public GameObject respawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        checkpoint = this.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.GetComponent<PlayerHealth>().activeRespawn = respawnpoint;
        }
    }
}
