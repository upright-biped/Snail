using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    private Canvas CanvasObject;
    private Canvas MainMenuCanvas;
    private bool isPaused = false;
    // Use this for initialization
    void Start()
    {
        CanvasObject = GameObject.Find("TUTORIALS").GetComponent<Canvas>();
        CanvasObject.GetComponent<Canvas>().enabled = false;
        MainMenuCanvas = GameObject.Find("MainMenuCanvas").GetComponent<Canvas>();
        MainMenuCanvas.GetComponent<Canvas>().enabled = true;
        //myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Scenes");
        //scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Tutorials();
        }
        if (isPaused)
            Time.timeScale = 0f;

        else
            Time.timeScale = 1.0f;
    }
    public void PlayGame()
    {
       // SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
        SceneManager.LoadScene("Underwater");
    }
    public void Tutorials()
    {
        if (CanvasObject.enabled == true)
        {
            CanvasObject.GetComponent<Canvas>().enabled = false;
            MainMenuCanvas.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            CanvasObject.GetComponent<Canvas>().enabled = true;
            MainMenuCanvas.GetComponent<Canvas>().enabled = false;
        }
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
