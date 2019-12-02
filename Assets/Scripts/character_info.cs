using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_info : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        snail_info MainChar = gameObject.AddComponent<snail_info>();
        MainChar.Name = "Player";
        MainChar.Health = 100;
        MainChar.Armor = 100;
        MainChar.Damage = 10;
        snail_info ArrowCrab = gameObject.AddComponent < snail_info>();
        ArrowCrab.Name = "arrow crab";
        ArrowCrab.Health = 10;
        ArrowCrab.Armor = 10;
        ArrowCrab.Damage = 0;
        snail_info Batfish = gameObject.AddComponent<snail_info>();
        Batfish.Name = "batfish";
        Batfish.Health = 10;
        Batfish.Armor = 10;
        Batfish.Damage = 0;
        snail_info CowrieSnail = gameObject.AddComponent<snail_info>();
        CowrieSnail.Name = "Cowrie Snail";
        CowrieSnail.Health = 10;
        CowrieSnail.Armor = 10;
        CowrieSnail.Damage = 0;
        snail_info HarpSnail = gameObject.AddComponent<snail_info>();
        HarpSnail.Name = "Harp Snail";
        HarpSnail.Health = 10;
        HarpSnail.Armor = 10;
        HarpSnail.Damage = 0;
        snail_info MoonSnail = gameObject.AddComponent<snail_info>();
        MoonSnail.Name = "Moon Snail";
        MoonSnail.Health = 10;
        MoonSnail.Armor = 10;
        MoonSnail.Damage = 0;
        snail_info RazorFish = gameObject.AddComponent<snail_info>();
        RazorFish.Name = "Razor Fish";
        RazorFish.Health = 10;
        RazorFish.Armor = 10;
        RazorFish.Damage = 1000;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
