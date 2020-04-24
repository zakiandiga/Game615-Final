using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snsControl : MonoBehaviour
{
    float inputX;
    float inputY;
    public KeyCode walk;
    float moveSpeed;
    public float jumpSpeed = 10f;

    public float turnSpeed;
    public float walkSpeed;
    public float runSpeed;
    public float throttle;
    public static bool isWalk = false;
    public static bool isMove = false;
    
    public float gravity;
    //private float verticalVel;
    public float allowMove;
    public Transform cameraController;
    
    private Vector3 moveDir = Vector3.zero;
    CharacterController control;
    public GameObject weaponEquip;
    CapsuleCollider weapon;
    public static float weaponDamage = 10f; //In case need to be accessed by damage calculation script
    float atkSpeed = 2f; //Sync this with animation!
    
    void Start()
    {
        control = GetComponent<CharacterController>();
        throttle = runSpeed;
        weapon = weaponEquip.GetComponent<CapsuleCollider>();
    }

    void PlayerMove()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        Vector3 forward = cameraController.forward;
        Vector3 right = cameraController.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        if(isWalk)
        {
            moveDir = forward * inputY + right * inputX;
            transform.rotation = Quaternion.Slerp(transform.rotation, cameraController.rotation, turnSpeed *Time.deltaTime);
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
            isMove = true;
        }
    }

    IEnumerator AttackDelay()
    {
        
        yield return new WaitForSeconds(atkSpeed);
        weapon.enabled = false;
        print("Ready to attack!");
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
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(weapon.enabled == false)
            {
                weapon.enabled = true;
                //anim.SetTrigger("atk1");
                StartCoroutine(AttackDelay());
            }            
        }
        if (moveSpeed <= allowMove)
        {
            isMove = false;
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
    }
}
