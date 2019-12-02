using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming : MonoBehaviour
{
    public int speed;
    GameObject player;
    Spawning spawnScript;
    Inventory inventory;
    float dist;
    Ray ray;
    RaycastHit hit;

    void Start()
    {
        player = GameObject.Find("SpawnCenter");
        spawnScript = player.GetComponent<Spawning>();
        inventory = player.GetComponent<Inventory>();
    }

    void Update()
    {
        //Always facing camera
        gameObject.transform.LookAt(GameObject.Find("SpawnCenter").transform.position);
        //Despawn when camera out of range or when clicked, decrease count in spawning script
        dist = Vector3.Distance(player.transform.position, this.transform.position);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (dist < 4 && Physics.Raycast(ray, out hit) && hit.collider.tag == "Creatures")
        {
//add to inventory

            spawnScript.count--;
            Destroy(gameObject);
            Destroy(this);
        }

        if (dist > 20)
        {
            spawnScript.count--;
            Destroy(gameObject);
            Destroy(this);
        }


    }
}
