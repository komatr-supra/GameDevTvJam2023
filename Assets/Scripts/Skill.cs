using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    public abstract Sprite SkillSprite { get; }
    protected Action onFinished;
    protected CharacterStats characterStats;
    protected ActionHandler actionHandler;
    public Skill(ActionHandler actionHandler, Action onFinished, CharacterStats characterStats)
    {
        this.actionHandler = actionHandler;
        this.onFinished = onFinished;
        this.characterStats = characterStats;
        //Debug.Log("abstract constructor");
    }

    

    public abstract void ExecuteAction(Action onFinished);
}
