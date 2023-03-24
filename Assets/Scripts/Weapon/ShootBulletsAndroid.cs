using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBulletsAndroid : MonoBehaviour
{
    public GameObject projectile;
    public GameObject weapon;
    public float bulletSpeed = 200f;
    GameObject theBullet;

    // Update is called once per frame
    public void Shoot()
    {
        theBullet = Instantiate(projectile, weapon.transform.position, weapon.transform.rotation);
        theBullet.GetComponent<Rigidbody>().velocity = weapon.transform.forward * bulletSpeed;
    }
}




