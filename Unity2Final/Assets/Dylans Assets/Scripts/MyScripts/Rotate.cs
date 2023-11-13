using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //public GameObject Box;
    [Range(-10f, 10f)]
    public float Xspeed = 0f;
    [Range(-10f, 10f)]
    public float Yspeed = 0f;
    [Range(-10f, 10f)]
    public float Zspeed = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {
            transform.Rotate(Xspeed, Yspeed, Zspeed);

        }
        else
        {
            transform.Rotate(0, 0, 0);


        }
    }
}
