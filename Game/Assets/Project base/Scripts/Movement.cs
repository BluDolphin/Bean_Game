using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class Movement : MonoBehaviour


{
    private InputHandler _input;

    //rotate towards mouse y/n
    [SerializeField]
    private bool RotateTowardMouse;

    [SerializeField]
    private float MovementSpeed;  //move speed
    [SerializeField]
    private float RotationSpeed;  //rotation speed

    [SerializeField]
    private Camera Camera;  //camera


    private void Awake()
    {
        _input = GetComponent<InputHandler>();   //call from other script
    }

    // Update is called once per frame
    void Update()
    {
        
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);  //asigning variable
        var movementVector = MoveTowardTarget(targetVector);    //asigning variable

        if (!RotateTowardMouse)
        {
            RotateTowardMovementVector(movementVector);  
        }
        if (RotateTowardMouse)
        {
            RotateFromMouseVector();    //mouse look
        }
    }

    private void RotateFromMouseVector()
    {
        Ray ray = Camera.ScreenPointToRay(_input.MousePosition);   //draw line from ccamera to cursor

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))        //if line hits object
        {
            var target = hitInfo.point;    //asign the point hit as target
            target.y = transform.position.y;
            transform.LookAt(target);        //rotate to look at mouse
        }
    }  //follow mouse

    private Vector3 MoveTowardTarget(Vector3 targetVector)     
    {
        var speed = MovementSpeed * Time.deltaTime;    // movementSpeed variable * frame time 

        targetVector = Quaternion.Euler(0, Camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

    private void RotateTowardMovementVector(Vector3 movementDirection)
    {
        if(movementDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
    }
}