using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform startPoint;
    public Transform endPoint;

    public float speed = 1.0f;
    public float dist = 3.0f;
    public float startTime;



    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float distMoved = Mathf.PingPong(Time.time - startTime, dist/speed);
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, distMoved/dist);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
