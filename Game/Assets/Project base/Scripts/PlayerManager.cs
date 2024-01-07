using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
	#region Singleton

	public static PlayerFinder instance;

	void Awake ()
	{
		instance = this;  //set instance to this object
	}

	#endregion

	public GameObject player;  //asignt onject to player

}