using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public static Action shootInput; //sets an action called shootInput
    public static Action reloadInput; //sets an action called reloadInput

    //This functions is called each frame
    private void Update() 
    {
        if (Input.GetMouseButton(0)) //check if mouse 1 is pressed
        {
            shootInput?.Invoke(); //activate the shoot input
        }
    }
}