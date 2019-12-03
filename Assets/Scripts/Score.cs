using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    private Text thisText;
    private int score;

    void Start()
    {
        thisText = GetComponent<Text>();

        // set score value to be zero
        score = 0;
    }

    void Update()
    {
        // When P is hit
        if (Input.GetKeyDown(KeyCode.P))
        {
            // add 500 points to score
            score += 500;
        }
        // update text of Text element
        thisText.text = "SCORE: " + score;
    }
}
