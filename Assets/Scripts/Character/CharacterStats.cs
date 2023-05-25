using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //he can be changed behaviour of attacks
    public AttackConfiguration shootAttack;
    public AttackConfiguration swordAttack;
    public float health;
    //sorry but no time to right implementation
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0) Death();
    }

    private void Death()
    {
        Debug.Log("character " + this + " died!");
    }
}
