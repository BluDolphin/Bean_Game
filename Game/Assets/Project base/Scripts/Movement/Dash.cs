using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    

    [SerializeField]
    private float DashDistance; //asigning a varible for how far the player will travel forward with dash
    [SerializeField]
    private float HightOffset; // asigning a varible for how far up or down the player will translate

    [SerializeField]
    public float CoolDown; //how long it will take for the player to be able to dash again

    private float nextTime; //variale for calculating if the cooldown has been reached




    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("space") && Time.time > nextTime)  //if space is pressed and current time is greater than NextTime  //Time.time is how long its been since start
        {

            if(Input.GetKey("w"))
            {
                Debug.Log("dash forward");

                transform.Translate(DashDistance,HightOffset,0);
            }
            else if(Input.GetKey("s"))
            {
                Debug.Log("dash backward");

                transform.Translate(-DashDistance,HightOffset,0);
            }

            else if (Input.GetKey("d"))
            {
                Debug.Log("dash right");

                transform.Translate(0,HightOffset,-DashDistance);
            }
            else if (Input.GetKey("a"))
            {
                Debug.Log("dash left");

                transform.Translate(0,HightOffset,DashDistance);
            }

            nextTime = Time.time + CoolDown; //set NextTime as current time from game start + CoolDown
        }
    }
}
