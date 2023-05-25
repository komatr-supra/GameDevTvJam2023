using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public abstract class Skill
{
    public abstract Sprite SkillSprite { get; }
    protected Action onFinished;
    protected CharacterStats characterStats;
    protected ActionHandler actionHandler;
    protected SkillConfiguration attackConfiguration;
    public Skill(ActionHandler actionHandler, SkillConfiguration attackConfiguration)
    {
        this.actionHandler = actionHandler;
        this.onFinished = actionHandler.callback;
        this.characterStats = actionHandler.characterStats;
        //Debug.Log("abstract constructor");
        this.attackConfiguration = attackConfiguration;
    }

    

    public abstract bool ExecuteAction();
}
