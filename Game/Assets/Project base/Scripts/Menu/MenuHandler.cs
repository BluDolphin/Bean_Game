using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public GameObject PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //if escape is pressed 
        {
            Debug.Log("Escape was pressed.");
            PauseMenu.SetActive(!PauseMenu.activeSelf);

            if (Time.timeScale == 1) //if game speed is 1 change it to 0
            {
                Time.timeScale = 0;
                Debug.Log("Paused game");
            }
            else //otherwise set it to 1
            {
                Time.timeScale = 1;
            }
        }

    }
}