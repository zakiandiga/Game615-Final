using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterControl : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;

    public KeyCode front;
    public KeyCode back;
    public KeyCode left;
    public KeyCode right;


    void Move()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

        transform.Rotate(0, turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0);
        /*if (Input.GetKey(front))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * moveSpeed;//maju
        }
        if (Input.GetKeyDown(back))
        {
            transform.position += transform.TransformDirection(Vector3.back) * Time.deltaTime * moveSpeed;//mundur
        }
        if (Input.GetKeyDown(left))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * moveSpeed;//kiri
        }
        if (Input.GetKeyDown(right))
        {
            transform.position += transform.TransformDirection(Vector3.right) * Time.deltaTime * moveSpeed;//kanan
        }*/
    }
}
