using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerConlrol : MonoBehaviour
{
    float inputX;
    float inputY;
    float moveSpeed;
    public float turnSpeed;
    public float throttle = 5;
    
    public float gravity;
    private float verticalVel;
    public float allowRotation;
    public Transform cameraController;
    //public float jump;
    
    private Vector3 moveDir = Vector3.zero;
    private Vector3 moveVector;
    CharacterController control;

    
    void Start()
    {
        control = GetComponent<CharacterController>();
        control.detectCollisions = false;
    }

    void PlayerMove()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        var forward = cameraController.forward;
        var right = cameraController.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        moveDir = forward * inputY + right * inputX;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), turnSpeed);

    }



    void InputMagnitude()
    {
        //Input value
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        //speed = new Vector2(inputX, inputY).sqrMagnitude;

        //calculation
        moveSpeed = (new Vector2(inputX, inputY).sqrMagnitude);
        
        if (moveSpeed > allowRotation)
        {
            PlayerMove();
        }

    }

    void Update()
    {
        //CharacterController control = GetComponent<CharacterController>();
        InputMagnitude();
        
        
        if (control.isGrounded)
        {
            verticalVel -= 0;

        }
        if(control.isGrounded == false)
        {
            verticalVel -= gravity;
        }

        moveDir.y -= gravity * Time.deltaTime;
        control.Move((moveDir * throttle) * Time.deltaTime);

        //control.Move(moveDir * Time.deltaTime);
        //moveDir.y = gravity * Time.deltaTime;
        //control.Move(moveDir);

    }
}
