using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private Canvas CanvasObject;
    private bool isPaused = false;
    void Start()
    {
        CanvasObject = GameObject.Find("Canvas").GetComponent<Canvas>();
        CanvasObject.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            ToggleCanvas();
        }
        if (isPaused)
            Time.timeScale = 0f;

        else
            Time.timeScale = 1.0f;
    }

    public void ToggleCanvas()
    {
        if (CanvasObject.enabled == true)
        {
            CanvasObject.GetComponent<Canvas>().enabled = false;
        }
        else
        {
            CanvasObject.GetComponent<Canvas>().enabled = true;
        }
    }
}