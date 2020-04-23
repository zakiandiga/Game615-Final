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
    public static bool isWalk = false;
    
    public float gravity;
    //private float verticalVel;
    public float allowMove;
    public Transform cameraController;
    public Transform viewPort;
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

        Vector3 forward = cameraController.forward;
        Vector3 right = cameraController.right;
        //float up = 0;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        if(isWalk)
        {
            moveDir = forward * inputY + right * inputX;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), turnSpeed * Time.deltaTime);
            //CHANGE THIS SO THE CHARACTER ALWAYS FACE CAMERA LATER

            //Trial & error for face camera//
            //transform.Translate(0, 0, throttle * Input.GetAxis("Vertical") * Time.deltaTime);

            //moveDir = forward * inputY;
            //transform.rotation = Quaternion.Euler (0, turnSpeed * (inputX*-1) * Time.deltaTime, 0);
            //transform.rotation = Quaternion.Euler(0, xRot, 0);
            //moveDir = forward * inputY + right * inputX;

            //transform.LookAt(viewPort);
        }


        if (isWalk == false)
        {
            //DEFAULT MOVE(RUN)
            moveDir = forward * inputY + right * inputX;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), turnSpeed * Time.deltaTime);

        }
        
    }
    
    void InputMagnitude()
    {
        //Input value from pressing move button/key
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
            isWalk = true;
            throttle = walkSpeed;
        }
        if(Input.GetKeyUp(walk))
        {
            isWalk = false;
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

        //if (control.isGrounded == false)
        //{
        //   verticalVel -= gravity;
        //}

        moveDir.y += Physics.gravity.y * gravity * Time.deltaTime;
        control.Move((moveDir * throttle) * Time.deltaTime);
        print(moveDir);
    }
}
