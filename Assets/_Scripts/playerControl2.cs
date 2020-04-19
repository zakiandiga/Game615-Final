using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl2 : MonoBehaviour
{
    float inputX;
    float inputY;

    public float moveSpeed;
    public float turnSpeed;
    public float jumpPow;
    public float gravityScale;

    private Vector3 moveDir;
    private Vector3 faceDir;
    
    CharacterController controller;
    public Transform cameraController;
    private Transform originFace;
    private float turnAngle;

    //public KeyCode Jump;

    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        //float yDir = moveDir.y;
        //moveDir = new Vector3(inputX * moveSpeed, moveDir.y, inputY * moveSpeed);
        moveDir = (cameraController.forward * moveSpeed * inputY) + (cameraController.right * moveSpeed * inputX);
        moveDir = moveDir.normalized * moveSpeed;
        //moveDir.y = yDir;

        
        //float eulerFace = cameraController.eulerAngles.y;
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, eulerFace, transform.eulerAngles.z);
        //transform.rotation = Quaternion.Lerp(transform.rotation, transform.right, turnSpeed);
        //Vector3 faceDir = cameraController.position;
        ////Quaternion rotation = Quaternion.LookRotation(faceDir, Vector3.up);
        
        //faceDir = new Vector3(moveDir.x, moveDir.y, moveDir.z); //THIS IS THE KEY TO THE NEXT LINE!
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), turnSpeed); //THIS ONE WORKING BUT ROTATE THE PLAYER x according to vertival movement
        //AT THE END OF MOVE, STILL FACE ORIGINAL POS!
        print(transform.rotation.x);
        
        //transform.Rotate(-90f, 0, 0, Space.Self);


        if (controller.isGrounded == true)
        {
            print("isGrounded");
            if (Input.GetButtonDown("Jump"))
            {
                print("Jump");
                moveDir.y = jumpPow;
                Debug.Log(jumpPow);
            }
        }

        moveDir.y = moveDir.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDir * Time.deltaTime);
    }
}

/*
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
*/