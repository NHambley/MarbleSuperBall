using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("player");
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Touched");
        if (collision.gameObject == player)
        {
            Debug.Log("Touched Player");
            Launch(collision.gameObject);
        }
    }

    private void Launch(GameObject obj)
    {

        Vector3 direction = transform.position - player.transform.position;
        Vector3 force = direction * 2000 * obj.GetComponent<Rigidbody>().mass;
        obj.GetComponent<Rigidbody>().AddForce(force);
        Debug.Log("Launched");
        Debug.Log(force);

    }
}
