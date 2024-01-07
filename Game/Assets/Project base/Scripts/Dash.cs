using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    

    [SerializeField]
    private float DashDistance;
    [SerializeField]
    private float HightOffset;

    [SerializeField]
    public float CoolDown;

    private float nextTime;




    // Update is called once per frame
    void Update()
    {
    
    
        if (Input.GetKey("space") && Time.time > nextTime) 
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

            nextTime = Time.time + CoolDown;
        }
    }
}
