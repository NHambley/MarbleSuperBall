using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow_Temp : MonoBehaviour
{
    public GameObject ball;

	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(ball.transform);
	}
}
