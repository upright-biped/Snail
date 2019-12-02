using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForestLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void ForestPlay()
    {
        // SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
        SceneManager.LoadScene("Forest");
    }
}
