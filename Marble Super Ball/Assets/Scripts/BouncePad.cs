using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour {
    public GameObject player;
    bool airborn = false;
    Respawn resScript;
    AudioSource sound;
	// Use this for initialization
	void Start ()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        resScript = player.GetComponent<Respawn>();
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == player)
        {
            Launch(collision.gameObject);
        }
    }

    private void Launch(GameObject obj)
    {

        Vector3 direction = transform.position - player.transform.position;
        Vector3 force = direction * 250 * obj.GetComponent<Rigidbody>().mass;
        force.y += 500;
        obj.GetComponent<Rigidbody>().AddForce(force);

        resScript.sepTimer += 3;
        sound.Play();
    }
}
