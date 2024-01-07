using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFunctions : MonoBehaviour
{
    //0-1-2-3 = up-down-right-left
    public GameObject[] walls; //creates an array to asign walls
    public GameObject[] doors; //creates an array to asign doors

   
    public void RoomUpdate(bool[] status) // check to see if the room has an open door
    {
        for (int i = 0; i < status.Length; i++) //whenever true
        {
            doors[i].SetActive(status[i]); //when doors is true the door is active
            walls[i].SetActive(!status[i]); //! means the oposite of the door - when wall is true wall is active
        }
    }
}