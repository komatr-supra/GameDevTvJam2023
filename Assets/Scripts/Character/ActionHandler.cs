using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ActionHandler : MonoBehaviour
{
    [SerializeField] private GameObject visualSelector;
    
    int maxActionPoints = 2;
    //end test
    private SimpleAnimator animator;
    public List<Skill> skills;  
     
    public float Direction => characterRotationHandler.Direction;
    public int actionPoints;
    private bool isActive;
    private bool inProgress;
    public Action onTurnEnd;
    public Action onActionPointsChange;
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
        foreach (var item in characterStats.skillConfigurations)
        {
            var skill = SkillFactory.Instance.GetSkill(item.skill, this, item);
            skills.Add(skill);
        }
    }
    
    public void PerformAction(Skill action)
    {
        if(!isActive || inProgress) return;
        if(!action.ExecuteAction()) return;
        inProgress = true;
        --actionPoints;
               
    }
    public Skill[] GetSkills() => skills.ToArray();
    
    
    private void ProgressClear()
    {
        inProgress = false;
        animator.SetAnimation(characterStats.idleAnim);
        onActionPointsChange?.Invoke();
        if(actionPoints <= 0)
        {           
            onTurnEnd?.Invoke();
        }
    }
    public void CharacterActive(bool isActive)
    {
        if(isActive) actionPoints = maxActionPoints;
        visualSelector.SetActive(isActive);
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
