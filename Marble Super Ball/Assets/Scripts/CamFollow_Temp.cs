using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow_Temp : MonoBehaviour
{
    public GameObject ball;

    Vector3 distance;
    private void Start()
    {
        distance = transform.position - ball.transform.position;
    }
    // Update is called once per frame
    void Update ()
    {
        transform.position = ball.transform.position + distance;
    }
}
