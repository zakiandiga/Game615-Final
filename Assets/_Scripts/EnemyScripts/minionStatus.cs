using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionStatus : MonoBehaviour
{
    public float maxHealth = 5f;
    public float healthPoints;
    //public bool isChasing = false;
    public bool isDead = false;
    Animator anim;

    void Start()
    {
        healthPoints = maxHealth;
        anim = GetComponent<Animator>();
    }

    void MinionDead()
    {
        isDead = true;
        anim.SetBool("isDie", true);
        GetComponent<Collider>().enabled = false;
        GetComponent<minionBehavior>().enabled = false;
        //anim.enabled = false;
        print("MINION DEAD!!!!");
        //set dead animation
        //destroy after a couple
        //remove from list
    }

    // Update is called once per frame
    void Update()
    {
        if(healthPoints <= 0 && isDead == false)
        {
            MinionDead();
        }
    }
}
