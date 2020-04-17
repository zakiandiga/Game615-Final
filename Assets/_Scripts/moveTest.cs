using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTest : MonoBehaviour
{
    float speed = 1f;
    float yPos;
    Vector3 mousePos;
    

    
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        yPos = Input.GetAxis("Vertical");
            yPos = Mathf.Clamp(yPos, 0.5f, 1.5f);
        mousePos = new Vector3 (0, yPos, -1);
        
        transform.position = Vector2.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);

    }


}
