using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zPickupObj : MonoBehaviour
{

    bool pickedUp = false;

    Rigidbody rb;

    [SerializeField] Transform destinationObj;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        
    }

    public void Pickup()
    {
        pickedUp = !pickedUp;

        if(pickedUp )
        {
            rb.useGravity = false;
            rb.isKinematic = true;

            transform.position = destinationObj.position;
            transform.parent = destinationObj;

        }
        else
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            //drops where ever player brought it 
            transform.parent = null;
        }

    }
}
