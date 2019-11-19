using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_info : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        snail_info MainChar = gameObject.AddComponent<snail_info>();
        MainChar.Name = "Player 1";
        MainChar.Health = 100;
        MainChar.Armor = 100;
        MainChar.Damage = 10;
        snail_info SnailChar = gameObject.AddComponent < snail_info>();
        SnailChar.Name = "Snail 1";
        SnailChar.Health = 10;
        SnailChar.Armor = 10;
        SnailChar.Damage = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
