using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Vector3 offset;
    public GameObject FocusObject;
    public float CameraZoomMax = 10f;
    public float CameraZoomMin = 3f;
    public float zoom = 0.25f;
    public float sensitivity = 1f;
    public float limitMax = 80f;
    public float limitMin = 1f;

    private float X, Y;

    void Start()
    {
        offset = new Vector3(offset.x, offset.y, -Mathf.Abs(CameraZoomMax) / 2);
        //transform.position = FocusObject.transform.position + offset;
        transform.position = new Vector3(FocusObject.transform.position.x,
                                         FocusObject.transform.position.y + 2f,
                                         FocusObject.transform.position.z) + offset;
        transform.LookAt(FocusObject.transform);
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && offset.z < -CameraZoomMin)
            offset.z += zoom;
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && offset.z > -CameraZoomMax)
            offset.z -= zoom;

        transform.position = transform.localRotation * offset + FocusObject.transform.position;

        if (Input.GetKey(KeyCode.Mouse2))
        {
            offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(CameraZoomMax), -Mathf.Abs(CameraZoomMin));

            X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
            Y += Input.GetAxis("Mouse Y") * sensitivity;
            Y = Mathf.Clamp(Y, -limitMax, -limitMin);
            transform.localEulerAngles = new Vector3(-Y, X, 0);
            transform.position = transform.localRotation * offset + FocusObject.transform.position;
            FocusObject.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        }
    }
}
