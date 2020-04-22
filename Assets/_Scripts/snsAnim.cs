using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snsAnim : MonoBehaviour
{
    Animator anim;
    Vector3 lastPos = Vector3.zero;
    CharacterController control;
    Vector3 horizontalVelocity = Vector3.zero;
    public KeyCode walk;

    bool isWalk = false;
    bool isMove = false;
    
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
        float horizontalSpeed = horizontalVelocity.magnitude;
        //float verticalSpeed = verticalVelocity.magnitude;

        if (horizontalSpeed > 0)
        {
            anim.SetBool("isMove", true);
        }

        if (horizontalVelocity.magnitude == 0)
        {
            anim.SetBool("isMove", false);
        }

        if (Input.GetKey(walk))
        {
            anim.SetBool("isRun", false);
        }
        if (Input.GetKeyUp(walk))
        {
            anim.SetBool("isRun", true);
        }

        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("atk1");
        }


        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("jump");//REAL ANIMATION NOT AVAILABLE
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
