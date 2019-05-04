using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateControl : MonoBehaviour
{
    //On and Off Materials
    public Material[] material;
    //Gate Lights
    public GameObject[] Lights;
    //Gate Buttons
    public GameObject[] Buttons;

    //Active Buttons Tracker
    public bool[] ActiveButtons;
    //Active Lights (Not tied to specific Buttons)
    int activeLights;
    Renderer rend;
    //Gate Door and desired end position
    public GameObject Door;
    private float doorEndPosition;


    // Start is called before the first frame update
    void Start()
    {
        activeLights = 0;
        doorEndPosition = Door.transform.position.y - 8;

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            //If Button was inactive, check.
            if (ActiveButtons[i] == false)
            {
                if (Buttons[i].GetComponent<GateButton>().activated == true)
                {
                    //Light up Button
                    rend = Buttons[i].GetComponent<Renderer>();
                    rend.enabled = true;
                    rend.sharedMaterial = material[1];
                    //set Button to active in ActiveButtons
                    ActiveButtons[i] = true;
                    //Set next light to active;
                    activeLights++;
                    //Light up next Light
                    rend = Lights[activeLights - 1].GetComponent<Renderer>();
                    rend.enabled = true;
                    rend.sharedMaterial = material[1];
                }
            }
        }
        //If all lights active, and door exists(Not fully opened), Open door
        if(activeLights == Lights.Length)
        {
            if (Door)
            {
                Open();
            }
        }

    }

    void Open()
    {
        //While Door is above end position
        if(Door.transform.position.y > doorEndPosition)
        {
            Door.transform.Translate(-transform.up * Time.deltaTime);
        }
    }
}
