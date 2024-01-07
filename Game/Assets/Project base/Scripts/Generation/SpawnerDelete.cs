using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for use with the boos spwaner
public class SpawnerDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 7f); //creates a sphere around the current object
          foreach (Collider collider in colliders) 
            {
                if(collider.tag == "Boss")  //if an object called boss is in this sphere 
                {
                    Destroy(gameObject); //delete yourself

                }
            }
         GetComponent<Collider>().enabled = true; //enable collieder componet 
    }   
}