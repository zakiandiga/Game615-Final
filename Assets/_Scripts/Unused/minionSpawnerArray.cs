using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionSpawnerArray : MonoBehaviour
{
    public GameObject[] minions = new GameObject[5];
    public GameObject originalMinion;
    public Transform enemyParent;
    int maxMinion = 5;
    float posX, posY, posZ;

    void Start()
    {

        for (int i = 0; i < minions.Length; ++i)
        {
            posX = Random.Range(-20, 20);
            posY = 0;
            posZ = Random.Range(-12, 20);
            GameObject minion = Instantiate(originalMinion, new Vector3(posX, posY, posZ), Quaternion.identity, enemyParent);

            minions[i] = minion;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
