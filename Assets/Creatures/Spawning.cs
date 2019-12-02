using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public int count;
    public GameObject[] species;
    public int lastSea;
    Vector3 playerLocation;
    int randCreature;
    bool stop = false;

    public float height;
    public float xPoint;
    public float yPoint;
    public float zPoint;
    void Start()
    {
        StartCoroutine(WaitSpawner());
    }

    void Update()
    {
        //location of player
        playerLocation = GameObject.Find("SpawnCenter").transform.position;
    }

    IEnumerator WaitSpawner()
    {
        while (!stop)
        {
            //choose creature to spawn
            if (GameObject.Find("Sea Floor")==true)
            {
                randCreature = Random.Range(0, lastSea);
            }
            else
            {
                randCreature = Random.Range(lastSea, species.Length);
            }

            //get radius of that species
            height = species[randCreature].GetComponent<SphereCollider>().radius;
            //choose random cooridnates
            xPoint = Random.Range(playerLocation.x - 20, playerLocation.x + 20);
            zPoint = Random.Range(playerLocation.z - 20, playerLocation.z + 20);
            yPoint = height+1;
            Vector3 spawnPosition = new Vector3(xPoint, yPoint, zPoint);

            Instantiate(species[randCreature], spawnPosition, gameObject.transform.rotation);

            count++;
            yield return new WaitForSeconds(5);
            //pauses script if 12 or more creatures are instantiated
            while(count>12)
            {
                yield return new WaitForSeconds(1);
            }
        }

    }

}
