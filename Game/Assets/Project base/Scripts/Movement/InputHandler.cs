using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 InputVector { get; private set; }  // get+set x,y cordinates

    public Vector3 MousePosition { get; private set; } //get+set x,y,z cordinates

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal"); //get horizontal mouse position
        var v = Input.GetAxis("Vertical"); //get verical mouse position
        InputVector = new Vector2(h, v);
        
        MousePosition = Input.mousePosition;
    }

}