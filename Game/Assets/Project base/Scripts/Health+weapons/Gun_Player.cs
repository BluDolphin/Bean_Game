using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun_Player : MonoBehaviour
{
    [SerializeField] private WeaponData WeaponData; //asign gameobject with vaiables from WeaponData
    [SerializeField] private Transform Muzzle;


    float TimeSinceLastAttack;
    public ParticleSystem MuzzleFlash;
    public ParticleSystem ParticleReloading;

    //This function is called at the start of the program
    private void Start()
    {
        Firing.shootInput += Shoot;

        Firing.reloadInput += StartReload;
        StartCoroutine(Reload());
    }

    public void StartReload()
    {
        if (!WeaponData.reloading) //reload
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        Debug.Log ("Player Reloading");
        
        ParticleReloading.Play(); //plays the reloading paritcles

        WeaponData.reloading = true;  //set reloading to true

        yield return new WaitForSeconds(WeaponData.reloadTime); //wait for reload time before continuing 

        WeaponData.ammoLeft = WeaponData.magSize; //set ammo left to maximum ammo amount

        WeaponData.reloading = false; //set reloading to false
    }

    //boolean for if the gun can shoot 
    //if the not reloading and time since last attack is greater than 1 dived by the fire rate divided by 60
    private bool CanShoot() => !WeaponData.reloading && TimeSinceLastAttack > 1f / (WeaponData.fireRate / 60f);

    public void Shoot()
    {
        Debug.Log("Player Attacking");

        if (WeaponData.ammoLeft >0)
        {
            if (CanShoot())
            {
                MuzzleFlash.Play(); //plays muzzle flash particles
                
                //cast a ray from the muzzle, if it hits an entity
                if(Physics.Raycast(Muzzle.position, Muzzle.forward, out RaycastHit hitInfo, WeaponData.fallOff))
                {
                    //get its DamageAble component
                    DamageAble damageable = hitInfo.transform.GetComponent<DamageAble>();
                    //deal the damage from the current weapon
                    damageable?.Damage(WeaponData.damage);
                }

                //set time since last attack to 0
                TimeSinceLastAttack = 0;
                
            }
        }

    }

    //This function is called each frame
    private void Update()
    {
        TimeSinceLastAttack += Time.deltaTime; //sets time since last attack to itself + the current game time
        
        //draws a straight line from the end of the gun
        Debug.DrawRay(Muzzle.position, Muzzle.forward * WeaponData.fallOff);
    }
}