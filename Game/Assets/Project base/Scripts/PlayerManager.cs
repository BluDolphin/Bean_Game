using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	#region Singleton

	public static PlayerManager instance;

	void Awake ()
	{
		instance = this;  //set instance to this object
	}

	#endregion

	public GameObject player;  //asigns object to player

}