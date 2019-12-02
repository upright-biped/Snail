using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Crawling : MonoBehaviour
{
    GameObject player;
    Spawning spawnScript;
    Inventory inventory;
    float dist;


    public float speed; //each species has a different speed
    float step;
    float tilt = 1;
    float height;
    float xPoint;
    float zPoint;
    Vector3 curLocation;
    Vector3 newLocation;
    bool stop = false;


    void Start()
    {
        player = GameObject.Find("SpawnCenter");
        spawnScript = player.GetComponent<Spawning>();
        inventory = player.GetComponent<Inventory>();
        height = GetComponent<SphereCollider>().radius;

        curLocation = transform.position;
        xPoint = Random.Range(curLocation.x - 20, curLocation.x + 20);
        zPoint = Random.Range(curLocation.z - 20, curLocation.z + 20);
        newLocation = new Vector3(xPoint, height, zPoint);
    }

    void Update()
    {
        //Always facing camera
        transform.LookAt(GameObject.Find("SpawnCenter").transform.position);
        curLocation = transform.position;
//sprite flipping
        //Despawn when camera out of range or when clicked, decrease count in spawning script
        dist = Vector3.Distance(player.transform.position, this.transform.position);
        //clicking??
        if (dist > 20)
        {
            spawnScript.count--;
            Destroy(gameObject);
            Destroy(this);
        }
        //moving to random points
        if (curLocation==newLocation)
        {
            xPoint = Random.Range(curLocation.x - 20, curLocation.x + 20);
            zPoint = Random.Range(curLocation.z - 20, curLocation.z + 20);
            newLocation = new Vector3(xPoint, height, zPoint);
            step = speed*Time.deltaTime; // calculate distance to move
        }
        transform.position = Vector3.MoveTowards(transform.position, newLocation, step);
        //tilting
        if (transform.localEulerAngles.z>20 || transform.localEulerAngles.z < -20)
        { tilt *= (-1); }
        transform.Rotate(0, 0, (1*tilt), Space.Self);

        //maintaining distance from camera
        //distance from landmarks or other creatures

    }
    void OnMouseDown()
    {
        if (dist < 4)
        {
//add to inventory

            spawnScript.count--;
            Destroy(gameObject);
            Destroy(this);
        }
    }

}

