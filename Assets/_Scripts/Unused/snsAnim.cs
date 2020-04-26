using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snsAnim : MonoBehaviour
{
    //Old animator script
    Animator anim;
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
    void LateUpdate()
    {
        horizontalVelocity = new Vector3(control.velocity.x, 0, control.velocity.z);
        float horizontalSpeed = horizontalVelocity.magnitude;
        //float verticalSpeed = verticalVelocity.magnitude;

        if (snsControl.isMove == true)
        {
            anim.SetBool("isMove", true);
        }

        if (snsControl.isMove == false)
        {
            anim.SetBool("isMove", false);
        }

        if (snsControl.isWalk == true)
        {
            anim.SetBool("isRun", false);
        }
        if (snsControl.isWalk == false)
        {
            anim.SetBool("isRun", true);
        }

        if(Input.GetMouseButtonDown(0))
        {
            //anim.SetTrigger("atk1");
            //anim.SetTrigger("atk1");
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
