using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroRot : MonoBehaviour {

    private Vector3 deadZone = Vector3.zero;
    private Matrix4x4 calibrateMat;

    // used for calculating the quaternion difference between the gyroscope and zero upon game start
    float xDif;
    float zDif;

    Quaternion q;
    Quaternion d;
    bool isGyro;
    bool setGyro;
    int delay;
	// Use this for initialization
	void Start ()
    {
        // if a gyroscope is detected establish a "zero" aka a difference between 
        if(SystemInfo.supportsGyroscope == true)
        {
            isGyro = true;
            Input.gyro.enabled = true;
            setGyro = false;
            delay = 0;
        }
        else
            CalibrateAccel();

    }

    // Update is called once per frame
    void Update ()
    {
        if (isGyro)
        {
            if(setGyro == false)
            {
                if (delay == 1)
                {
                    d = Input.gyro.attitude;
                    setGyro = true;
                }
                else
                {
                    delay++;
                }
            }
            else
            {
                q = Input.gyro.attitude;
                transform.rotation = new Quaternion(q.x,q.z,q.y,-q.w);
            }
        }
        else
        {
            Vector3 accel = calibrateMat.MultiplyVector(Input.acceleration);
            transform.rotation *= Quaternion.Euler(accel.y, -accel.x, 0);
        }
	}

    void SetGyroZero()
    {
        d = Input.gyro.attitude;
    }

    // set deadzone
    void CalibrateAccel()
    {
        deadZone = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0f, 0f, -1f), deadZone);
        Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotateQuaternion, new Vector3(1f, 1f, 1f));
        calibrateMat = matrix.inverse;
    }

    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 20;

        GUILayout.Label("Orientation: " + Screen.orientation);
        GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude);
        GUILayout.Label("Current Rotation: " + q);
        GUILayout.Label("Dead Zone: " + d);
        GUILayout.Label("Set: " + setGyro);
    }
}
