using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SkillFactory : MonoBehaviour
{
    public static SkillFactory Instance;
    private void Awake() {
        Instance = this;

        skills = new();
        skills.Add(typeof(Move));
        skills.Add(typeof(SwordAttack));
        skills.Add(typeof(ShootAttack));
        skills.Add(typeof(FlipSide));
    }
    private List<Type> skills;
    public Skill GetSkill(Skills skill, ActionHandler actionHandler, SkillConfiguration attackConfiguration)
    {
        var skillToCreate = skills[(int)skill];
        Type[] typyPar = new Type[] {typeof(ActionHandler), typeof(SkillConfiguration)};
        ConstructorInfo constructorInfo = skillToCreate.GetConstructor(typyPar);

        
        object[] parametrs = new object[] {actionHandler, attackConfiguration};
        return (Skill)Activator.CreateInstance(skillToCreate, parametrs);
    }
}
public enum Skills{
    move,
    melee,
    shoot,
    flipSide
}
