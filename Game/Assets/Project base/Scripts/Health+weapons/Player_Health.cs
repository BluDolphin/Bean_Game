using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour, DamageAble 
{
    public float health;
    public float armor;
   public ParticleSystem TakingDamage;

    public void Damage(float damage)
    {
        TakingDamage.Play();

        health -= damage / armor;
        if (health <=0) Destroy(gameObject);
    }
}
