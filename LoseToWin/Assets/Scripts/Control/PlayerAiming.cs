using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    private bool controllerInput;
    // Update is called once per frame
    void Update()
    {
        controllerInput = ControllerInputDetected();
        if(!GameManager.playerCanMove)
            return;
        if (!controllerInput)
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, transform.position);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);
                transform.LookAt(pointToLook);
            }
        }
        else
        {
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RotationHoriz") + Vector3.forward * -Input.GetAxisRaw("RotationVert");
            if(playerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }
        }
    }
    bool ControllerInputDetected()
    {
        //Get Joystick Names
        string[] temp = Input.GetJoystickNames();

        //Check whether array contains anything
        if (temp.Length > 0)
        {
            //Iterate over every element
            for (int i = 0; i < temp.Length; ++i)
            {
                //Check if the string is empty or not
                if (!string.IsNullOrEmpty(temp[i]))
                {
                    //Not empty, controller temp[i] is connected
                    //Debug.Log("Controller " + i + " is connected using: " + temp[i]);
                    return true;
                }
                else
                {
                    //If it is empty, controller i is disconnected
                    //where i indicates the controller number
                    //Debug.Log("Controller: " + i + " is disconnected.");
                    return false;

                }
            }
        }
        return false;

    }
}
