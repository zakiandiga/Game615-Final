using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerConlrol : MonoBehaviour
{
    float inputX;
    float inputY;
    float moveSpeed;
    public float jumpSpeed = 10f;
    public KeyCode Jump;
    public float turnSpeed;
    public float throttle = 5;
    
    public float gravity;
    private float verticalVel;
    public float allowMove;
    public Transform cameraController;
    //public float jump;
    
    private Vector3 moveDir = Vector3.zero;
    private Vector3 moveVector;
    CharacterController control;

    
    void Start()
    {
        control = GetComponent<CharacterController>();
        //control.detectCollisions = false;
    }

    void PlayerMove()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        var forward = cameraController.forward;
        var right = cameraController.right;
        var up = 0;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        moveDir = forward * inputY + right * inputX;
        //moveDir = new Vector3(forward.x * inputY, 0, right.x * inputX);
        print(moveDir);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), turnSpeed);



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

    void Update()
    {
        InputMagnitude();



        if (control.isGrounded)
        {
            Debug.Log("isGrounded");
            //verticalVel -= 0;
            
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Jump");
                moveDir.y = jumpSpeed;

            }
        }



        if (control.isGrounded == false)
        {
            verticalVel -= gravity;
        }

        moveDir.y += Physics.gravity.y * gravity * Time.deltaTime;
        control.Move((moveDir * throttle) * Time.deltaTime);

        //control.Move(moveDir * Time.deltaTime);
        //moveDir.y = gravity * Time.deltaTime;
        //control.Move(moveDir);

    }
}
