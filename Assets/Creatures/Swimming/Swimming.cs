using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming : MonoBehaviour
{
    GameObject player;
    Spawning spawnScript;
    float dist;


    public float speed; //each species has a different speed
    float xTilt;
    float yTilt;
    float zTilt = 1;
    float height;
    float xPoint;
    float yPoint;
    float zPoint;
    public Vector3 newLocation;
    bool stop = false;
    bool collided = false;

    void Start()
    {
        player = GameObject.Find("SpawnCenter");
        spawnScript = player.GetComponent<Spawning>();
        height = GetComponent<SphereCollider>().radius;

        xPoint = Random.Range(player.transform.position.x - 20, player.transform.position.x + 20);
        zPoint = Random.Range(player.transform.position.z - 20, player.transform.position.z + 20);
        newLocation = new Vector3(xPoint, height, zPoint);
    }

    void Update()
    {
        //despawn when out of range
        dist = Vector3.Distance(player.transform.position, this.transform.position);
        if (dist > 20)
        {
            spawnScript.count--;
            Destroy(gameObject);
            Destroy(this);
        }

        //moving to random points
        if (collided == true || Vector3.Distance(transform.position, newLocation) < 1)
        {
            xPoint = Random.Range(player.transform.position.x - 20, player.transform.position.x + 20);
            yPoint = Random.Range(height, 5);
            zPoint = Random.Range(player.transform.position.z - 20, player.transform.position.z + 20);
            newLocation = new Vector3(xPoint, yPoint, zPoint);
            collided = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, newLocation, speed);
        //tilting to look like crawling, and facing player
        xTilt = GameObject.Find("SpawnCenter").transform.eulerAngles.x - transform.eulerAngles.x;
        yTilt = GameObject.Find("SpawnCenter").transform.eulerAngles.y - transform.eulerAngles.y;
        zTilt = GameObject.Find("SpawnCenter").transform.eulerAngles.z - transform.eulerAngles.z;
        transform.Rotate(xTilt, yTilt, zTilt, Space.Self);

        //flipping depending on if going to players right or left
        if (Vector3.SignedAngle(player.transform.position, transform.position - newLocation, Vector3.up) < 0)
        { GetComponent<SpriteRenderer>().flipX = false; }
        else
        { GetComponent<SpriteRenderer>().flipX = true; }

    }
    void OnMouseDown()
    {
        if (dist < 4)
        {
            //add to inventory and score

            spawnScript.count--;
            Destroy(gameObject);
            Destroy(this);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "terrain")
        {
            collided = true;
        }
    }
}
