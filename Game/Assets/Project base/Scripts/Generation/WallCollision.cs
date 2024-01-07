using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer()); //calls timer
    }   

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); //waits for one seccond
            Wall_Collision(); //then calls Wall_Collision
        }    

    }


    //creates a list of colliders within 1f of the object
    //check through the list and for each one 
    //if object has a tag "Door"
    //then destroy the object
    void Wall_Collision()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f); 
          foreach (Collider collider in colliders) 
            {
                if(collider.tag == "Door")  
                {
                    Destroy(gameObject);
                    Debug.Log ("Destroying Walls");
                }
            }
         GetComponent<Collider>().enabled = true; //enable collider component
    }
 
}