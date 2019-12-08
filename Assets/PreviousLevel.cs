using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PreviousLevel : MonoBehaviour
{
    private Canvas CanvasObject;

    public void Start()
    {
        CanvasObject = GameObject.Find("TUTORIALS").GetComponent<Canvas>();
        CanvasObject.GetComponent<Canvas>().enabled = false;
    }
    // Start is called before the first frame update
    public void WaterPlay()
    {
        // SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
        SceneManager.LoadScene("Underwater");
    }
    public void QuitPlay()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void Tutorials()
    {
        if (CanvasObject.enabled == true)
        {
            CanvasObject.GetComponent<Canvas>().enabled = false;
            //MainMenuCanvas.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            CanvasObject.GetComponent<Canvas>().enabled = true;
            //MainMenuCanvas.GetComponent<Canvas>().enabled = false;
        }
    }
}
