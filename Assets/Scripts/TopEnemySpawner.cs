using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopEnemySpawner : MonoBehaviour
{

    public List<Enemy> enemies = new List<Enemy>();
    public int currWave;
    private int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform[] spawnLocation;
    public int spawnIndex;

    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;
    public bool generating;
    public float speed;
    

    public List<GameObject> spawnedEnemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        currWave = 1;
        GenerateWave();
        speed = 3;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Spawning script
        if (spawnTimer <= 0)
        {

            //spawn an enemy
            if (enemiesToSpawn.Count > 0)
            {
                GameObject enemy = (GameObject)Instantiate(enemiesToSpawn[0], gameObject.transform.parent.transform, false); // spawn first enemy in our list
                enemy.transform.position = new Vector3(spawnLocation[spawnIndex].position.x, spawnLocation[spawnIndex].position.y, -1);
                enemy.GetComponent<BasicObstacleSpeedT>().layer = spawnIndex + 1;
                enemy.GetComponent<BasicObstacleSpeedT>().speed = speed;
                enemiesToSpawn.RemoveAt(0); // and remove it
                spawnedEnemies.Add(enemy);



                spawnTimer = spawnInterval;

                spawnIndex = Random.Range(0, spawnLocation.Length);

                /*
                if (spawnIndex + 1 <= spawnLocation.Length - 1)
                {
                    spawnIndex++;
                }
                else
                {
                    spawnIndex = 0;
                }
                */
            }
            else
            {
                waveTimer = 0; // if no enemies remain, end wave
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }

        print(waveTimer);
        if (waveTimer <= 0 && !generating)
        {
            currWave++;
            spawnedEnemies.Clear();
            GenerateWave();

        }
    }

    public void GenerateWave()
    {
        generating = true;
        waveValue = (1+ (currWave-1)/5) * 50 ;
        GenerateEnemies();

        if(enemiesToSpawn.Count != 0)
        {
            spawnInterval = waveDuration / enemiesToSpawn.Count;
            
        }
        else
        {
            spawnInterval = 0;
        }
        // gives a fixed time between each enemies
        // wave duration is read only
        waveTimer = waveDuration + spawnInterval;
        generating = false;
    }

    public void GenerateEnemies()
    {
        // Create a temporary list of enemies to generate
        // 
        // in a loop grab a random enemy 
        // see if we can afford it
        // if we can, add it to our list, and deduct the cost.

        // repeat... 

        //  -> if we have no points left, leave the loop

        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0 || generatedEnemies.Count < 50)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

    

}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}