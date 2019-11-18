using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public float Speed = 10.0f;
    public float Gravity = 9.0f;

    private CharacterController C_Controller;
    private Vector3 moveDir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        C_Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (C_Controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= Speed;
        }

        moveDir.y -= Gravity * Time.deltaTime;
        C_Controller.Move(moveDir * Time.deltaTime);
    }
}
