using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snsControl : MonoBehaviour
{
    float inputX;
    float inputY;
    float moveSpeed;
    public float jumpSpeed = 10f;
    public KeyCode Jump;
    public KeyCode walk;
    public float turnSpeed;
    public float walkSpeed;
    public float runSpeed;
    public float throttle;    
    
    public float gravity;
    private float verticalVel;
    public float allowMove;
    public Transform cameraController;
    //public GameObject cameraController;
    
    private Vector3 moveDir = Vector3.zero;
    private Vector3 moveVector;
    CharacterController control;

    
    void Start()
    {
        control = GetComponent<CharacterController>();
        throttle = runSpeed;       
        
    }

    void PlayerMove()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        var forward = cameraController.forward;
        var right = cameraController.right;
        //var forward = cameraController.transform.forward;
        //var right = cameraController.transform.right;
        var up = 0;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        moveDir = forward * inputY + right * inputX;
        //moveDir = new Vector3(forward.x * inputY, 0, right.x * inputX);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), turnSpeed *Time.deltaTime);
    }
    
    void InputMagnitude()
    {
        //Input value
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        //calculation
        moveSpeed = (new Vector2(inputX, inputY).sqrMagnitude);

        if (moveSpeed > allowMove)
        {
            PlayerMove();            
        }
    }


    void WalkRun()
    {
        if(Input.GetKey (walk))
        {
            throttle = walkSpeed;
        }
        if(Input.GetKeyUp(walk))
        {
            throttle = runSpeed;
        }
    }
    
    void LateUpdate()
    {
        WalkRun();

        if (control.isGrounded)
        {
            InputMagnitude();
            //verticalVel -= 0;
            
            if (Input.GetButtonDown("Jump"))
            {
                moveDir.y = jumpSpeed;

            }
        }

        if (control.isGrounded == false)
        {
            verticalVel -= gravity;
        }

        moveDir.y += Physics.gravity.y * gravity * Time.deltaTime;
        control.Move((moveDir * throttle) * Time.deltaTime);
        print(moveDir);
    }
}
