using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHealth : MonoBehaviour
{

    public GameObject enemy;
    public Transform player;
    Vector3 offset = new Vector3(0f,2f,0f);





    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(player);
        transform.position = enemy.transform.position + offset;
    }
}
