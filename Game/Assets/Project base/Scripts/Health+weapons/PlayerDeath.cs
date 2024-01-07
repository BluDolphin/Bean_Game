using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject DeathScreen;

    void Start()
    {
        DeathScreen.SetActive(false);
        StartCoroutine(Timer()); //calls timer
    }   

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); //waits for one seccond
            UserDetection(); //then calls User_detection
        }    

    }
    void UserDetection()
    {
        if (GameObject.FindWithTag("User") != null)
        {
            // GameObject with tag "User" exists in the scene
        }
        else
        {
            // GameObject with tag "User" does not exist in the scene
            Debug.Log("User is dead");
            DeathScreen.SetActive(true);
            Time.timeScale = 0;

        }
       
    }
}