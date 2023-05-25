using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Move : Skill
{
    public Move(ActionHandler actionHandler, Action onFinished, CharacterStats characterStats) : base(actionHandler, onFinished, characterStats)
    {
    }

    public override Sprite SkillSprite => null;

    public override void ExecuteAction(Action onFinished)
    {
        this.onFinished = onFinished;
        Vector3 endPosition = new Vector3(actionHandler.transform.position.x + actionHandler.Direction, actionHandler.transform.position.y, actionHandler.transform.position.z);
        actionHandler.transform.DOMove(endPosition, 1).SetEase(Ease.Linear).OnComplete(Finish);
        actionHandler.GetComponent<SimpleAnimator>().SetAnimation(actionHandler.MoveAnim);
    }

    private void Finish()
    {
        DOTween.KillAll();
        onFinished?.Invoke();
    }
}