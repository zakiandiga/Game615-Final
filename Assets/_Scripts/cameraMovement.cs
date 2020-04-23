using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject player;
    public Transform viewPort;
    //public Transform player;
    public float smoothFollow = 0.2f;
    public Vector3 camHeight;
    public float mouseSense = 10f;

    //public Quaternion camAngle;
    //public Vector3 defaultView;
    float zoomDir;
    public float smoothZoom = 80f;
    float allowScroll;
    float zoomSpeed;
    float zoomPos;
    float zoomMin = -1.4f;
    float zoomMax = -0.6f;
    float zoomInit = -1.25f;

    private float scrollSpeed = 100f;
    public float turnSpeed;
    float xRot;
    float yRot;
    float yPos = 1f;

    public GameObject cameraController;
    
    Camera cam;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
    }
        

    // Update is called once per frame
    void LateUpdate()
    {
        //POSITION
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 startPos = transform.position;
        Vector3 newPosition = new Vector3(player.transform.position.x, player.transform.position.y +0.6f, player.transform.position.z);
        Vector3 smoothPos = Vector3.Lerp(startPos, newPosition, smoothFollow * Time.deltaTime);
        transform.position = smoothPos;

        //ROTATION
        xRot += mouseX * mouseSense * Time.deltaTime;
        yRot -= mouseY * mouseSense * Time.deltaTime;
        yRot = Mathf.Clamp(yRot, -40f, 40f);
        transform.rotation = Quaternion.Euler(yRot, xRot, 0);

        //TRIAL & ERROR FOR WALK MOVEMENT//
        //if(snsControl.isWalk == false)
        //{

        //}

        //if(snsControl.isWalk)
        //{
        //transform.rotation = player.transform.rotation; //This one is the last resort
        //    yRot -= mouseY;
        //    yRot = Mathf.Clamp(yRot, -40f, 40f);
        //    transform.rotation = Quaternion.Euler(yRot, player.transform.rotation.y,0);
        //xRot += (Input.GetAxis("Horizontal")+mouseX);
        //yRot -= mouseY;
        //yRot = Mathf.Clamp(yRot, -40f, 40f);
        //transform.rotation = Quaternion.Euler(yRot, xRot, 0);

        //}


        //ZOOM
        float zoomDir = Input.GetAxis("Mouse ScrollWheel");
        zoomPos = cam.transform.localPosition.z + (zoomDir * zoomPos * Time.deltaTime);
        zoomPos = Mathf.Clamp(zoomPos, zoomMin, zoomMax);
        cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, zoomPos);
        





        /*float currentZoom = cam.fieldOfView;
        float zoomer = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed ;
        float zoomDir = currentZoom + zoomer;
        
        currentZoom = Mathf.MoveTowards(currentZoom, zoomDir, smoothZoom * Time.deltaTime);
        currentZoom = Mathf.Clamp(currentZoom, 50f, 100f);
        cam.fieldOfView = currentZoom;*/

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
