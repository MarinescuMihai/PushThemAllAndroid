using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Rigidbody playerBody;
    float turnSmoothVelocity;
    Vector3 direction;

    public float speed = 2.5f;
    public float turnSmoothTime = 0.1f;
    public Joystick joystick;
    public bool useJoystick = true;

    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        direction = GetDirection();

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            playerBody.MovePosition(transform.position + direction * Time.deltaTime * speed * -1f);
        }
    }

    Vector3 GetDirection() 
    {
        if (useJoystick)
        {
            return new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        }
        else
        {
            return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
    }

    private void Awake()
    {
        Time.timeScale = 1f;
    }
}
