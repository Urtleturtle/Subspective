using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideEnemySpawner : MonoBehaviour
{

    public List<EnemyS> enemies = new List<EnemyS>();
    public List<GameObject> treasures = new List<GameObject>();

    public int currWave;
    private int waveValue;
    public List<int> enemiesToSpawn = new List<int>();

    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;
    public bool generating;
    public float speed;
    public TopEnemySpawner spawner;
    public TopDownController controller;

    public List<GameObject> spawnedEnemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GenerateWave();
        currWave = 1;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = spawner.speed / 9.2f * 5.5f;
        //Spawning script
        if (spawnTimer <= 0)
        {

            //spawn an enemy
            if (enemiesToSpawn.Count > 0)
            {
                EnemyS es = enemies[enemiesToSpawn[0]];

                StartCoroutine(spawnGroup(es, Random.Range(es.instancesMin, es.instancesMax), Random.Range(1, 4)));

                spawnTimer = spawnInterval;


                //random change for treasure chest
                if (Random.Range(0, 101) < 20)
                {
                    GameObject treasure = (GameObject)Instantiate(treasures[0], gameObject.transform.parent.transform, false); // spawn first enemy in our list
                    treasure.transform.localPosition = new Vector3(transform.localPosition.x, -4.43f, 1);
                    treasure.GetComponent<BasicObstacleSpeedS>().speed = speed;
                    treasure.GetComponent<BasicObstacleSpeedS>().guideObj = null;
                    treasure.GetComponent<BasicObstacleSpeedS>().layer = Random.Range(1,4);
                    treasure.GetComponent<BasicObstacleSpeedS>().hasGuideObj = 2;
                }

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

        if (waveTimer <= 0 && !generating)
        {
            if (currWave < 5)
            {
                currWave++;
            }
            spawnedEnemies.Clear();
            GenerateWave();

        }
    }

    public void GenerateWave()
    {
        generating = true;
        waveValue = (1 + (currWave - 1) / 5) * 70;
        GenerateEnemies();

        if (enemiesToSpawn.Count != 0)
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

        List<int> generatedEnemies = new List<int>();
        while (waveValue > 0 || generatedEnemies.Count < 50)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(randEnemyId);
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

    IEnumerator spawnGroup(EnemyS es, int times, int layer) 
    {
        if(times > 0)
        {
            yield return new WaitForSeconds(Random.Range(3, 7) / 10.0f);
            GameObject enemy = (GameObject)Instantiate(es.enemyPrefab, gameObject.transform.parent.transform, false); // spawn first enemy in our list
            enemy.transform.localPosition = new Vector3(transform.localPosition.x, Random.Range(es.spawnYMin * 10, es.spawnYMax * 10) / 10.0f, -1 + 0.1f*times);
            enemy.GetComponent<BasicObstacleSpeedS>().speed = speed;
            enemy.GetComponent<BasicObstacleSpeedS>().guideObj = null;
            enemy.GetComponent<BasicObstacleSpeedS>().layer = layer;
            enemy.GetComponent<BasicObstacleSpeedS>().hasGuideObj = 2;
            spawnedEnemies.Add(enemy);

            StartCoroutine(spawnGroup(es, times - 1, layer));        
        }
        else
        {
            enemiesToSpawn.RemoveAt(0); // and remove it

        }


    }
}

[System.Serializable]
public class EnemyS
{
    public GameObject enemyPrefab;
    public int cost;
    public float spawnYMin;
    public float spawnYMax;
    public float speed;
    public int instancesMin;
    public int instancesMax;
}


