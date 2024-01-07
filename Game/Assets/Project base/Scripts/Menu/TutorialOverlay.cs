using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOverlay : MonoBehaviour
{
    
    public GameObject TutorialMenu;

    // Start is called before the first frame update
    void Start()
    {
        TutorialMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) //if reload key is pressed 
        {
            Debug.Log("Tab was pressed.");
            TutorialMenu.SetActive(!TutorialMenu.activeSelf); //toggle tutorial menus state

        }
    }
}