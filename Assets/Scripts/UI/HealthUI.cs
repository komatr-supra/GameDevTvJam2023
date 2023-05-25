using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    CharacterStats characterStats;
    private void Awake() {
        characterStats = GetComponentInParent<CharacterStats>();
        characterStats.onHealthChange += UpdateHealthUI;
    }
    private void UpdateHealthUI()
    {
        var fillValue = characterStats.health / (float)characterStats.maxHealth;
        healthImage.fillAmount = fillValue;
    }
}
