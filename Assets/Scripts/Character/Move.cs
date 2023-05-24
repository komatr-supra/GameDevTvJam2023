using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Move : IActionable
{   

    private CharacterStats stats;
    private ActionHandler actionHandler;
    private SimpleAnimationSO animation;
    private Action onFinished;
    public Move(ActionHandler actionHandler, CharacterStats characterStats, SimpleAnimationSO animation)
    {
        this.stats = characterStats;
        this.actionHandler = actionHandler;
        this.animation = animation;
    }


    public void ExecuteAction(Action onFinished, bool right = true)
    {
        this.onFinished = onFinished;
        float addedDistance = right ? stats.movementDistance : -stats.movementDistance;
        Vector3 endPosition = new Vector3(actionHandler.transform.position.x + addedDistance, actionHandler.transform.position.y, actionHandler.transform.position.z);
        actionHandler.transform.DOMove(endPosition, 1).SetEase(Ease.Linear).OnComplete(Finish);
        actionHandler.GetComponent<SimpleAnimator>().SetAnimation(animation);
        
    }
    private void Finish()
    {
        DOTween.KillAll();
        onFinished?.Invoke();
    }
}
