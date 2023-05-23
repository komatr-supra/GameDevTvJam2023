using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Mover : MonoBehaviour, IActionable
{
    [SerializeField] private SimpleAnimationSO animationMove;
    readonly float movementDistance = 1;
    public void ExecuteAction(Action onFinished, bool right = true)
    {
        float addedDistance = right ? movementDistance : -movementDistance;
        Vector3 endPosition = new Vector3(transform.position.x + addedDistance, transform.position.y, transform.position.z);
        transform.DOMove(endPosition, 1).SetEase(Ease.Linear).OnComplete(() => onFinished());
        GetComponent<SimpleAnimator>().SetAnimation(animationMove);
    }
}
