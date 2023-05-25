using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : Skill
{
    public SwordAttack(ActionHandler actionHandler, SkillConfiguration attackConfiguration) : base(actionHandler, attackConfiguration)
    {
    }

    public override Sprite SkillSprite => attackConfiguration.skillSprite;

    public override bool ExecuteAction()
    {
        //check if can attack
        actionHandler.GetComponent<SimpleAnimator>().SetAnimation(characterStats.meleeAnim,
                PerformAttack, onFinished);
        return true;
    }
    private void PerformAttack()
    {
        var hits = Physics2D.BoxCastAll(actionHandler.transform.position + new Vector3(actionHandler.Direction, 0.5f, 0), Vector2.one * 0.2f, 0, Vector2.zero);
        if(!(hits.Length > 0)) return;

        foreach (var item in hits)
        {
            if(item.collider.TryGetComponent<CharacterStats>(out var hitedCharacter))
            {
                hitedCharacter.TakeDamage(attackConfiguration.damage);
                VFXCreator.Instance.CreateEffect(item.point, VFXType.blood);
            }
        }
    }
}
