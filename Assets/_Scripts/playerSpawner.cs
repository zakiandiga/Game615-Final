using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawner : MonoBehaviour
{
    GameObject player;
    public Transform spawnPoint1;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player.transform.position = spawnPoint1.position;
        player.transform.eulerAngles = new Vector3(spawnPoint1.eulerAngles.x, spawnPoint1.eulerAngles.y - 90, spawnPoint1.eulerAngles.z);
    }

    void Update()
    {
        
    }
}
