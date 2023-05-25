using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public int roundNumber = 0;
    public static TurnSystem Instance;
    public Action onTurnChanged;
    public ActionHandler[] characters;
    public ActionHandler currentCharacter;
    public Action<int> onRoundChanged;
    public Action onActionPOintChange;
    private int index;
    public Skill[] CharacterSkills => currentCharacter.GetSkills();
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void NextRound()
    {
        ++roundNumber;
        onRoundChanged?.Invoke(roundNumber);
    }
    public void StartFight()
    {
        //this is start of the fight... so maybe another method and triggers to start fight?
        NextRound();
        characters = FindObjectsOfType<ActionHandler>();
        currentCharacter = characters[index];
        currentCharacter.CharacterActive(true);
        currentCharacter.onTurnEnd = NextCharacter;
        currentCharacter.onActionPointsChange = onActionPOintChange;
        onTurnChanged?.Invoke();
    }
    public void NextCharacter()
    {
        currentCharacter.onTurnEnd = null;
        currentCharacter.CharacterActive(false);
        UpdateIndex();
        currentCharacter = characters[index];
        currentCharacter.CharacterActive(true);
        currentCharacter.onActionPointsChange = onActionPOintChange;
        currentCharacter.onTurnEnd = NextCharacter;
        onTurnChanged?.Invoke();
        //NextRound();
    }

    private void UpdateIndex()
    {
        if(index + 1 < characters.Length)
        {
            index++;
        }
        else
        {
            index = 0;
            NextRound();
        }
    }
}
