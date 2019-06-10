/* Spawner.cs
 * Gameobject:      Game Manager
 * Brief:           This script controls spawning of our collectibles
 * Author:          Drew Massey
 * Date Created:    05/19/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject collectible_template;
    public List<GameObject> spawn_list;

    private Vector2 spawnBoundary = new Vector2(7, 4);
    private float spawnHeight = 1;
    private float spawnTimer = 0.0f;
    private float spawnThreshold = 5.0f;

    public int SpawnCount
    {
        get { return spawn_list.Count; }   
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Start our timer
        spawnTimer += Time.deltaTime;

        //Once our timer reaches the threshold, spawn
        if(spawnTimer > spawnThreshold)
        {
            Spawn(collectible_template);
            spawnTimer = 0.0f;
        }
    }

    //Spawns an object at a location
    private void Spawn(GameObject obj)
    {
        spawn_list.Add(Instantiate(obj, GenerateRandomPosition(spawnBoundary, spawnHeight), collectible_template.transform.rotation));
    }

    /// <summary>
    /// Decreaes the spawn threshold by an amount.  
    /// spawnThreshold * amt
    /// </summary>
    /// <param name="amt"></param>
    private void DecreaseThreshold(float amt)
    {
        spawnThreshold = spawnThreshold * amt;
    }

    //Generates a random value between a max and min
    private float GenerateRandom(float max, float min)
    {
        float ret = Random.Range(min, max);

        return ret;
    }

    //Generates a random position with a set of bounds and a height
    private Vector3 GenerateRandomPosition(Vector2 bounds, float height)
    {
        Vector3 retPos = new Vector3();
        retPos.x = GenerateRandom(-bounds.x, bounds.x);
        retPos.y = spawnHeight;
        retPos.z = GenerateRandom(-bounds.y, bounds.y);

        return retPos;
    }
}
