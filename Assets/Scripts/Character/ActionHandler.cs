using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHandler : MonoBehaviour
{
    //test
    public AttackConfiguration shootConfig;

    [SerializeField] private SimpleAnimationSO moveAnim;
    [SerializeField] private SimpleAnimationSO idleAnim;
    [SerializeField] private SimpleAnimationSO shootAnim;
    //get char data
    int maxActionPoints = 2;
    //end test
    private SimpleAnimator animator;
    private List<IActionable> actions;    

    public int actionPoints;
    private bool isActive;
    private bool inProgress;
    private bool endTurnFlag;
    public Action onTurnEnd;
    private void Awake()
    {
        animator = GetComponent<SimpleAnimator>();
        actions = new();
        var shootAttack = new Attack(this, shootConfig);
        actions.Add(shootAttack);
        var move = new Move(this, GetComponent<CharacterStats>(), moveAnim);
        actions.Add(move);
    }
    
    public bool TryPerformAction(IActionable action, bool right = true)
    {
        if(!isActive) return false;
        if(inProgress) return false;
        inProgress = true;
        action.ExecuteAction(ProgressClear, right);
        actionPoints--;
        if(actionPoints <= 0) endTurnFlag = true;
        return true;
    }
    public IActionable GetMoveAction()
    {
        foreach (var item in actions)
        {
            if(item is Move) return item;
        }
        return default;
    }
    public IActionable GetAttackAction(AttackConfiguration attackConfiguration)
    {
        foreach (var item in actions)
        {
            if(item is Attack) return item;
        }
        return default;
    }
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
}
