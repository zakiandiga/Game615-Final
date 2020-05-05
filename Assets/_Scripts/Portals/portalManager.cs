using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class portalManager : MonoBehaviour
{
    public GameObject portal1;
    public Text confirmText;
    public GameObject confirmBox;
    public GameObject player;

    public KeyCode yes;
    public KeyCode no;
    bool waitingConfirmation = false;

    void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            confirmBox.SetActive(true);
            waitingConfirmation = true;
            print("Move to safe area");
            
        }
    }

    void PlayerDisable()
    {
    
    }

    void PlayerEnable()
    {

    }

    void Update()
    {
        if(waitingConfirmation == true)
        {
            player.GetComponent<snsControl>().enabled = false;
            if(Input.GetKey(yes))
            {
                confirmBox.SetActive(false);
                waitingConfirmation = false;
                player.GetComponent<snsControl>().enabled = true;
                SceneManager.LoadScene(0);
            }
            if(Input.GetKey(no))
            {
                confirmBox.SetActive(false);
                waitingConfirmation = false;
                player.GetComponent<snsControl>().enabled = true;
            }
        }
    }
}
