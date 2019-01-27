using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float CameraSpeed;
    PlayerController Pcontroller;

    void Start()
    {
        //this.gameObject.SetActive(false);
        Pcontroller = transform.parent.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Pcontroller.unitController != null)
        {

            transform.position = new Vector3(Pcontroller.unitController.transform.position.x,
                                                Pcontroller.unitController.transform.position.y,
                                                Pcontroller.unitController.transform.position.z);
        }
        else
        {
            if (Input.GetMouseButton(2))
            {
                //Continue;
            }
            else
            {
                if (20 > Input.mousePosition.x || Input.GetKey(KeyCode.A))
                {
                    transform.Translate(Vector3.left * CameraSpeed * Time.deltaTime);
                }
                if ((Screen.width - 10) < Input.mousePosition.x || Input.GetKey(KeyCode.D))
                {
                    transform.Translate(Vector3.right * CameraSpeed * Time.deltaTime);
                }
                if (20 > Input.mousePosition.y || Input.GetKey(KeyCode.S))
                {
                    transform.Translate(Vector3.back * CameraSpeed * Time.deltaTime);
                }
                if ((Screen.height - 10) < Input.mousePosition.y || Input.GetKey(KeyCode.W))
                {
                    transform.Translate(Vector3.forward * CameraSpeed * Time.deltaTime);
                }
            }
        }
    }
}
