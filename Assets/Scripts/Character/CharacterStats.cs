using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //he can be changed behaviour of attacks
    public SimpleAnimationSO shootAnim;
    public SimpleAnimationSO idleAnim;
    public SimpleAnimationSO moveAnim;
    public SimpleAnimationSO meleeAnim;
    public int damage = 1;
    public int spellDamage = 1;
    public List<SkillConfiguration> skillConfigurations;
    public float health;
    private void Start() {
        
    }
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
