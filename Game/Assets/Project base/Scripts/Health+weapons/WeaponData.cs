using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creates a class which in the unity menu
[CreateAssetMenu(fileName="Weapons", menuName="weapon/Gun")]
public class WeaponData : ScriptableObject
{
    public new string name;

    public float damage; //how much damage is done 
    public float fallOff; // how fare the bullet travels 

    public static int ammoLeft; //how much ammo is left in the mag
    public int magSize; //how much ammo there is before reloading
    public float fireRate; //how fast the gun can shoot
    public float reloadTime; //how long it takes to reload
    [HideInInspector]
    public bool reloading; //if the player is currently reloading 

}
