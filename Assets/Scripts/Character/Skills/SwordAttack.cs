using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : Skill
{
    public SwordAttack(ActionHandler actionHandler) : base(actionHandler)
    {
    }

    public override Sprite SkillSprite => characterStats.swordAttack.skillSprite;

    public override void ExecuteAction()
    {
        actionHandler.GetComponent<SimpleAnimator>().SetAnimation(characterStats.swordAttack.aniation,
                PerformAttack, onFinished);
    }
    private void PerformAttack()
    {
        var hits = Physics2D.BoxCastAll(actionHandler.transform.position + new Vector3(actionHandler.Direction, 0.5f, 0), Vector2.one * 0.2f, 0, Vector2.zero);
        if(!(hits.Length > 0)) return;

        foreach (var item in hits)
        {
            if(item.collider.TryGetComponent<CharacterStats>(out var hitedCharacter))
            {
                hitedCharacter.TakeDamage(this.characterStats.swordAttack.damage);
                VFXCreator.Instance.CreateEffect(item.point, VFXType.blood);
            }
        }
    }
}
