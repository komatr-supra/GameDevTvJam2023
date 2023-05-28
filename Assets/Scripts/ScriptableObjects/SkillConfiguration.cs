using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Character skill", order = 1)]
public class SkillConfiguration : SkillData
{
    public AudioClip clip;
    public int damage = 1;
    public float attackRadius = 1f;
    public GameObject projectilePrefab;
    public float projectileSpeed;
    public Skills skill;
}
public abstract class SkillData : ScriptableObject
{
    public Sprite skillSprite;
}
