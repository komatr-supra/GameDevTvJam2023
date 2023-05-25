using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI roundTMP;
    [SerializeField] private TextMeshProUGUI pointsTMP;
    [SerializeField] private TurnSystem turnSystem;
    private void Start() {
        turnSystem.onActionPOintChange += UpdatePoints;
        turnSystem.onTurnChanged += UpdatePoints;
        turnSystem.onRoundChanged += UpdateRound;
    }

    private void UpdateRound(int roundNumber)
    {
        roundTMP.text = "Round: " + roundNumber;
    }

    private void UpdatePoints()
    {
        pointsTMP.text = "AP: " + turnSystem.currentCharacter.actionPoints;
    }
}
