using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool inWindZone = false;
    public GameObject windZone;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (inWindZone)
        {
            rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "windArea")
        {
            windZone = coll.gameObject;
            inWindZone = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if(coll.gameObject.tag == "windArea")
        {
            inWindZone = false;
        }
    }
}
