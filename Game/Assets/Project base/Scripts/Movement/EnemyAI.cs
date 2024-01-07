using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public static Action shootInput;
    public static Action reloadInput;

    [SerializeField]
    public float LookRadius; //field for entering radius for player detection
    
    [SerializeField]
    public float AttackingDistance; //how far away the enemy will stop from the player 
    
    [SerializeField]
    Transform target;  
    [SerializeField]
    NavMeshAgent agent;

    void Start()
    {
        target = PlayerManager.instance.player.transform; //set the playet as the variable target
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);  //find the distance by getting the difference between player cordinates and objects
        if (distance <= LookRadius)  // if disntance is less than or greater than look radius
        {
            Debug.Log("AI moving to target");
            agent.SetDestination(target.position);  //go to targets position
        }


        if (distance <= AttackingDistance) //if player is further away from attacking distance 
        {
            Debug.Log("AI stopping");
            transform.LookAt(target); //look at target
            agent.isStopped = true; //stop moving
            shootInput?.Invoke();

            if (WeaponData.ammoLeft == 0)
            {
                reloadInput?.Invoke();
            }
            
        }
        else  // otherwise dont stop
        {
            agent.isStopped = false; 
        }


    }

    void OnDrawGizmos() //create a way to see look radius for debugging
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookRadius); //create a red wire sphere around the object to see looking radius for debugging

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, AttackingDistance); //create a yellow wire sphere around the object to see looking radius for debugging
    }
}
