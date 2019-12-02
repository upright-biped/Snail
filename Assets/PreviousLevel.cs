using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PreviousLevel : MonoBehaviour
{
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
}
