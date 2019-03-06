using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nudge : MonoBehaviour {

    public Vector2 startPos;
    public Vector2 direction;
    public bool directionChosen;

    public bool swipe = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Simulate touch using mouse-click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            //On hit
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject == gameObject)
                {
                    hit.rigidbody.AddForceAtPosition((hit.rigidbody.position - hit.point) * 200, hit.point);
                }
            }
        }

        

        if (Input.touchCount > 0 && swipe)
        {
            

            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }
        if (directionChosen)
        {
            Vector2 norm = direction.normalized;
            float horizontal = direction.x;
            float vertical = norm.y;
            Vector3 nforce = new Vector3(norm.x, 0.0f, 0.0f);
            GetComponent<Rigidbody>().AddForceAtPosition(nforce * 100,GetComponent<Rigidbody>().position);
            directionChosen = false;
        }
    }
}
