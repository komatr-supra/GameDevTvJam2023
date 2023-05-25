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
    public SimpleAnimationSO deathAnim;
    public int damage = 1;
    public int spellDamage = 1;
    public List<SkillConfiguration> skillConfigurations;
    public Action onHealthChange;
    public int maxHealth = 4;
    public int health;
    private void Start() {
        health = maxHealth;
        onHealthChange?.Invoke();
    }
    //sorry but no time to right implementation
    public void TakeDamage(int damage)
    {
        health -= damage;
        onHealthChange?.Invoke();
        if(health <= 0) Death();
    }

    private void Death()
    {
        Debug.Log("character " + this + " died!");
        GetComponent<SimpleAnimator>().SetAnimation(deathAnim, null, () => Destroy(gameObject));
    }
}
