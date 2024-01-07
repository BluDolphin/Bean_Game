using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    public GameObject VictoryScreen; //variable to asign victory screen

    void Start()
    {
        VictoryScreen.SetActive(false); //set victory screen to disabled
        StartCoroutine(Timer()); //calls timer
    }   

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); //waits for one seccond
            BossDetection(); //then calls Boss_detection
        }    

    }
    void BossDetection()
    {
        if (GameObject.FindWithTag("Boss") != null) //if there is an object with the tag boss 
        {
            // GameObject with tag "Boss" exists in the scene
        }
        else //otherwise
        {
            // GameObject with tag "Boss" does not exist in the scene
            Debug.Log("boss is dead");
            VictoryScreen.SetActive(true); //set victory screen to active
            Time.timeScale = 0; //set game time to 0
        }
       
    }
}