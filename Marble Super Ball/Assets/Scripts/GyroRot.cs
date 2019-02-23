using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroRot : MonoBehaviour {

    private Vector3 deadZone = Vector3.zero;
    private Matrix4x4 calibrateMat;

    bool isGyro;
	// Use this for initialization
	void Start ()
    {
        if(SystemInfo.supportsGyroscope == true)
        {
            isGyro = true;
            transform.rotation = Input.gyro.attitude;
        }
        else
            CalibrateAccel();

    }

    // Update is called once per frame
    void Update ()
    {
        if (isGyro)
            transform.rotation = Input.gyro.attitude;
        else
        {
            Vector3 accel = calibrateMat.MultiplyVector(Input.acceleration);
            transform.rotation *= Quaternion.Euler(accel.y, -accel.x, 0);
        }
       
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
