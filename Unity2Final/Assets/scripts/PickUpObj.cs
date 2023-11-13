using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObj : MonoBehaviour
{
    bool pickedUp = false;
    Rigidbody rb;
    public Transform destinationObj;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pickup()
    {
        pickedUp = !pickedUp;

        if(pickedUp)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            transform.position = destinationObj.position;
            transform.parent = destinationObj.transform;
        }
        else
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            transform.parent = null;
        }
    }
}
