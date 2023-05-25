using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ActionHandler : MonoBehaviour
{
    [SerializeField] private Skills[] avaliableSkills;
    //test
    [SerializeField] private SimpleAnimationSO moveAnim;
    [SerializeField] private SimpleAnimationSO idleAnim;
    public SimpleAnimationSO MoveAnim => moveAnim;
    //get char data
    int maxActionPoints = 2;
    //end test
    private SimpleAnimator animator;
    private List<Skill> skills;  
     
    public float Direction => characterRotationHandler.Direction;
    public int actionPoints;
    private bool isActive;
    private bool inProgress;
    private bool endTurnFlag;
    public Action onTurnEnd;
    private CharacterRotationHandler characterRotationHandler;
    public Action callback;
    public CharacterStats characterStats;
    private void Awake()
    {
        characterRotationHandler = GetComponent<CharacterRotationHandler>();
        animator = GetComponent<SimpleAnimator>();
        characterStats = GetComponent<CharacterStats>();
        callback = ProgressClear;
        skills = new();
        
        
    }
    private void Start() {
        foreach (var item in avaliableSkills)
        {
            skills.Add(SkillFactory.Instance.GetSkill(item, this));
        }
    }
    
    public void PerformAction(Skill action)
    {
        if(!isActive || inProgress) return;
        inProgress = true;
        action.ExecuteAction();
        actionPoints--;
        if(actionPoints <= 0) endTurnFlag = true;
    }
    public Skill[] GetSkills() => skills.ToArray();
    
    
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
        foreach (var item in skills)
        {
            if(item is T) return item;
        }
        return default;
    }
}
