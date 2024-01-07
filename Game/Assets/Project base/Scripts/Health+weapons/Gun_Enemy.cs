using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun_Enemy : MonoBehaviour
{
    [SerializeField] private WeaponData WeaponData; //asign gameobject with vaiables from WeaponData
    [SerializeField] private Transform Muzzle;


    float timesinceSinceLastAttack;
    public ParticleSystem MuzzleFlash;
    public ParticleSystem ParticleReloading;

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


    private bool CanShoot() => !WeaponData.reloading && timesinceSinceLastAttack > 1f / (WeaponData.fireRate / 60f);

    public void Shoot()
    {
        Debug.Log("Enemy Attacking");

        if (WeaponData.ammoLeft >0)
        {
            if (CanShoot())
            {
                MuzzleFlash.Play();
                
                if(Physics.Raycast(Muzzle.position, Muzzle.forward, out RaycastHit hitInfo, WeaponData.fallOff))
                {
                    DamageAble damageable = hitInfo.transform.GetComponent<DamageAble>();
                    damageable?.Damage(WeaponData.damage);
                }

                WeaponData.ammoLeft--;
                timesinceSinceLastAttack = 0;
                OnAttack();


            }
        }

    }


    private void Update()
    {
        timesinceSinceLastAttack += Time.deltaTime;
        

        Debug.DrawRay(Muzzle.position, Muzzle.forward * WeaponData.fallOff);
    }

    private void OnAttack()
    {

    }

}
