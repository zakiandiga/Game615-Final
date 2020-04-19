using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    Animator anim;
    public KeyCode moveForward;
    public KeyCode moveBackward;
    Vector3 lastPos = Vector3.zero;
    CharacterController control;
    Vector3 horizontalVelocity = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalVelocity = new Vector3(control.velocity.x, 0, control.velocity.z);
        //verticallVelocity = new Vector3(0, control.velocity.y, 0);
        float horizontalSpeed = horizontalVelocity.magnitude;
        //float verticalSpeed = verticalVelocity.magnitude;

        if (horizontalSpeed > 0)
        {
            anim.SetTrigger("walk");
        }
        if(horizontalVelocity.magnitude == 0)
        {
            anim.SetTrigger("idle");
        }
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("jump");
        }

        /*if (lastPos != gameObject.transform.position)
        {
            anim.SetTrigger("walk");
        }

        lastPos = gameObject.transform.position;*/

        //if (lastPos == gameObject.transform.position)
        //{
        //    anim.SetTrigger("idle");
        //}

    }
}
