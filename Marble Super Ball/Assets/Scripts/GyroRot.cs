using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroRot : MonoBehaviour {
    

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation *= Quaternion.Euler(Input.acceleration.y / 6, -Input.acceleration.x / 3, 0);
	}
}
