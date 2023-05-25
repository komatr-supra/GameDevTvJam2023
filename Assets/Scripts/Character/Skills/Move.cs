using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Move : Skill
{
    public Move(ActionHandler actionHandler, SkillConfiguration skillConfiguration) : base(actionHandler, skillConfiguration)
    {
    }

    public override Sprite SkillSprite => attackConfiguration.skillSprite;

    public override void ExecuteAction()
    {
        
        Vector3 endPosition = new Vector3(actionHandler.transform.position.x + actionHandler.Direction, actionHandler.transform.position.y, actionHandler.transform.position.z);
        actionHandler.transform.DOMove(endPosition, 1).SetEase(Ease.Linear).OnComplete(Finish);
        actionHandler.GetComponent<SimpleAnimator>().SetAnimation(characterStats.moveAnim);
    }

    private void Finish()
    {
        DOTween.KillAll();
        onFinished?.Invoke();
    }
}
