using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float timeForNextSpawn;
    private int unitToSpawn;
    private int RNG;

    public List<GameObject> EnemyUnits;

    public Transform spawnPoint;

    void Start()
    {
        aiSpawnCycle();
    }


    void aiSpawnCycle()
    {
        RNG = Random.Range(0, 101);
        timeForNextSpawn = Random.Range(2, 6);

        //50% to spawn Grunt
        //35% to spawn marksman
        //15% to spawn Tank

        if(RNG >= 0 && RNG <= 50)
        {
            // Spawn Grunt
            unitToSpawn = 0;
        }
        else if(RNG >= 51 && RNG <= 85)
        {
            //Spawn Marksman
            unitToSpawn = 1;
        }
        else if(RNG >= 86 && RNG <= 100)
        {
            //Spawn Tank
            unitToSpawn = 2;
        }


        Instantiate(EnemyUnits[unitToSpawn], spawnPoint.position, Quaternion.identity);
        Invoke("aiSpawnCycle", timeForNextSpawn);
    }
}