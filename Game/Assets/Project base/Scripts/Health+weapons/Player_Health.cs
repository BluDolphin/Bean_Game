using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour, DamageAble 
{
    public int CurrentHealth; //integer version of the current health
    public float health; //float for the current health
    public float armor; //vairable for armor
    public ParticleSystem TakingDamage; //variable for a particle generator

    public HealthBar healthBar; //refrence HealthBar script

    //Run at the start of the program
    public void Start()
    {
        int CurrentHealth = (int) health; //sets CurrentHealth to the same as health
        healthBar.SetMaximum(CurrentHealth); //calls the set maximum function to set maximum value for the slider
    }

    //damage function
    public void Damage(float damage)
    {
        TakingDamage.Play(); //play the paricle generator

        health -= damage / armor; //damage is divied by armor, then subtract that from health
        if (health <=0) Destroy(gameObject); //if health is 0 or below deelte the game object

        int CurrentHealth = (int) health; //sets CurrentHealth to health
        healthBar.SetSlider(CurrentHealth); //calls the set slider function to change the health bar
    }
}