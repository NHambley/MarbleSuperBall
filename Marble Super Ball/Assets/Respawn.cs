using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPos;

	// Check the ball's y value, if it is below -20, "respawn" the ball
	void Update ()
    {
        if (transform.position.y <= -20f)
        {
            // reset the ball position and set forces to 0
            transform.position = respawnPos.position;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;


            // reset the map rotation
            GameObject.FindGameObjectWithTag("Map").transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
