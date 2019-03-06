using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPos;

    public bool colliding = true;
    public float sepTimer = 3.0f;

	
	void Update ()
    {
       if(colliding == false)
       {
            sepTimer -= Time.deltaTime;

            if(sepTimer <= 0 && SystemInfo.supportsGyroscope == false)
            {
                sepTimer = 3.0f;

                // reset the map rotation
                GameObject.FindGameObjectWithTag("Map").transform.rotation = Quaternion.Euler(0, 0, 0);

                // do respawn things
                transform.position = respawnPos.position;

                //GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
            else if(sepTimer <= 0 && SystemInfo.supportsGyroscope == true)
            {
                transform.position = respawnPos.position;
            }
       }
    }

    private void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        colliding = true;
        sepTimer = 3.0f;
    }
}
