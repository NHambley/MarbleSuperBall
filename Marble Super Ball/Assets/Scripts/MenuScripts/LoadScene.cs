using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    
    public void LoadByString(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
