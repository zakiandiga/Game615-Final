using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponCollider : MonoBehaviour
{
    public int damage = 1;
    public bool playerMode;
    //public bool enemyMode;
    GameObject player;
    GameObject enemy;

    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");

        if (playerMode)
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
        if(playerMode == false)
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), enemy.GetComponent<Collider>(), true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
