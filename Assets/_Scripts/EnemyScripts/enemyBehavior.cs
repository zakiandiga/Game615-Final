using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyBehavior : MonoBehaviour
{
    float atkRoutine = 3f;
    float atkDelay = 0.5f;
    float atkStart = 0.3f;
    bool isAttack = false;
    public GameObject weaponOne;
    CapsuleCollider horn;

    //public GameObject player;

    Animator anim;

    void Start()
    {
        horn = weaponOne.GetComponent<CapsuleCollider>();  //Horn Collider script on Head Game Object!!
        anim = GetComponent<Animator>();
    }

    IEnumerator BugAttackDelay() //Testing attack function
    {
        yield return new WaitForSeconds(atkStart);
        horn.enabled = true;
        yield return new WaitForSeconds(atkDelay);        
        //BugAttack();
        horn.enabled = false;
        
    }



    void BugAttack()
    {
        anim.SetTrigger("StabAtk");
        isAttack = true;

        
        StartCoroutine(BugAttackDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttack == false)
        {
            StartCoroutine(AttackRoutine());
            BugAttack();
        }
    }

    IEnumerator AttackRoutine()
    {

        yield return new WaitForSeconds(atkRoutine);
        isAttack = false;

    }
}
