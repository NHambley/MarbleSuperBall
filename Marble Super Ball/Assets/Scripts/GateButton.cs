using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateButton : MonoBehaviour
{
    Renderer rend;
    public Material[] material;
    [HideInInspector]
    public bool activated;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Set to active, lower button to appear flattened.
            transform.position.Set(transform.position.x, transform.position.y - 0.1f, transform.position.z);
            activated = true;
        }
    }

   
}
