using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackConfiguration", menuName = "ScriptableObjects/AttackConfiguration", order = 1)]
public class AttackConfiguration : ScriptableObject
{
    public bool isRanged = false;
    public int damage = 1;
    public float attackRadius = 1f;
    public int turnRecovery = 1;
}
