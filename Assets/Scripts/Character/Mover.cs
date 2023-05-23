using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Mover : MonoBehaviour
{
    [SerializeField] private SimpleAnimationSO animationMove;
    readonly float movementDistance = 1;

    public void Move(bool right, Action onFinishMovement)
    {
        float addedDistance = right ? movementDistance : -movementDistance;
        Vector3 endPosition = new Vector3(transform.position.x + addedDistance, transform.position.y, transform.position.z);
        transform.DOMove(endPosition, 1).OnComplete(() => onFinishMovement()).SetEase(Ease.Linear);
        GetComponent<SimpleAnimator>().SetAnimation(animationMove);
    }
}
