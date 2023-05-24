using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Character Attack", order = 1)]
public class AttackConfiguration : ScriptableObject
{
    public bool isAvailable = true;
    public bool isRanged = false;
    public int damage = 1;
    public float attackRadius = 1f;
    public int turnRecovery = 1;
    public SimpleAnimationSO aniation;
    public GameObject projectilePrefab;
}
