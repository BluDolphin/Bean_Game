using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public static Action shootInput;
    public static Action reloadInput;

    [SerializeField] private KeyCode reloadKey;

    private void Update() 
    {
        if (Input.GetMouseButton(0)) //if mouse 1 is pressed
        {
            shootInput?.Invoke();
        }

        if (Input.GetKeyDown(reloadKey)) //if reload key is pressed 
        {
            reloadInput?.Invoke();
        }

    }
}
