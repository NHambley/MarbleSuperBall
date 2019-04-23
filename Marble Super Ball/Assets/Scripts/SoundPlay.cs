using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    AudioSource sound;
    float angV;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        angV = GetComponent<Rigidbody>().angularVelocity.magnitude;
        if (angV > 2.0f)
            sound.Play();
        else
            sound.Stop();
    }
}
