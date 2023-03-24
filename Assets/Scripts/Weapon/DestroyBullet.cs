using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody>().mass = 1.9f;
    }

    void Update()
    {
        float position = gameObject.transform.position.y;
        if (position < -4)
        { 
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        Destroy(gameObject, 0.5f);
    }
}
