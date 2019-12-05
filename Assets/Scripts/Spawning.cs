using System.Collections;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public int count;
    public GameObject[] species;
    Vector3 playerLocation;
    int randCreature;
    bool stop = false;

    float height;
    float xPoint;
    float yPoint;
    float zPoint;
    Vector3 spawnPosition;
//Alex Murray
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
            randCreature = Random.Range(0, species.Length);
            

            //get radius of that species
            height = species[randCreature].GetComponent<SphereCollider>().radius;
            //choose random cooridnates
            xPoint = Random.Range(playerLocation.x - 20, playerLocation.x + 20);
            zPoint = Random.Range(playerLocation.z - 20, playerLocation.z + 20);
            yPoint = height;
            spawnPosition = new Vector3(xPoint, yPoint, zPoint);

            Instantiate(species[randCreature], spawnPosition, gameObject.transform.rotation);

            count++;
            yield return new WaitForSeconds(5);
            //pauses script if 12 or more creatures are instantiated, including released creatures
            while(count>11)
            {
                yield return new WaitForSeconds(1);
            }
        }

    }

}
