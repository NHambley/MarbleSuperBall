using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject endpoint;
    Vector3 ePos;
    Vector3 pPos;

    float rotSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        endpoint = GameObject.FindGameObjectWithTag("EndPoint");
        pPos = transform.position;
        ePos = endpoint.transform.position;// this doesn't need changed once it's established
    }

    // Update is called once per frame
    void Update()
    {
        pPos = player.transform.position;
        Vector3 dir = ePos - pPos;
        dir = player.transform.InverseTransformDirection(dir);
        float angleBetween = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotSpeed * angleBetween);
    }
}
