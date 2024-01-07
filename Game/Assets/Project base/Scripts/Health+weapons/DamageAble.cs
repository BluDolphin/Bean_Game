using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is used on objects which can be damaged
public interface DamageAble
{
    public void Damage(float damage); //takes in damage value and passes it onto the health script
}