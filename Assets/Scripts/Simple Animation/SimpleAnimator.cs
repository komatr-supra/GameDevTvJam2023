using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//basic testing animation for 2D -> TODO: state machine
public class SimpleAnimator : MonoBehaviour
{
    [SerializeField] private SimpleAnimationSO idleAnimation;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Action onAnimationEnd;
    private Action onAnimationTrigger;
    //this is an SO for played animation
    private SimpleAnimationSO actualAnimation;
    private int currentFrame;
    private Coroutine coroutine;
    WaitForSeconds wait;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        //method is just as description, can be directly in awake        
        actualAnimation = idleAnimation;
    }
    private void Start() 
    {
        if(actualAnimation == null) return;
        SetWait();
        coroutine = StartCoroutine(SwitchFrameCoroutine());
    } 
    private IEnumerator SwitchFrameCoroutine()
    {
        
        while (true)
        {
            if(actualAnimation.frameTrigger == currentFrame) onAnimationTrigger?.Invoke();
            if(!actualAnimation.isLoopable && currentFrame == actualAnimation.frameArray.Length - 1) 
            {
                onAnimationEnd?.Invoke();
                yield break;
            }            
            SwitchFrame();
            yield return wait;
        }        
    }
    private void SwitchFrame()
    {
        currentFrame = (currentFrame + 1) % actualAnimation.frameArray.Length;
        spriteRenderer.sprite = actualAnimation.frameArray[currentFrame];
    }

    public void SetAnimation(SimpleAnimationSO simpleAnimation, Action onTriggerAction = null)
    {        
        if(actualAnimation == simpleAnimation) return;
        onAnimationEnd = null;
        onAnimationTrigger = null;
        actualAnimation = simpleAnimation;
        SetWait();
        currentFrame = 0;
        if(onTriggerAction != null)
        {
            onAnimationTrigger = onTriggerAction;
        }
        StopCoroutine(coroutine);
        coroutine = StartCoroutine(SwitchFrameCoroutine());
        spriteRenderer.sprite = actualAnimation.frameArray[currentFrame];
    }
    public void ResetCurrentAnimation()
    {
        currentFrame = 0;
        StopCoroutine(coroutine);
        coroutine = StartCoroutine(SwitchFrameCoroutine());
        
    }
    private void SetWait()
    {
        wait = new WaitForSeconds(1f / actualAnimation.framesPerSecond);
    }
}
