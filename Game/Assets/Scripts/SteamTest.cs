using UnityEngine;
using Steamworks;

namespace SteamName
{

    public class SteamTest : MonoBehaviour
    {

        private void Start()
        {
            if(!SteamManager.Initialized) {return;} //check to see if Steam in running if not return
            Debug.Log("Steam is Initialized");

            string name = SteamFriends.GetPersonaName(); //get accounts public name and asign to name
            Debug.Log(name); //print name into console for debug
        }
    }
}
