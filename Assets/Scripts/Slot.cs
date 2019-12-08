using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject spawnObject;
    Vector3 Location;
    Image Icon;
    Text Name;
    Text Count;
    int countInt;
//Alex Murray
    void Start()
    {
        Icon = GameObject.Find(this.name+"/icon").GetComponent<Image>();
        Count = GameObject.Find(this.name + "/count").GetComponent<Text>();
        Name = GameObject.Find(this.name + "/Text").GetComponent<Text>();
    }
    public void Caught()
    {
        //revert image colors
        if (Icon.color == Color.blue)
        {
            GameObject.Find("Score").GetComponent<Score>().AddSpecies();
            Icon.color = Color.white;
        }
        countInt++;
        Count.text = countInt.ToString();
    }
    void OnMouseDown()
    {
        //when left clicked, release
        if (Input.GetMouseButtonDown(0) && countInt > 0)
        {
            Location = GameObject.Find("SpawnCenter").transform.position;
            Location.x++;
            Instantiate(spawnObject, Location, gameObject.transform.rotation);
            countInt--;
            Count.text = countInt.ToString();
        }

        //when right clicked, delete
        if (Input.GetMouseButtonDown(1) && countInt>0)
        {
            countInt--;
            Count.text = countInt.ToString();
        }
    }
    void OnMouseOver()
    {
        Name.enabled = true;
    }
    void OnMouseExit()
    {
        Name.enabled = false;
    }
}
