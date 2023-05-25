using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : Skill
{
    private bool attackFinished;
    private bool animationFinished;

    public ShootAttack(ActionHandler actionHandler) : base(actionHandler)
    {
    }

    public override Sprite SkillSprite => characterStats.shootAttack.skillSprite;

    public override void ExecuteAction()
    {
        actionHandler.GetComponent<SimpleAnimator>().SetAnimation(characterStats.shootAttack.aniation, () => Shoot(), () => AnimationFinished());
        attackFinished = false;
        animationFinished = false;
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
        var projectile = GameObject.Instantiate(characterStats.shootAttack.projectilePrefab, spawnedPosition, Quaternion.identity);
        projectile.GetComponent<Projectile>().Init(actionHandler.Direction, characterStats.shootAttack.projectileSpeed, characterStats.shootAttack.damage, actionHandler.GetComponent<Collider2D>(), () => AttackFinished());

    }

}
