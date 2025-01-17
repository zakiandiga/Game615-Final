﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class minionBehavior : MonoBehaviour
{
    float atkRoutine = 3f;
    float atkDelay = 0.5f;
    float atkStart = 0.2f;
    float patrolDelay;
    float patrolSpeed = 1.5f;
    float chasingSpeed = 3.5f;

    float chasingRadius = 13f;
    float patrolRadius = 6f;

    public GameObject weaponOne;
    CapsuleCollider horn;
    GameObject player;
    NavMeshAgent agent;

    bool isAttack = false;
    
    bool detectPlayer = false;
    bool isChasing = false;
    bool isRun = false;
    
    bool isPatrol = false;
    bool isWalk = false;

    Vector3 chasePos;
    Vector3 patrolPos;

    Animator anim;

    void Start()
    {
        horn = weaponOne.GetComponent<CapsuleCollider>();  //Horn Collider script on Head Game Object!!
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();        
    }

    IEnumerator MinionPatrol()
    {
        float walkTime = Random.Range(2, 5);
        float walkWait = Random.Range(2, 5);
        float patrolX, patrolZ;
        patrolX = transform.position.x + Random.Range(-5f, 5f);
        patrolZ = transform.position.z + Random.Range(-5f, 5f);
        patrolPos = new Vector3(patrolX, transform.position.y, patrolZ);
        agent.SetDestination(patrolPos);
        //print("I am patroling again");
        isPatrol = true;
        
        yield return new WaitForSeconds(walkWait);
        isWalk = true;
        agent.speed = patrolSpeed;
        anim.SetBool("isWalk", true);
        //print("I am patroling toward " + patrolPos);
        
        yield return new WaitForSeconds(walkTime);
        isWalk = false;
        agent.speed = 0;
        anim.SetBool("isWalk", false);
        //print("I am ready for the next patrol");

        isPatrol = false;
    }

    IEnumerator ChasePlayer()
    {
        float checkTime = 0.6f;
        isPatrol = false;
        isWalk = false;
        Vector3 dirToPlayer = transform.position - player.transform.position;
        chasePos = transform.position - dirToPlayer;
        agent.SetDestination(chasePos);

        isChasing = true;
        
        isRun = true;
        agent.speed = chasingSpeed;
        anim.SetBool("isRun", true);
        //print("CHASING PLAYER!!!");
        yield return new WaitForSeconds(checkTime);

        isChasing = false;
    }

    //PLAYER DETECTION
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && isChasing == false)
        {
            detectPlayer = true;
            GetComponent<SphereCollider>().radius = chasingRadius;
            //print("ENEMY DETECTED!");
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            detectPlayer = false;
            anim.SetBool("isRun", false);
            GetComponent<SphereCollider>().radius = patrolRadius;
            //print("ENEMY IS TOO FAR, STOP CHASING");
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {            
            agent.SetDestination(transform.position);
            MinionStab();
        }
    }

    IEnumerator BugAttackDelay() //Testing attack function
    {
        isAttack = true;
        agent.speed = 0;
        yield return new WaitForSeconds(atkStart);
        anim.SetTrigger("StabAtk");
        horn.enabled = true;
        //yield return new WaitForSeconds(atkStart);
        yield return new WaitForSeconds(atkDelay);
        //BugAttack();
        horn.enabled = false;
        isAttack = false;
    }

    void MinionStab()
    {
        
        StartCoroutine(BugAttackDelay());
    }

    void Update()
    {
        if(isPatrol == false && detectPlayer == false && isAttack == false) //PATROL BEHAVIOR WHEN PLAYER NOT DETECTED
        {
            StartCoroutine(MinionPatrol());
        }

        if(isChasing == false && detectPlayer == true && isAttack == false) //CHASING BEHAVIOR WHEN PLAYER DETECTED
        {
            StartCoroutine(ChasePlayer());
        }

        //if (isAttack == false) //and player is in range
        //{
        //StartCoroutine(AttackRoutine());
        //    MinionStab();
        //}
    }
          
    



    //This attack routine should be removed after the enemy has attack behavior
    //IEnumerator AttackRoutine()
    //{

    //    yield return new WaitForSeconds(atkRoutine);
    //    isAttack = false;

    //}
}
