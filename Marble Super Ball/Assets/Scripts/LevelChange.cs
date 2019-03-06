using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    // set this in the editor on a level basis
    public string lvlName;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Sphere")
        {
            ChangeLevel();
        }
        ChangeLevel();
    }

    private void ChangeLevel()
    {
        SceneManager.LoadScene(lvlName);
    }
}
