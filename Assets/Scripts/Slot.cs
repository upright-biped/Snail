using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    GameObject Icon;
    GameObject Count;
    GameObject Name;

    void Start()
    {
        Icon = GameObject.Find(this.name+"/icon");
        Count = GameObject.Find(this.name + "/count");
        Name = GameObject.Find(this.name + "/Text");


        //when moused over, show text
        //when left clicked, release

        //when right clicked, delete
    }

    public void Caught()
    {
        //revert image colors
        Icon.GetComponent<Image>().color = Color.white;

        //Count.GetComponent<Text>().text = int.Parse(Count.GetComponent<Text>().text);
    }
}
