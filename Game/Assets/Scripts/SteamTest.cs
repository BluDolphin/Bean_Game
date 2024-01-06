using UnityEngine;
using Steamworks;

namespace BluDolphin
{

    public class SteamTest : MonoBehaviour
    {

        private void Start()
        {
            if(!SteamManager.Initialized) {return;} //check to see if Steam in running if not return

            string name = SteamFriends.GetPersonaName(); //get accounts public name and asign to name
            Debug.Log(name); //print name into console for debug
        }
    }
}
