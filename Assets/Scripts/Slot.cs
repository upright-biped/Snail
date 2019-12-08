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
<<<<<<< HEAD
        Icon = GameObject.Find(this.name+"/icon").GetComponent<Image>();
        Count = GameObject.Find(this.name + "/count").GetComponent<Text>();
        Name = GameObject.Find(this.name + "/Text").GetComponent<Text>();
=======
        Icon = GameObject.Find(this.name+"/icon");
        Count = GameObject.Find(this.name + "/count");
        Name = GameObject.Find(this.name + "/Text");


        //when moused over, show text
        //when left clicked, release

        //when right clicked, delete
>>>>>>> ba747fa7a8d0112468da3d5e23680b989c96c2bc
    }
    public void Caught()
    {
        //revert image colors
<<<<<<< HEAD
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
=======
        if (Icon.GetComponent<Image>().color == Color.blue)
        {
            GameObject.Find("Score").GetComponent<Score>().AddSpecies();
        }
        Icon.GetComponent<Image>().color = Color.white;
>>>>>>> 3135284dbf841277c93ac3ebb14afc667fa44169

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
