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

    public override bool ExecuteAction()
    {
        //check if character can go
        Vector3 endPosition = new Vector3(actionHandler.transform.position.x + actionHandler.Direction, actionHandler.transform.position.y, actionHandler.transform.position.z);
        if(Physics2D.OverlapPoint(endPosition))
        {
            Debug.Log("position is not free");
            return false;
        }
        SFXPlayer.PlaySFX(actionHandler.transform.position, attackConfiguration.clip);
        actionHandler.transform.DOMove(endPosition, 1).SetEase(Ease.Linear).OnComplete(Finish);
        actionHandler.GetComponent<SimpleAnimator>().SetAnimation(characterStats.moveAnim);
        return true;
    }

    private void Finish()
    {
        DOTween.KillAll();
        onFinished?.Invoke();
    }
}
