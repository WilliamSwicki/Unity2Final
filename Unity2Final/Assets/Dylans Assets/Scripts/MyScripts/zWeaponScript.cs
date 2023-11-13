using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class zWeaponScript : MonoBehaviour
{

    public float weaponDamage = 10.0f;
    public float weaponRange = 50.0f;
    public float fireRate = 20.0f;
    public float nextFire = 20.0f;
    public Camera fpCamera;


    void Update()
    {
        Debug.DrawRay(fpCamera.transform.position, fpCamera.transform.forward * weaponRange, Color.yellow);
    }
    public void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, weaponRange))
        {
            if(hit.transform.gameObject.tag == "Enemy" || hit.transform.gameObject.name == "Adversary")
            {
                //Hit enemy
                Debug.Log(hit.collider.name);
                
                hit.collider.GetComponent<zEnemyHealth>().TakeDamage(weaponDamage);
            }
        }
    }
    public void FireShot(InputAction.CallbackContext ctx)
    {
        Debug.Log(Time.time);
        Debug.Log(nextFire);
        if(ctx.performed && Time.time >= nextFire)
        {
            Debug.Log("Fire");
            nextFire = Time.time + 1.0f / fireRate;
            Shoot();
        }
    }
    
}
