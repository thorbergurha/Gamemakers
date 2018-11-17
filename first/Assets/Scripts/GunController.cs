using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    //Shooting
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    float lastfired;
    float shotInterval = 0.2f;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))//if mouse left is down
        {
            if (Time.time - lastfired >= shotInterval)//fire every _shotInterval 
            {
                Fire();
                lastfired = Time.time;
            }
        }
    }

    void Fire()
    {
        //Create the bullet from the bullet prefab
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        //Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 20;

        // Destroy the bullt after 2 seconds or on collision
        Destroy(bullet, 2.0f);
    }
}
