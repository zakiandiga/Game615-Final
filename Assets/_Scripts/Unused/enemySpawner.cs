using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject originalMinion;
    public Transform enemyParent;
    public int maxMinionCount = 5;
    int currentMinionCount;
    public int range;
    //public GameObject[] spawnedMinion;
    public List<GameObject> minions = new List<GameObject>();
    //public GameObject[] minionBugs;

    private float posX, posY, posZ;
    float respawnTime = 3f;
    bool isRespawning = false;
    bool isFull = true;

    GameObject minion;

    void Start()
    {
        for (int i = 0; i < maxMinionCount; ++i) //i = spawn point!!
        {
            posX = Random.Range(-20, 20);
            posY = 0;
            posZ = Random.Range(-12, 20);
            minion = Instantiate(originalMinion, new Vector3 (posX, posY, posZ), Quaternion.identity, enemyParent);
            minions.Add(minion);  
        }

    }

    IEnumerator MinionSpawn()
    {
        isRespawning = true;
        posX = Random.Range(-20, 20);
        posY = 0;
        posZ = Random.Range(-12, 20);
        
        minion = Instantiate(originalMinion, new Vector3(posX, posY, posZ), Quaternion.identity, enemyParent);
        minions.Add(minion);
        print("minion respawned");
        yield return new WaitForSeconds(respawnTime);
        isRespawning = false;
    }

    void Update()
    {
        if(isRespawning == false && minions.Count < maxMinionCount)
        {
            StartCoroutine(MinionSpawn());               
        }
    }
}
