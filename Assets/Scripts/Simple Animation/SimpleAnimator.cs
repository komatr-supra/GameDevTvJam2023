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
        coroutine = StartCoroutine(SwitchFrameCoroutine(actualAnimation.framesPerSecond));
    }    
    public float GetAnimationTime()
    {
        return 1f / actualAnimation.framesPerSecond * actualAnimation.frameArray.Length;
    }
    private IEnumerator SwitchFrameCoroutine(int fps)
    {
        float changingTime = 1f / fps;
        var wait = new WaitForSeconds(changingTime);
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
        currentFrame = 0;
        if(onTriggerAction != null)
        {
            onAnimationTrigger = onTriggerAction;
        }
        if(coroutine == null) coroutine = StartCoroutine(SwitchFrameCoroutine(actualAnimation.framesPerSecond));
        spriteRenderer.sprite = actualAnimation.frameArray[currentFrame];
    }
    public void ResetCurrentAnimation()
    {
        currentFrame = 0;
        StopCoroutine(coroutine);
        coroutine = StartCoroutine(SwitchFrameCoroutine(actualAnimation.framesPerSecond));
        
    }
}