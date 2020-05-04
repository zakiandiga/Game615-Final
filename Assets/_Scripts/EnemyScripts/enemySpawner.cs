using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject originalMinion;
    public Transform enemyParent;
    public int minionCount = 10;
    public int range;
    //public GameObject[] spawnedMinion;
    public List<GameObject> minions = new List<GameObject>();

    private float posX, posY, posZ;

    void Start()
    {
        for (int i = 0; i < minionCount; ++i) //i = spawn point!!
        {
            posX = Random.Range(-25, 25);
            posY = 0;
            posZ = Random.Range(-25, 25);
            GameObject minion = Instantiate(originalMinion, new Vector3 (posX, posY, posZ), Quaternion.identity, enemyParent);
            minions.Add(minion);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
