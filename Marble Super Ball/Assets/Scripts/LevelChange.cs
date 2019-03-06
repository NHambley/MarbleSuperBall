using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour {

    public GameObject player;
    public string scene;
	// Use this for initialization
	void Start () {
        Debug.Log("hi");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == player)
        {
            ChangeLevel();
        }
        Debug.Log(collision);
        Debug.Log(player);
    }

    private void ChangeLevel()
    {
        SceneManager.LoadScene(scene);
    }
}
