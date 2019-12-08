using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElectricRay : MonoBehaviour
{
    GameObject player;
    float dist;

    public float speed; //each species has a different speed
    float xTilt;
    float yTilt;
    float zTilt = 1;
    public float height;
    float xPoint;
    float zPoint;
    public Vector3 newLocation;
    bool stop = false;
    bool collided = false;
    //Alex Murray
    void Start()
    {
        player = GameObject.Find("SpawnCenter");

        xPoint = Random.Range(player.transform.position.x - 20, player.transform.position.x + 20);
        zPoint = Random.Range(player.transform.position.z - 20, player.transform.position.z + 20);
        newLocation = new Vector3(xPoint, height, zPoint);
    }

    void Update()
    {
        dist = Vector3.Distance(player.transform.position, this.transform.position);
        
        //moving to random points until almost there or collided with object
        if (collided == true || Vector3.Distance(transform.position, newLocation) < 1)
        {
            xPoint = Random.Range(player.transform.position.x - 20, player.transform.position.x + 20);
            zPoint = Random.Range(player.transform.position.z - 20, player.transform.position.z + 20);
            newLocation = new Vector3(xPoint, height, zPoint);
            collided = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, newLocation, speed);

        //flipping depending on if going to players right or left
        if (Vector3.SignedAngle(player.transform.position, transform.position - newLocation, Vector3.up) < 0)
        { GetComponent<SpriteRenderer>().flipX = true; }
        else
        { GetComponent<SpriteRenderer>().flipX = false; }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Terrain")
        {
            collided = true;
        }
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}

