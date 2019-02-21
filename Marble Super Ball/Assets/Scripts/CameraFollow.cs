using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    enum MotionStatus {
        Idle = 0,
        TurnRight = 1,
        TurnLeft = 2,
        Forward = 3,
        Backward = 6,
    }

    private float tiltTime = 0.5f;
    private float turnTime = 0.5f;

    public int idleAngle = 0;
    public int tiltAngle = 25;
    public int turnAngle = 15;
    public float TiltTime {
        get {
            return tiltTime;
        }
        set {
            tiltTime = value;
            tiltSpeed = tiltAngle / tiltTime;
        }
    }
    public float TurnTime
    {
        get
        {
            return turnTime;
        }
        set
        {
            turnTime = value;
            turnSpeed = turnAngle / turnTime;
        }
    }
    public float turnDeadzone;

    MotionStatus currentMotion;
    Vector3 currentRotation;
    Vector3 targetRotation;
    Vector3 motionRotation;
    float tiltSpeed;
    float turnSpeed;
    float turnOverflow;
    float tiltOverflow;

    // Boolean Properties for clarity.
    bool movingIdle     { get { return currentMotion < MotionStatus.Forward; } }
    bool movingForward  { get { return currentMotion < MotionStatus.Backward; } }
    bool movingBackward { get { return !(currentMotion < MotionStatus.Backward); } }
    bool turningRight   { get { return currentMotion == (MotionStatus)1 || currentMotion == (MotionStatus)4 || currentMotion == (MotionStatus)7; } }
    bool turningLeft    { get { return currentMotion == (MotionStatus)2 || currentMotion == (MotionStatus)5 || currentMotion == (MotionStatus)8; } }

    // Use this for initialization
    void Start () {
        currentMotion = MotionStatus.Idle;
        currentRotation = Vector3.zero;
        targetRotation = Vector3.zero;
        motionRotation = Vector3.zero;

        TiltTime = tiltTime;
        TurnTime = turnTime;
        turnOverflow = 0;
        tiltOverflow = 0;
	}
	
	// Update is called once per frame
	void Update () {
        // If moving backwards, speed up the turn time. Otherwise, set to standard
        TurnTime =
            currentMotion == MotionStatus.Backward ?
                0.25f
            :
                0.5f
        ;

        // Get current camera rotation and reset the target rotation's value.
        currentRotation = gameObject.transform.localRotation.eulerAngles;
        currentRotation.x -=
            currentRotation.x > 180 ?
                360
            :
                0
        ;
        currentRotation.y -=
            currentRotation.y > 180 ?
                360
            :
                0
        ;

        // Detect motion type
        currentMotion =
            Input.GetKey(KeyCode.W) ?
                MotionStatus.Forward
            :
                Input.GetKey(KeyCode.S) ?
                    MotionStatus.Backward
                :
                    MotionStatus.Idle
        ;
        currentMotion =
            Input.GetKey(KeyCode.A) ?
                currentMotion + 2
            :
                Input.GetKey(KeyCode.D) ?
                    currentMotion + 1
                :
                    currentMotion
        ;

        // Set target rotation
        targetRotation.x =
            movingIdle ?
                idleAngle
            :
                tiltAngle
        ;
        targetRotation.y =
            turningLeft ?
                turnAngle * -1
            :
                turningRight ?
                    turnAngle
                :
                    0
        ;
        // Turn 180 degrees if moving backwards
        targetRotation.y +=
            movingBackward ?
                180
            :
                0
        ;
        targetRotation.y -=
            targetRotation.y > 180 ?
                360
            :
                0
        ;

        // Calculate the rotation we want to apply to the camera.
        motionRotation.x =
            targetRotation.x > currentRotation.x?
                tiltSpeed * Time.deltaTime
            :
                targetRotation.x < currentRotation.x ?
                    tiltSpeed * Time.deltaTime * -1
                :
                    0
        ;
        motionRotation.y =
            targetRotation.y > currentRotation.y ?
                turnSpeed * Time.deltaTime
            :
                targetRotation.y < currentRotation.y ?
                    turnSpeed * Time.deltaTime * -1
                :
                    0
        ;
        motionRotation.z = -gameObject.transform.eulerAngles.z;

        // Prevent motionRotation from rotating beyond the desired tilt and turn angles.
        motionRotation.x =
            motionRotation.x > 0 && currentRotation.x + motionRotation.x > targetRotation.x ?
                Mathf.Abs(targetRotation.x - currentRotation.x)
            :
                motionRotation.x < 0 && currentRotation.x + motionRotation.x < targetRotation.x ?
                    Mathf.Abs(targetRotation.x - currentRotation.x) * -1
                :
                    motionRotation.x
        ;
        motionRotation.y =
            motionRotation.y > 0 && currentRotation.y + motionRotation.y > targetRotation.y ?
                Mathf.Abs(targetRotation.y - currentRotation.y)
            :
                motionRotation.y < 0 && currentRotation.y + motionRotation.y < targetRotation.y ?
                    Mathf.Abs(targetRotation.y - currentRotation.y) * -1
                :
                    motionRotation.y
        ;

        // Apply motionRotation to camera
        gameObject.transform.Rotate(motionRotation);
        string debugString = string.Format("MoveStatus: {0} - CurrentTurn {1} - TargetTurn: {2}",
            currentMotion, currentRotation.y, targetRotation.y);
        Debug.Log(debugString);
    }
}
