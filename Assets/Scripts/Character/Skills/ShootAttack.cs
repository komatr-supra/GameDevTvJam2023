using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : Skill
{
    private bool attackFinished;
    private bool animationFinished;

    public ShootAttack(ActionHandler actionHandler, SkillConfiguration attackConfiguration) : base(actionHandler, attackConfiguration)
    {
    }

    public override Sprite SkillSprite => attackConfiguration.skillSprite;

    public override bool ExecuteAction()
    {
        //check if can shoot
        //return false;
        SFXPlayer.PlaySFX(actionHandler.transform.position, attackConfiguration.clip);
        actionHandler.GetComponent<SimpleAnimator>().SetAnimation(characterStats.shootAnim, () => Shoot(), () => AnimationFinished());
        attackFinished = false;
        animationFinished = false;
        return true;
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

    private void Shoot()
    {
        Vector3 spawnedPosition = new Vector3(actionHandler.transform.position.x + actionHandler.Direction * 0.5f, actionHandler.transform.position.y + 0.5f, 0);
        var projectile = GameObject.Instantiate(attackConfiguration.projectilePrefab, spawnedPosition, Quaternion.identity);
        projectile.GetComponent<Projectile>().Init(actionHandler.Direction, attackConfiguration.projectileSpeed, characterStats.spellDamage, actionHandler.GetComponent<Collider2D>(), () => AttackFinished());

    }

}
