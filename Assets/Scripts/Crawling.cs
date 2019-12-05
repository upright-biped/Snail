using UnityEngine;
public class Crawling : MonoBehaviour
{
    GameObject player;
    Spawning spawnScript;
    float dist;
    GameObject score;

    public float speed; //each species has a different speed
    float xTilt;
    float yTilt;
    float zTilt = 1;
    float height;
    float xPoint;
    float zPoint;
    public Vector3 newLocation;
    bool stop = false;
    bool collided = false;
//Alex Murray
    void Start()
    {
        score = GameObject.Find("Text");

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

        //moving to random points until almost there or collided with object
        if (collided == true || Vector3.Distance(transform.position, newLocation) < 1)
        {
            xPoint = Random.Range(player.transform.position.x - 20, player.transform.position.x + 20);
            zPoint = Random.Range(player.transform.position.z - 20, player.transform.position.z + 20);
            newLocation = new Vector3(xPoint, height, zPoint);
            collided = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, newLocation, speed);
        //tilting to look like crawling, and facing player
        if (transform.localEulerAngles.z > 10 || transform.localEulerAngles.z < -30)
        { zTilt *= (-1); }
        xTilt = GameObject.Find("SpawnCenter").transform.eulerAngles.x - transform.eulerAngles.x;
        yTilt = GameObject.Find("SpawnCenter").transform.eulerAngles.y - transform.eulerAngles.y;
        transform.Rotate(xTilt, yTilt, zTilt, Space.Self);

        //flipping depending on if going to players right or left
        if (Vector3.SignedAngle(player.transform.position, transform.position - newLocation, Vector3.up) < 0)
        { GetComponent<SpriteRenderer>().flipX = true; }
        else
        { GetComponent<SpriteRenderer>().flipX = false; }

    }
    void OnMouseDown()
    {
        if (dist < 4)
        {
            //add to inventory
            spawnScript.count--;
            score.GetComponent<Score>().AddScore();
            Destroy(gameObject);
            Destroy(this);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag!= "Terrain")
        {
            collided = true;
        }
    }
}

