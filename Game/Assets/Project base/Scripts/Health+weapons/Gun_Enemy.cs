using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun_Enemy : MonoBehaviour
{
    [SerializeField] private WeaponData WeaponData; //asign gameobject with vaiables from WeaponData
    [SerializeField] private Transform Muzzle;


    float TimeSinceAttack;
    public ParticleSystem MuzzleFlash;
    public ParticleSystem ParticleReloading;

    //This function is called at the start of the program
    private void Start()
    {
        EnemyAI.shootInput += Shoot;

        EnemyAI.reloadInput += StartReload;
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
        Debug.Log ("Enemy Reloading");
        
        ParticleReloading.Play();

        WeaponData.reloading = true;  //set reloading to true

        yield return new WaitForSeconds(WeaponData.reloadTime); //wait for reload time before continuing 

        WeaponData.ammoLeft = WeaponData.magSize; //set ammo left to maximum ammo amount

        WeaponData.reloading = false; //set reloading to false
    }

    //if the not reloading and time since last attack is greater than 1 dived by the fire rate divided by 60
    private bool CanShoot() => !WeaponData.reloading && TimeSinceAttack > 1f / (WeaponData.fireRate / 60f);

    public void Shoot()
    {
        Debug.Log("Enemy Attacking");

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
                TimeSinceAttack = 0;
                

            }
        }

    }

    //This function is called each frame
    private void Update()
    {
        TimeSinceAttack += Time.deltaTime; //sets time since last attack to itself + the current game time
        
        //draws a straight line from the end of the gun
        Debug.DrawRay(Muzzle.position, Muzzle.forward * WeaponData.fallOff);
    }

}