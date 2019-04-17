using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuObjects : MonoBehaviour
{
    public Transform respawnPos;
    float timer = 2.0f;
    bool colliding = false;


    // Update is called once per frame
    void Update()
    {
        if(colliding == false)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                timer = 2.0f;
                // do respawn things
                transform.position = respawnPos.position;

                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
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
        timer = 2.0f;
    }
}
