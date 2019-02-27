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
    bool isGyro;
	// Use this for initialization
	void Start ()
    {
        // if a gyroscope is detected establish a "zero" aka a difference between 
        if(SystemInfo.supportsGyroscope == true)
        {
            isGyro = true;
            Input.gyro.enabled = true;
            transform.rotation = Input.gyro.attitude;
            SetGyroZero();
        }
        else
            CalibrateAccel();

    }

    // Update is called once per frame
    void Update ()
    {
        if (isGyro)
        {
            transform.rotation = new Quaternion(q.x- xDif, q.z - zDif, q.y, -q.w);
        }
        else
        {
            Vector3 accel = calibrateMat.MultiplyVector(Input.acceleration);
            transform.rotation *= Quaternion.Euler(accel.y, -accel.x, 0);
        }
       
	}

    void SetGyroZero()
    {
        q = Input.gyro.attitude;
        xDif = q.x;
        zDif = q.z;
    }

    // set deadzone
    void CalibrateAccel()
    {
        deadZone = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0f, 0f, -1f), deadZone);
        Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotateQuaternion, new Vector3(1f, 1f, 1f));
        calibrateMat = matrix.inverse;
    }
}
