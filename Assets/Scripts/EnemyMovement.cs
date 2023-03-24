using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    GameObject Player;
    public float MoveSpeed = 1f;

    private void Start()
    {
        Player = GameObject.Find("Player");
        GetComponent<Rigidbody>().mass = 4;
    }

    void Update()
    {
        transform.LookAt(Player.transform);
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        if (gameObject.transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }
}
