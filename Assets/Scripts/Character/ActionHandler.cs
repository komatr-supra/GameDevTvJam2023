using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHandler : MonoBehaviour
{
    //test

    [SerializeField] private SimpleAnimationSO moveAnim;
    [SerializeField] private SimpleAnimationSO idleAnim;
    public SimpleAnimationSO MoveAnim => moveAnim;
    //get char data
    int maxActionPoints = 2;
    //end test
    private SimpleAnimator animator;
    private List<Skill> actions;  
     
    public float Direction => characterRotationHandler.Direction;
    public int actionPoints;
    private bool isActive;
    private bool inProgress;
    private bool endTurnFlag;
    public Action onTurnEnd;
    private CharacterRotationHandler characterRotationHandler;
    private void Awake()
    {
        characterRotationHandler = GetComponent<CharacterRotationHandler>();
        animator = GetComponent<SimpleAnimator>();
        var charStat = GetComponent<CharacterStats>();
        actions = new();
        var shootAttack = new ShootAttack(this, ProgressClear, charStat);
        actions.Add(shootAttack);
        var move = new Move(this, ProgressClear, charStat);
        actions.Add(move);
        var sword = new SwordAttack(this, ProgressClear, charStat);
        actions.Add(sword);
    }
    
    public void PerformAction(Skill action)
    {
        if(!isActive || inProgress) return;
        inProgress = true;
        action.ExecuteAction(ProgressClear);
        actionPoints--;
        if(actionPoints <= 0) endTurnFlag = true;
    }
    public Skill[] GetSkills() => actions.ToArray();
    
    
    private void ProgressClear()
    {
        inProgress = false;
        animator.SetAnimation(idleAnim);
        if(endTurnFlag)
        {
            endTurnFlag = false;            
            onTurnEnd?.Invoke();
        }
    }
    public void CharacterActive(bool isActive)
    {
        if(isActive) actionPoints = maxActionPoints;
        this.isActive = isActive;
    }

    internal Skill GetAction<T>()
    {
        foreach (var item in actions)
        {
            if(item is T) return item;
        }
        return default;
    }
}
