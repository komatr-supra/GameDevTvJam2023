using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : IActionable
{
    //test -> add to attack configurator?
    float speed = 5;
    private AttackConfiguration attackConfiguration;
    private ActionHandler actionHandler;
    private bool attackFinished;
    private bool animationFinished;
    private Action onFinished;
    public Attack(ActionHandler actionHandler, AttackConfiguration attackConfiguration)
    {
        this.actionHandler = actionHandler;
        this.attackConfiguration = attackConfiguration;
    }
    public void ExecuteAction(Action onFinished, bool right = true)
    {
        actionHandler.GetComponent<SimpleAnimator>().SetAnimation(attackConfiguration.aniation, () => AttackTRigger(), () => AnimationFinished());
        this.onFinished = onFinished;
        attackFinished = false;
        animationFinished = false;
    }
    
    

    private void AttackTRigger()
    {
        if(attackConfiguration.isRanged)
        {
            Shoot();
        }
        else
        {
            Slash();
        }
    }

    private void AnimationFinished()
    {
        Debug.Log("animation finished");
        animationFinished = true;
        if(attackFinished) onFinished?.Invoke();
    }
    private void AttackFinished()
    {
        Debug.Log("attack finished");
        attackFinished = true;
        if(animationFinished) onFinished?.Invoke();
    }

    private void Slash()
    {
        Debug.Log("slash behaviour");
        onFinished?.Invoke();
    }

    private void Shoot()
    {
        float direction = actionHandler.GetComponent<CharacterRotationHandler>().Direction;
        Vector3 spawnedPosition = new Vector3(actionHandler.transform.position.x + direction * 0.5f, actionHandler.transform.position.y + 0.5f, 0);
        var projectile = GameObject.Instantiate(attackConfiguration.projectilePrefab, spawnedPosition, Quaternion.identity);
        projectile.GetComponent<Projectile>().Init(direction, speed, attackConfiguration.damage, actionHandler.GetComponent<Collider2D>(), () => AttackFinished());

    }}
