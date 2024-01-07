using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] public int SpawnChance;  //creates an integer variable StartPos
    public GameObject Enemy;  //selects what object to be spawned 
    public int Chance;  //intiger to store the random number 
    
    //This function is called at the start of the program
    void Start() 
    {
        StartCoroutine(Timer()); //starts the timer
        Chance = Random.Range(0,100); //stores a random number between 0 and 100
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); //waits for one seccond
            Spawner(); //then calls spawner
        }    
    }

    //checks to see if the random number generated is less than or equal to the spawn probabibility
    //if it is smaller it creates the gameobject at its current location
    //then deletes itself to prevent continuous spawning 
    void Spawner()
    {
        if (Chance <= SpawnChance) //of the chance is less than or equal to the spawn chance
        {
            Instantiate(Enemy, transform.position,Quaternion.identity); //generate a new game object using the Enemy variable
            Object.Destroy(this.gameObject); //Destroy this current game object
        }
    }
}