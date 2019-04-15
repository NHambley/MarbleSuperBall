using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    // set this in the editor on a level basis
    public string lvlName;
    public GameObject player;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == player)
        {
            ChangeLevel();
        }
    }

    private void ChangeLevel()
    {
        SceneManager.LoadScene(lvlName);
    }
}
