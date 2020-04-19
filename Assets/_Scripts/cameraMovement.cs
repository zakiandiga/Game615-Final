using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform player;
    public float smoothFollow = 0.2f;
    public float smoothHeight;
    public Vector3 camHeight;
    public float mouseSense = 10f;
    //public Quaternion camAngle;
    //public Vector3 defaultView;
    public float turnSpeed;
    float xRot;
    float yRot;
    float yPos = 1f;
    Camera cam;
    public GameObject cameraController;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
    }
        

    // Update is called once per frame
    void Update()
    {
        //POSITION
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;
        Vector3 newPosition = new Vector3(player.position.x, player.position.y +0.6f, player.position.z);
        Vector3 smoothPos = Vector3.Lerp(transform.position, newPosition, smoothFollow * Time.deltaTime);
        transform.position = smoothPos;

        //ROTATION
        xRot += mouseX;
        yRot -= mouseY;
        yRot = Mathf.Clamp(yRot, -40f, 40f);
        transform.rotation = Quaternion.Euler(yRot,xRot,0);

        
         
        //VERTICAL MOUSE = MOVE VERTICAL CAM
        //yPos -= mouseY/20;
        //yPos = Mathf.Clamp(yPos, 0.3f, 2f);
        //Vector3 newCampos = new Vector3(cam.transform.position.x, yPos, cam.transform.position.z);
        //Vector3 camSmooth = Vector3.Lerp(cam.transform.position, newCampos, smoothHeight * Time.deltaTime);
        //Camera.main.transform.position = camSmooth;

        //VERTICAL MOUSE = ROTATE CAM
        //xRot -= mouseY;
        //xRot = Mathf.Clamp(xRot, -30f, 45f);
        //Camera.main.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        
        //cam.transform.LookAt(newPosition);

        //Vector3 direction = newCampos - cam.transform.position;
        //float cosAlpha = Vector3.Dot(Vector3.up, direction.normalized);

        //float alpha = Mathf.Acos(cosAlpha);
        //float xRot = alpha * Mathf.Rad2Deg;
        //xRot = Mathf.Clamp(xRot, -20f, 45f);
        //cam.transform.localRotation = Quaternion.Euler(xRot , 0, 0); //* Mathf.Rad2Deg

        //Vector3 camHeight = new Vector3(0, yPos, -1.25f);
        //Vector3 camInit = new Vector3 (cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        //Vector3 camPos = new Vector3 (cam.transform.position.x, mouseY, cam.transform.position.z);
        //Vector3 camMov = Vector3.Lerp(camInit, camPos, smoothCam * Time.deltaTime);

    }
}
