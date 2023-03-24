using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour
{
    public GameObject projectile;
    public float bulletSpeed = 200f;
    GameObject theBullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            theBullet = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        
            theBullet.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * bulletSpeed;
        }
    }
}
