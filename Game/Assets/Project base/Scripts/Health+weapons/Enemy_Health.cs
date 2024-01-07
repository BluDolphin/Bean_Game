using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour, DamageAble 
{
    public float health; //float for current health
    public float armor; //float fopr armor
    public ParticleSystem TakingDamage; //variable for paritcle generator

    //function called Damage
    public void Damage(float damage)
    {
        TakingDamage.Play(); //Play particle generator
        health -= damage / armor; //damage is divied by armor, then subtract that from health
        if (health <=0) Destroy(gameObject); //if the health is 0 or less delete the game object 
    }
}