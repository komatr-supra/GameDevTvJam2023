using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //he can be changed behaviour of attacks
    
    [SerializeField] private AudioClip hurt;
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
    public Action onDIe;
    private void Start() {
        health = maxHealth;
        onHealthChange?.Invoke();
    }
    //sorry but no time to right implementation
    public void TakeDamage(int damage)
    {
        SFXPlayer.PlaySFX(transform.position, hurt);
        health -= damage;
        onHealthChange?.Invoke();
        if(health <= 0) Death();
    }

    private void Death()
    {
        GetComponent<SimpleAnimator>().SetAnimation(deathAnim, null, () => {onDIe?.Invoke();});
    }
}
