using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTilt : MonoBehaviour
{
    GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Avelyn");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(transform.position.x, 
                                        transform.parent.position.y, //Y should still
                                        transform.parent.position.z);
        transform.LookAt(targetPos);
    }
}
